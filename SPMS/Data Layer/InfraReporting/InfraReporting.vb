Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class InfraReporting
    Private v_ReportHeaderID As Integer = -1

    Private v_Type As Integer = -1

    Private v_ReportTile As String = String.Empty

    'Private v_InfraReportingID As Integer = -1

    Private v_Code As String = String.Empty

    Private v_Description As String = String.Empty

    Private v_SqlStoredProc As String = String.Empty

    Private v_IsDelete As Integer = -1

    Private v_ReportFilter As New ReportFilterCollection

    'Dim dt As DataTable

    'Public ReadOnly Property InfraReportingID() As Integer
    '    Get
    '        Return v_InfraReportingID
    '    End Get
    'End Property

    Public Enum ReportingType
        SalesSummary = 0
        SalesDetail = 1
        MasterFile = 2
        Others = 3
    End Enum

    Public ReadOnly Property ReportHeaderID() As Integer
        Get
            Return v_ReportHeaderID
        End Get
    End Property

    Public Property Type() As Integer
        Get
            Return v_Type
        End Get
        Set(ByVal value As Integer)
            v_Type = value
        End Set
    End Property

    Public Property ReportTitle() As String
        Get
            Return v_ReportTile
        End Get
        Set(ByVal value As String)
            v_ReportTile = value
        End Set
    End Property

    Public Property Code() As String
        Get
            Return v_Code
        End Get
        Set(ByVal value As String)
            v_Code = value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return v_Description
        End Get
        Set(ByVal value As String)
            v_Description = value
        End Set
    End Property

    Public Property SqlStoredProc() As String
        Get
            Return v_SqlStoredProc
        End Get
        Set(ByVal value As String)
            v_SqlStoredProc = value
        End Set
    End Property

    Public Property IsDeleted() As Integer
        Get
            Return v_IsDelete
        End Get
        Set(ByVal value As Integer)
            v_IsDelete = value
        End Set
    End Property

    Public ReadOnly Property ReportFilterDetails() As ReportFilterCollection
        Get
            Return v_ReportFilter
        End Get
    End Property

    Public Function Save() As Boolean
        connect()
        Try

            Dim sqlCMD As New SqlCommand("uspReportUtils", SPMSConn2)
            sqlCMD.CommandType = CommandType.StoredProcedure
            sqlCMD.Parameters.AddWithValue("@Action", "SAVE")
            sqlCMD.Parameters.AddWithValue("@ReportHeaderID", v_ReportHeaderID)
            sqlCMD.Parameters.AddWithValue("@Type", v_Type)
            sqlCMD.Parameters.AddWithValue("@ReportTitle", v_ReportTile)
            sqlCMD.Parameters.AddWithValue("@Code", v_Code)
            sqlCMD.Parameters.AddWithValue("@Description", v_Description)
            sqlCMD.Parameters.AddWithValue("@SqlStoredProc", v_SqlStoredProc)
            sqlCMD.Parameters.AddWithValue("@IsDeleted", v_IsDelete)
            v_ReportHeaderID = sqlCMD.ExecuteScalar()



            For j As Integer = 0 To Me.v_ReportFilter.Count - 1
                If v_ReportFilter(j).Save = False Then
                    Throw New Exception("Error saving details")
                End If
            Next
            Return True
        Catch ex As Exception
            Disconnect()
            Throw New Exception(ex.Message)
            'Utils.ExclamationBox(ex.Message, "Error")
            Return False
        End Try
    End Function

    Public Function Delete() As Boolean
        Connect()
        Try

            Dim sqlCMD As New SqlCommand("uspReportUtils", SPMSConn2)
            sqlCMD.CommandType = CommandType.StoredProcedure
            sqlCMD.Parameters.AddWithValue("@Action", "DELETE")
            sqlCMD.Parameters.AddWithValue("@ReportHeaderID", v_ReportHeaderID)

            sqlCMD.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            Disconnect()
            Throw New Exception(ex.Message)
            'Utils.ExclamationBox(ex.Message, "Error")
            Return False
        End Try
    End Function

    Private Shared Function BaseFilter(ByVal dt As DataTable) As InfraReportingCollection
        Dim col As New InfraReportingCollection
        For j As Integer = 0 To dt.Rows.Count - 1
            Dim v_InfraReport As New InfraReporting
            Dim row As DataRow = dt.Rows(j)
            v_InfraReport.v_ReportHeaderID = row("ReportHeaderID")
            v_InfraReport.v_Type = row("Type")
            v_InfraReport.v_ReportTile = row("ReportTitle")
            v_InfraReport.v_Code = row("Code")
            v_InfraReport.v_Description = row("Description")
            v_InfraReport.v_SqlStoredProc = row("SqlStoredProc")
            v_InfraReport.v_IsDelete = row("IsDeleted")
            v_InfraReport.v_ReportFilter = ReportFilter.LoadByCode(v_InfraReport.v_Code)
            col.Add(v_InfraReport)
        Next
        Return col
    End Function

    Public Shared Function Filter(ByVal Condition As String) As InfraReportingCollection
        Return BaseFilter(GetRecords("SELECT * FROM ReportHeader " & IIf(Condition <> "", " WHERE " & Condition, "")))
    End Function

    Public Shared Function Load() As InfraReportingCollection
        Return Filter("")
    End Function

    Public Shared Function Load(ByVal ReportHeaderID As Integer) As InfraReportingCollection
        Return Filter("ReportHeaderID = " & ReportHeaderID)
    End Function

    Public Shared Function GetAllTablesColumn() As String
        Return "object_id; Name; type_Desc; Create_Date"
    End Function

    Public Shared Function GetAllTablesSql() As String
        Return "select object_id,Name [Table Name],type_Desc [Description],Create_Date [Date Created] from sys.tables"

    End Function

    Public Shared Function GetStoredProcedureColumns() As String
        Return "object_ID; Name; Type; Type_Desc"
    End Function

    Public Shared Function GetStoreProcedureSQL() As String
        Return "select object_Id,Name [Name],Type [Stored Proc. Type],Type_Desc [Stored Proc. Description]  from sys.objects WHERE type = 'P' and is_ms_shipped = 0 order by name"
    End Function

    Public Shared Function GetInfraReportColumns() As String
        Return "ReportHeaderID; Code; ReportTitle; Description"
    End Function

    Public Shared Function GetInfraReportSQL(ByVal Type As Integer) As String
        Return "SELECT ReportHeaderID,Code , ReportTitle [Report Title], Description   FROM ReportHeader Where IsDeleted = 0 And Type = " & Type
    End Function

    Public Shared Function GetInfraReportSQL() As String
        Return "SELECT ReportHeaderID,Code , ReportTitle [Report Title], Description   FROM ReportHeader Where IsDeleted = 0 "
    End Function

    Public Shared Function GetSPParameter(ByVal SPName As String) As DataTable
        Dim dt As DataTable


        Connect()
        Dim cmd As New SqlClient.SqlCommand("uspSPParameter", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@SPName", SPName)

        Dim da As New SqlClient.SqlDataAdapter(cmd)
        dt = New DataTable

        Disconnect()
        da.Fill(dt)
        Return dt
    End Function

    Public Shared Function GetStoredProcResult(ByVal SP As String) As DataTable
        Return ExecuteStoredProcedure(SP)
    End Function

    Public Shared Function GetTableColumns(ByVal TableName As String) As DataTable
        Return ExecuteStoredProcedure("SELECT Name FROM sys.columns WHERE object_id = OBJECT_ID('" & TableName & "')")

    End Function

    Public Shared Function CheckIfCodeExist(ByVal SP As String) As Boolean
        Return ExecuteCommand("Select 'A' From ReportHeader Where IsDeleted = 0 And Code = '" & JLCLibrary.JStrings.RefineSQL(SP) & "'") = "A"
    End Function
End Class

Public Class InfraReportingCollection
    Inherits List(Of InfraReporting)
End Class

'-----------------------------------------------------------------------------------------
'-----------------------------------------------------------------------------------------

Public Class ReportFilter
    Private v_ReportFilterID As Integer = -1

    Private v_ReportHeaderCode As String = String.Empty

    Private v_FilterLabel As String = String.Empty

    Private v_ColumnName As String = String.Empty

    Private v_DataType As String = String.Empty

    Private v_Search As String = String.Empty

    Private v_SqlColumns As String = String.Empty

    Private v_SqlQuery As String = String.Empty

    Public ReadOnly Property ReportFilterID() As Integer
        Get
            Return v_ReportFilterID
        End Get
    End Property

    Public Property ReportHeaderCode() As String
        Get
            Return v_ReportHeaderCode
        End Get
        Set(ByVal value As String)
            v_ReportHeaderCode = value
        End Set
    End Property

    Public Property FilterLabel() As String
        Get
            Return v_FilterLabel
        End Get
        Set(ByVal value As String)
            v_FilterLabel = value
        End Set
    End Property

    Public Property ColumnName() As String
        Get
            Return v_ColumnName
        End Get
        Set(ByVal value As String)
            v_ColumnName = value
        End Set
    End Property

    Public Property DataType() As String
        Get
            Return v_DataType
        End Get
        Set(ByVal value As String)
            v_DataType = value
        End Set
    End Property

    Public Property Search() As String
        Get
            Return v_Search
        End Get
        Set(ByVal value As String)
            v_Search = value
        End Set
    End Property

    Public Property SqlColumns() As String
        Get
            Return v_SqlColumns
        End Get
        Set(ByVal value As String)
            v_SqlColumns = value
        End Set
    End Property

    Public Property SqlQuery() As String
        Get
            Return v_SqlQuery
        End Get
        Set(ByVal value As String)
            v_SqlQuery = value
        End Set
    End Property

    Public Function Save() As Boolean
        Connect()
        Try
            Dim sqlCMD As New SqlCommand("uspReportUtilDetails", SPMSConn2)
            sqlCMD.CommandType = CommandType.StoredProcedure
            sqlCMD.Parameters.AddWithValue("@Action", "SAVE")
            sqlCMD.Parameters.AddWithValue("@ReportFilerID", v_ReportFilterID)
            sqlCMD.Parameters.AddWithValue("@ReportHeaderCode", v_ReportHeaderCode)
            sqlCMD.Parameters.AddWithValue("@ColumnName", v_ColumnName)
            sqlCMD.Parameters.AddWithValue("@FilterLabel", v_FilterLabel)
            sqlCMD.Parameters.AddWithValue("@DataType", v_DataType)
            sqlCMD.Parameters.AddWithValue("@Search", v_Search)
            sqlCMD.Parameters.AddWithValue("SqlColumns", v_SqlColumns)
            sqlCMD.Parameters.AddWithValue("@SqlQuery", v_SqlQuery)
            v_ReportFilterID = sqlCMD.ExecuteScalar()
            Return True
        Catch ex As Exception
            Disconnect()
            Throw New Exception(ex.Message)
            'Utils.ExclamationBox(ex.Message, "Error")
            Return False
        End Try
    End Function

    Private Shared Function BaseFilter(ByVal dt As DataTable) As ReportFilterCollection
        Dim col As New ReportFilterCollection
        For j As Integer = 0 To dt.Rows.Count - 1
            Dim v_ReportFilter As New ReportFilter
            Dim row As DataRow = dt.Rows(j)
            v_ReportFilter.v_ReportFilterID = row("ReportFilerID")
            v_ReportFilter.v_ReportHeaderCode = row("ReportHeaderCode")
            v_ReportFilter.v_ColumnName = row("ColumnName")
            v_ReportFilter.v_FilterLabel = row("FilterLabel")
            v_ReportFilter.v_DataType = row("DataType")
            v_ReportFilter.v_Search = row("Search")
            v_ReportFilter.v_SqlColumns = row("SqlColumns")
            v_ReportFilter.v_SqlQuery = row("SqlQuery")
            col.Add(v_ReportFilter)
        Next
        Return col
    End Function

    Public Shared Function Filter(ByVal Condition As String) As ReportFilterCollection
        Return BaseFilter(GetRecords("SELECT * FROM ReportFilter " & IIf(Condition <> "", " WHERE " & Condition, "")))
    End Function

    Public Shared Function Load() As ReportFilterCollection
        Return Filter("")
    End Function

    Public Shared Function LoadByCode(ByVal Code As String) As ReportFilterCollection
        Return Filter("ReportHeaderCode = '" & Code & "'")
    End Function

    Public Shared Function GetSqlColumnsByID(ByVal ReportFilterID As Integer) As String
        Return Filter("ReportFilerID = " & ReportFilterID)(0).SqlColumns
    End Function

    Public Shared Function GetSqlQueryByID(ByVal ReportFilterID As Integer) As String
        Return Filter("ReportFilerID = " & ReportFilterID)(0).SqlQuery
    End Function
End Class

Public Class ReportFilterCollection
    Inherits List(Of ReportFilter)
End Class

