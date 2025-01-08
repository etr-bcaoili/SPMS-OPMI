Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class Configuration
    Private m_ConfigTypeID As Integer = -1
    Private m_ConfigTypeCode As String = String.Empty
    Private m_ConfigTypeName As String = String.Empty


    Public Property ConfigTypeID As Integer
        Get
            Return m_ConfigTypeID
        End Get
        Set(value As Integer)
            m_ConfigTypeID = value
        End Set
    End Property
    Public Property ConfigTypeCode As String
        Get
            Return m_ConfigTypeCode
        End Get
        Set(value As String)
            m_ConfigTypeCode = value
        End Set
    End Property
    Public Property ConfigTypeName As String
        Get
            Return m_ConfigTypeName
        End Get
        Set(value As String)
            m_ConfigTypeName = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As ConfigurationCollection
        Dim col As New ConfigurationCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_Configuration As New Configuration
            Dim row As DataRow = table.Rows(j)
            m_Configuration.m_ConfigTypeID = row("ConfigTypeID")
            m_Configuration.m_ConfigTypeCode = row("ConfigTypeCode")
            m_Configuration.m_ConfigTypeName = row("ConfigTypeName")
            col.Add(m_Configuration)
        Next
        Return col
    End Function
    Public Shared Function Filter(ByVal Condition As String) As ConfigurationCollection
        Return BaseFilter(GetRecords("Select * from ConfigurationType   Where " & Condition, ""))
    End Function
    Public Overloads Shared Function Load() As ConfigurationCollection
        Return Filter("")
    End Function
    Public Shared Function LoadbyCode(ByVal ConfigTypeCode As String) As Configuration
        Return Filter("ConfigTypeCode = '" & HandleSingleQuoteInSql(ConfigTypeCode) & "'")(0)
    End Function
    Public Shared Function GetConfigtypeSql(Optional ByVal Code As String = "") As String
        Return "Select ConfigTypeCode,ConfigTypeCode,ConfigTypeName from ConfigurationType Order by ConfigTypeID "
    End Function
    Public Shared Function GetConfigTypeCode(ByVal Code As String) As String
        Return LoadbyCode(Code).ConfigTypeName
    End Function
    Public Shared Function GetYearbyConfig() As String
        Return "SELECT Distinct CAYR  FROM Calendar Order by CAYR"
    End Function
    Public Shared Function GetMonthConfigtype(ByVal DistributorCode As String, ByVal YearCode As String) As String
        Return "SELECT * FROM Calendar Where COMID  = '" & DistributorCode & "' And CAYR = '" & YearCode & "'"
    End Function
End Class
Public Class ConfigurationCollection
    Inherits List(Of Configuration)
End Class
