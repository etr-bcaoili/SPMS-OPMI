
Imports System.Data.SqlClient
Public Class ProductManagerMapping
    Private _ID As Integer = -1
    Private _ProductManagerCode As String = String.Empty
    Private _ProductManagerName As String = String.Empty
    Private _ItemCode As String = String.Empty
    Private _ItemName As String = String.Empty
    Private _EffectivityStartDate As Date = "1/1/1990"
    Private _EffectivityEndDate As Date = "1/1/1990"
    Private m_Createby As String = String.Empty
    Public ReadOnly Property ID As Integer
        Get
            Return _ID
        End Get
    End Property
    Public Property PriductManagerCode As String
        Get
            Return _ProductManagerCode
        End Get
        Set(value As String)
            _ProductManagerCode = value
        End Set
    End Property
    Public Property ProductManagerName As String
        Get
            Return _ProductManagerName
        End Get
        Set(value As String)
            _ProductManagerName = value
        End Set
    End Property
    Public Property ItemCode As String
        Get
            Return _ItemCode
        End Get
        Set(value As String)
            _ItemCode = value
        End Set
    End Property
    Public Property ItemDescriptionName As String
        Get
            Return _ItemName
        End Get
        Set(value As String)
            _ItemName = value
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
    Public Property Createby As String
        Get
            Return m_Createby
        End Get
        Set(value As String)
            m_Createby = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As ProductManagerMappingCollection
        Dim col As New ProductManagerMappingCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _ProductManagerMapping As New ProductManagerMapping
            Dim row As DataRow = Table.Rows(j)
            _ProductManagerMapping._ID = row("ID")
            _ProductManagerMapping._ProductManagerCode = row("PMCode")
            _ProductManagerMapping._ProductManagerName = row("PMName")
            _ProductManagerMapping._ItemCode = row("ItemMotherCode")
            _ProductManagerMapping._ItemName = row("ItemMotherName")
            _ProductManagerMapping._EffectivityStartDate = row("StartDateEffectivity")
            _ProductManagerMapping._EffectivityEndDate = row("EndDateEffectivity")
            _ProductManagerMapping.m_Createby = row("Createdby")
            col.Add(_ProductManagerMapping)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspProductManagersMapping", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@ID", _ID)
            cmd.Parameters.AddWithValue("@PMCode", _ProductManagerCode)
            cmd.Parameters.AddWithValue("@PMName", _ProductManagerName)
            cmd.Parameters.AddWithValue("@ItemMotherCode", _ItemCode)
            cmd.Parameters.AddWithValue("@ItemMotherName", _ItemName)
            cmd.Parameters.AddWithValue("@StartDateEffectivity", _EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EndDateEffectivity", _EffectivityEndDate)
            cmd.Parameters.AddWithValue("@Createdby", m_Createby)
            _ID = cmd.ExecuteScalar
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Function Delete() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspProductManagersMapping", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "Delete")
            cmd.Parameters.AddWithValue("@PMCode", _ProductManagerCode)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Function GetProductManagerItemMapping(ByVal ProductManagerItemCode As String) As String
        Return "SELECT PMCode,ItemMotherCode,ItemMotherName,StartDateEffectivity,EndDateEffectivity FROM [ProductManagersMapping] Where PMCode = '" & ProductManagerItemCode & "'"
    End Function
    Public Shared Function GetProductManagerItemMappingSql() As String
        Return "SELECT Distinct PMCode,PMCode [Product Manager Code],PMName [Product Manager Name],StartDateEffectivity [Start Date Effectivity] FROM [ProductManagersMapping]"
    End Function

End Class
Public Class ProductManagerMappingCollection
    Inherits List(Of ProductManagerMapping)
End Class