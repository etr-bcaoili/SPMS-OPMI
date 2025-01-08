Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class OverviewData
    Private m_ConfigtypeCode As String = String.Empty
    Private m_Year As String = String.Empty
    Private m_ItemDivisionCode As String = String.Empty
    Private m_DistrictManagerCode As String = String.Empty
    Private m_TerritoryManagerCode As String = String.Empty

    Public Property ConfigtypeCopde As String
        Get
            Return m_ConfigtypeCode
        End Get
        Set(value As String)
            m_ConfigtypeCode = value
        End Set
    End Property
    Public Property Year As String
        Get
            Return m_Year
        End Get
        Set(value As String)
            m_Year = value
        End Set
    End Property
    Public Property ItemDivisionCode As String
        Get
            Return m_ItemDivisionCode
        End Get
        Set(value As String)
            m_ItemDivisionCode = value
        End Set
    End Property
    Public Property DistrictManagerCode As String
        Get
            Return m_DistrictManagerCode
        End Get
        Set(value As String)
            m_DistrictManagerCode = value
        End Set
    End Property
    Public Property TerritoryManagerCode As String
        Get
            Return m_TerritoryManagerCode
        End Get
        Set(value As String)
            m_TerritoryManagerCode = value
        End Set
    End Property
    Public Shared Function GetItemDivision(ByVal ConfigTypeCode As String, ByVal Year As String) As String
        Return "Select Distinct A.[Item Division Code] ,B.ITMDIVNAME [Item Division Description] From Sc02File A Inner Join ItemDivision B On A.[Item Division Code] = B.ITMDIVCD Where A.Configtypecode = '" & ConfigTypeCode & "' And Year = '" & Year & "' And  B.DLTFLG = 0 Order by A.[Item Division Code]"
    End Function
    Public Shared Function GetDistrictManager(ByVal ConfigTypeCode As String, ByVal ItemDivisionCode As String, ByVal Year As String) As String
        Return "Select A.[Item Division Code],A.[District Manager Code],B.STSLSMGRNAME [District Manager Name] From SC02File A INNER JOIN STSalesManager B ON A.[District Manager Code] = B.STSLSMGRCD  Where A.Configtypecode = '" & ConfigTypeCode & "' And A.[Item Division Code] = '" & ItemDivisionCode & "' And A.Year = '" & Year & "' Group by A.[Item Division Code],A.[District Manager Code],B.STSLSMGRNAME  Order by [District Manager Code]"
    End Function
    Public Shared Function GetTerritoryManager(ByVal ConfigTypeCode As String, ByVal ItemDivisionCode As String, ByVal DistrictManagerCode As String, ByVal Year As String) As String
        Return "Select A.[Item Division Code],A.[District Manager Code],A.[Territory Manager Code],B.STSLSMNNAME [Territory Manager Name] From SC02File A INNER JOIN SalesMatrix B ON A.[Territory Manager Code] = B.STTERRCD And B.Configtypecode = '" & ConfigTypeCode & "' Where A.Configtypecode = '" & ConfigTypeCode & "' And A.[Item Division Code] = '" & ItemDivisionCode & "' And A.[District Manager Code] = '" & DistrictManagerCode & "' And A.Year = '" & Year & "' Group by A.[Item Division Code],A.[District Manager Code],A.[Territory Manager Code],B.STSLSMNNAME Order by A.[District Manager Code]"
    End Function
    Public Shared Function GetTreeViewMasterlist() As String
        Return "SELECT Distinct ROW_NUMBER() OVER(ORDER BY [Item Division Code])  AS RowNum, [Item Division Code],[District Manager Code],[Territory Code] From SC02SalesOverView GROUP BY [Item Division Code],[District Manager Code],[Territory Code]"
    End Function
    Public Shared Function GetTestingChart(ByVal TerritoryCode As String, ByVal ProductCode As String)
        Return "SE"
    End Function
    Public Shared Function ResetOverview() As String
        ExecuteCommand("Truncate table SC02SalesOverView")
    End Function
    Public Function InsertIntoSalesOverView() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspSC02SalesOverView", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "GetSalesOverview")
            cmd.Parameters.AddWithValue("@ConfigTypeCode", m_ConfigtypeCode)
            cmd.Parameters.AddWithValue("@Year", m_Year)
            cmd.Parameters.AddWithValue("@ItemDivisionCode", m_ItemDivisionCode)
            cmd.Parameters.AddWithValue("@DistrictManagerCode", m_DistrictManagerCode)
            cmd.Parameters.AddWithValue("@TerritoryManagerCode", m_TerritoryManagerCode)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class
