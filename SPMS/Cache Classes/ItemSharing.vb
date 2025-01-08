Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class ItemSharing
    Private m_ID As Integer = -1

    Private m_IDS As Integer = -1

    Private m_Config As String = String.Empty

    Private m_Year As String = String.Empty

    Private m_Month As String = String.Empty

    Private m_SDI As String = String.Empty

    Private m_ItemCode As String = String.Empty

    Private m_PMRAB As String = String.Empty

    Private m_PMRABSHR As Decimal = 0

    Private m_PMRC As String = String.Empty

    Private m_PMRCSHR As Decimal = 0

    Private m_PMRD As String = String.Empty

    Private m_PMRDSHR As Decimal = 0

    Private m_PMREF As String = String.Empty

    Private m_PMREFSHR As Decimal = 0

    Private m_TOTALSHR As Decimal = 0

    Private m_Status As Boolean = False

    Private m_PGCode As String = String.Empty

    Private m_PMRCodeMajor As String = String.Empty

    Private m_PMRCodejonior As String = String.Empty

    Private m_ItemSharingCollectionID As Integer = -1

    Private m_YearTo As String = String.Empty

    Private m_MonthTo As String = String.Empty




    Public ReadOnly Property ID As Integer
        Get
            Return m_ID
        End Get
    End Property
    Public Property IDS As Integer
        Get
            Return m_IDS
        End Get
        Set(value As Integer)
            m_IDS = value
        End Set
    End Property
    Public Property Config As String
        Get
            Return m_Config
        End Get
        Set(value As String)
            m_Config = value
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
    Public Property Month As String
        Get
            Return m_Month
        End Get
        Set(value As String)
            m_Month = value
        End Set
    End Property
    Public Property SDI As String
        Get
            Return m_SDI
        End Get
        Set(value As String)
            m_SDI = value
        End Set
    End Property
    Public Property ItemCode As String
        Get
            Return m_ItemCode
        End Get
        Set(value As String)
            m_ItemCode = value
        End Set
    End Property
    Public Property PMRAB As String
        Get
            Return m_PMRAB
        End Get
        Set(value As String)
            m_PMRAB = value
        End Set
    End Property
    Public Property PMRABSHR As Decimal
        Get
            Return m_PMRABSHR
        End Get
        Set(value As Decimal)
            m_PMRABSHR = value
        End Set
    End Property
    Public Property PMRC As String
        Get
            Return m_PMRC
        End Get
        Set(value As String)
            m_PMRC = value
        End Set
    End Property
    Public Property PMRCSHR As Decimal
        Get
            Return m_PMRCSHR
        End Get
        Set(value As Decimal)
            m_PMRCSHR = value
        End Set
    End Property
    Public Property PMRD As String
        Get
            Return m_PMRD
        End Get
        Set(value As String)
            m_PMRD = value
        End Set
    End Property
    Public Property PMRDSHR As Decimal
        Get
            Return m_PMRDSHR
        End Get
        Set(value As Decimal)
            m_PMRDSHR = value
        End Set
    End Property
    Public Property PMREF As String
        Get
            Return m_PMREF
        End Get
        Set(value As String)
            m_PMREF = value
        End Set
    End Property
    Public Property PMREFSHR As Decimal
        Get
            Return m_PMREFSHR
        End Get
        Set(value As Decimal)
            m_PMREFSHR = value
        End Set
    End Property
    Public Property TOTALSHR As Decimal
        Get
            Return m_TOTALSHR
        End Get
        Set(value As Decimal)
            m_TOTALSHR = value
        End Set
    End Property
    Public Property Status As Boolean
        Get
            Return m_Status
        End Get
        Set(value As Boolean)
            m_Status = value
        End Set
    End Property
    Public Property PGCode As String
        Get
            Return m_PGCode
        End Get
        Set(value As String)
            m_PGCode = value
        End Set
    End Property
    Public Property PMRCodeMajor As String
        Get
            Return m_PMRCodeMajor
        End Get
        Set(value As String)
            m_PMRCodeMajor = value
        End Set
    End Property
    Public Property PMRCodejonior As String
        Get
            Return m_PMRCodejonior
        End Get
        Set(value As String)
            m_PMRCodejonior = value
        End Set
    End Property
    Public Property ItemSharingCollectionID As String
        Get
            Return m_ItemSharingCollectionID
        End Get
        Set(value As String)
            m_ItemSharingCollectionID = value
        End Set
    End Property
    Public Property YearTo As String
        Get
            Return m_YearTo
        End Get
        Set(value As String)
            m_YearTo = value
        End Set
    End Property
    Public Property MonthTo As String
        Get
            Return m_MonthTo
        End Get
        Set(value As String)
            m_MonthTo = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As ItemSharingCollection
        Dim col As New ItemSharingCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_ItemSharing As New ItemSharing
            Dim row As DataRow = table.Rows(j)
            m_ItemSharing.m_ID = row("ID")
            m_ItemSharing.m_SDI = row("SDI")
            m_ItemSharing.m_Config = row("CONFIG")
            m_ItemSharing.m_Year = row("YEAR")
            m_ItemSharing.m_Month = row("MONTH")
            m_ItemSharing.m_ItemCode = row("ITEMCODE")
            m_ItemSharing.m_PMRAB = row("PMRAB")
            m_ItemSharing.m_PMRABSHR = row("PMRABSHR")
            m_ItemSharing.m_PMRC = row("PMRC")
            m_ItemSharing.m_PMRCSHR = row("PMRCSHR")
            m_ItemSharing.m_PMRD = row("PMRD")
            m_ItemSharing.m_PMRDSHR = row("PMRDSHR")
            m_ItemSharing.m_PMREF = row("PMREF")
            m_ItemSharing.m_PMREFSHR = row("PMREFSHR")
            m_ItemSharing.m_TOTALSHR = row("TOTALSHR")
            m_ItemSharing.m_Status = row("STATUS")
            col.Add(m_ItemSharing)
        Next
        Return col
    End Function
    Private Shared Function BaseFilters(ByVal table As System.Data.DataTable) As ItemSharingPGCollection
        Dim col As New ItemSharingPGCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_ItemSharingPG As New ItemSharing
            Dim row As DataRow = table.Rows(j)
            m_ItemSharingPG.m_Config = row("CONFIG")
            m_ItemSharingPG.m_Year = row("YEAR")
            m_ItemSharingPG.m_Month = row("MONTH")
            m_ItemSharingPG.m_ItemCode = row("ITEMCODE")
            m_ItemSharingPG.m_PGCode = row("PGCODE")
            m_ItemSharingPG.m_Status = row("STATUS")
            col.Add(m_ItemSharingPG)
        Next
        Return col
    End Function

    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspItemSharingCollection", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.Parameters.AddWithValue("@SDI", m_SDI)
            cmd.Parameters.AddWithValue("@CONFIG", m_Config)
            cmd.Parameters.AddWithValue("@YEAR", m_Year)
            cmd.Parameters.AddWithValue("@MONTH", m_Month)
            cmd.Parameters.AddWithValue("@ITEMCODE", m_ItemCode)
            cmd.Parameters.AddWithValue("@PMRAB", m_PMRAB)
            cmd.Parameters.AddWithValue("@PMRABSHR", m_PMRABSHR)
            cmd.Parameters.AddWithValue("@PMRC", m_PMRC)
            cmd.Parameters.AddWithValue("@PMRCSHR", m_PMRCSHR)
            cmd.Parameters.AddWithValue("@PMRD", m_PMRD)
            cmd.Parameters.AddWithValue("@PMRDSHR", m_PMRDSHR)
            cmd.Parameters.AddWithValue("@PMREF", m_PMREF)
            cmd.Parameters.AddWithValue("@PMREFSHR", m_PMREFSHR)
            cmd.Parameters.AddWithValue("@TOTALSHR", m_TOTALSHR)
            cmd.Parameters.AddWithValue("@STATUS", m_Status)
            m_ID = cmd.ExecuteScalar()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Function SaveItemSharing()
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspItemSharing", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Get")
            cmd.Parameters.AddWithValue("@Config", m_Config)
            cmd.Parameters.AddWithValue("@Year", m_Year)
            cmd.Parameters.AddWithValue("@Month", m_Month)
            cmd.Parameters.AddWithValue("@ItemCode", m_ItemCode)
            cmd.ExecuteNonQuery()
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
            Dim cmd As New SqlCommand("uspItemSharingCollection", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "UPDATE")
            cmd.Parameters.AddWithValue("@ID", m_IDS)
            cmd.Parameters.AddWithValue("@SDI", m_SDI)
            cmd.Parameters.AddWithValue("@CONFIG", m_Config)
            cmd.Parameters.AddWithValue("@YEAR", m_Year)
            cmd.Parameters.AddWithValue("@MONTH", m_Month)
            cmd.Parameters.AddWithValue("@ITEMCODE", m_ItemCode)
            cmd.Parameters.AddWithValue("@PMRAB", m_PMRAB)
            cmd.Parameters.AddWithValue("@PMRABSHR", m_PMRABSHR)
            cmd.Parameters.AddWithValue("@PMRC", m_PMRC)
            cmd.Parameters.AddWithValue("@PMRCSHR", m_PMRCSHR)
            cmd.Parameters.AddWithValue("@PMRD", m_PMRD)
            cmd.Parameters.AddWithValue("@PMRDSHR", m_PMRDSHR)
            cmd.Parameters.AddWithValue("@PMREF", m_PMREF)
            cmd.Parameters.AddWithValue("@PMREFSHR", m_PMREFSHR)
            cmd.Parameters.AddWithValue("@TOTALSHR", m_TOTALSHR)
            cmd.Parameters.AddWithValue("@STATUS", True)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function

    Public Function SavePG() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspItemSharingCollectionPG", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.Parameters.AddWithValue("@CONFIG", m_Config)
            cmd.Parameters.AddWithValue("@YEAR", m_Year)
            cmd.Parameters.AddWithValue("@MONTH", m_Month)
            cmd.Parameters.AddWithValue("@ITEMCODE", m_ItemCode)
            cmd.Parameters.AddWithValue("@PGCODE", m_PGCode)
            m_ID = cmd.ExecuteScalar()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Function InsertItemSharingMajor()
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspItemSharingSeparate", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "ItemSharingMajor")
            cmd.Parameters.AddWithValue("@Config", m_Config)
            cmd.Parameters.AddWithValue("@Year", m_Year)
            cmd.Parameters.AddWithValue("@Month", m_Month)
            cmd.Parameters.AddWithValue("@ItemCode", m_ItemCode)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try

    End Function
    Public Function InsertItemSharingSC03Major()
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspINSERTSC03", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "ItemSharingMajor")
            cmd.Parameters.AddWithValue("@Config", m_Config)
            cmd.Parameters.AddWithValue("@Year", m_Year)
            cmd.Parameters.AddWithValue("@Month", m_Month)
            cmd.Parameters.AddWithValue("@ItemCode", m_ItemCode)
            cmd.Parameters.AddWithValue("@PMRCodeMajor", m_PMRCodeMajor)
            cmd.Parameters.AddWithValue("@ItemSharingCollectionID", m_ItemSharingCollectionID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try

    End Function
    Public Function InsertSC03ItemSharingJonior()
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspINSERTSC03", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "ItemSharingJonior")
            cmd.Parameters.AddWithValue("@Config", m_Config)
            cmd.Parameters.AddWithValue("@Year", m_Year)
            cmd.Parameters.AddWithValue("@Month", m_Month)
            cmd.Parameters.AddWithValue("@ItemCode", m_ItemCode)
            cmd.Parameters.AddWithValue("@PMRCodejonior", m_PMRCodejonior)
            cmd.Parameters.AddWithValue("@PMRCodeMajor", m_PMRCodeMajor)
            cmd.Parameters.AddWithValue("@ItemSharingCollectionID", m_ItemSharingCollectionID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try

    End Function
    Public Function ExecuteItemSharingWithSalesmatrix(ByVal ConfigtypeCode As String)
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspExecuteItemSharingPG", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ConfigtypeCode", ConfigtypeCode)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try

    End Function
    Public Function InsertItemSharingJonior()
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspItemSharingSeparate", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "ItemSharingJonior")
            cmd.Parameters.AddWithValue("@Config", m_Config)
            cmd.Parameters.AddWithValue("@Year", m_Year)
            cmd.Parameters.AddWithValue("@Month", m_Month)
            cmd.Parameters.AddWithValue("@ItemCode", m_ItemCode)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try

    End Function
    Public Function ItemSharingCopyFrom()
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspItemSharingCollectionCopyFrom", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ConfigtypeCode", m_Config)
            cmd.Parameters.AddWithValue("@YearFrom", m_Year)
            cmd.Parameters.AddWithValue("@MonthFrom", m_Month)
            cmd.Parameters.AddWithValue("@ItemCode", m_ItemCode)
            cmd.Parameters.AddWithValue("@YearTo", m_YearTo)
            cmd.Parameters.AddWithValue("@MonthTo", m_MonthTo)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Function ItemSharingPGCopyFrom()
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspItemSharingCollectionCopyFrom", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "ItemSharingCollectionPG")
            cmd.Parameters.AddWithValue("@ConfigtypeCode", m_Config)
            cmd.Parameters.AddWithValue("@YearFrom", m_Year)
            cmd.Parameters.AddWithValue("@MonthFrom", m_Month)
            cmd.Parameters.AddWithValue("@ItemCode", m_ItemCode)
            cmd.Parameters.AddWithValue("@YearTo", m_YearTo)
            cmd.Parameters.AddWithValue("@MonthTo", m_MonthTo)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Shared Function BaseFilters(ByVal Condition As String) As ItemSharingPGCollection
        Return BaseFilters(GetRecords("Select * From [ItemSharingCollectionPG] Where Status = 1 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As ItemSharingPGCollection
        Return BaseFilters("")
    End Function
    Public Shared Function GetItemDetailSql(ByVal ConfigtypeCode As String) As String
        Return "Select Distinct A.ITEMDIVCD,A.ITEMDIVCD [Product Group],B.ITEMCD [Item Code],A.ITEMMDES [Item Description] From Item A Inner Join  TerritoryItemTarget B ON A.itemthr = B.ITEMCD And  B.ConfigTypeCode = '" & ConfigtypeCode & "' Where A.ITEMDIVCD NOT IN ('99','NPP') Order by A.ITEMDIVCD"
    End Function
    Public Shared Function CheckofItemSharingAlreadyExist(ByVal ConfigtypeCode As String, ByVal Years As String, Months As String, ByVal ItemCode As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM ItemSharingCollection Where Year = '" & Years & "' and MONTH = '" & Months & "' and ITEMCODE = '" & ItemCode & "' and CONFIG = '" & ConfigtypeCode & "'") = "A"
    End Function
    Public Shared Function GetItemSharingSql(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String, ByVal ItemCode As String) As String
        Return "Select PMRAB,PMRABSHR,PMRC,PMRCSHR,PMRD,PMRDSHR,PMREF,PMREFSHR,TOTALSHR,SDI,ID From [ItemSharingCollection] Where Year = '" & Year & "' and MONTH = '" & Month & "' and ITEMCODE = '" & ItemCode & "' and CONFIG = '" & ConfigtypeCode & "'"
    End Function
    Public Shared Function GetItemSharingPGSql(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String, ByVal ItemCode As String) As String
        Return "Select CONFIG,YEAR,MONTH,ITEMCODE,PGCODE  From [ItemSharingCollectionPG] Where Year = '" & Year & "' and MONTH = '" & Month & "' and ITEMCODE = '" & ItemCode & "' and CONFIG = '" & ConfigtypeCode & "'"
    End Function
    Public Shared Function CheckofItemSharingPGAlreadyExist(ByVal ConfigtypeCode As String, ByVal Years As String, Months As String, ByVal ItemCode As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM ItemSharingCollectionPG Where Year = '" & Years & "' and MONTH = '" & Months & "' and ITEMCODE = '" & ItemCode & "' and CONFIG = '" & ConfigtypeCode & "'") = "A"
    End Function
    Public Shared Function GetItemSharingMajorSql(ByVal ConfigtypeCode As String, ByVal Years As String, Months As String, ByVal ItemCode As String) As String
        Return "Select Config,Month,Year,ItemCode,PMRCode,ItemSharingCollectionID From ItemSharingMajor Where Config = '" & ConfigtypeCode & "' AND Month = '" & Months & "' AND Year = '" & Years & "' AND ItemCode = '" & ItemCode & "'"
    End Function
    Public Shared Function GetItemSharingJoniorSql(ByVal ConfigtypeCode As String, ByVal Years As String, Months As String, ByVal ItemCode As String, ByVal ItemSharingID As Integer) As String
        Return "Select Config,Month,Year,ItemCode,PMRCode,ItemSharingCollectionID From ItemSharingJonior Where Config = '" & ConfigtypeCode & "' AND Month = '" & Months & "' AND Year = '" & Years & "' AND ItemCode = '" & ItemCode & "'"
    End Function
    Public Shared Function GetItemSharingListSql() As String
        Return "Select Distinct A.CONFIG,A.CONFIG [CONFIGTYPE CODE],A.Year [YEAR],A.Month [MONTH],A.ITEMCODE [ITEM CODE],B.IMDBRN [ITEM BRAND] from ItemSharingCollection A Inner Join Item B On A.ItemCode = B.ITEMCD  Order by A.YEAR,A.MONTH"
    End Function
    Public Shared Function GetItemSharingListbyOneSQl(ByVal ConfigtypeCode As String, ByVal ItemCode As String, ByVal Year As String, ByVal Month As String) As String
        Return "Select Distinct A.CONFIG ,C.ConfigTypeName,A.Year,A.Month,A.ITEMCODE,B.IMDBRN From ItemSharingCollection A Inner Join Item B On A.ItemCode = B.ITEMCD Inner Join ConfigurationType C  ON A.CONFIG = C.ConfigTypeCode Where A.CONFIG = '" & ConfigtypeCode & "' And A.ITEMCODE = '" & ItemCode & "' And A.YEAR = '" & Year & "' And A.Month = '" & Month & "'  Order by A.YEAR,A.MONTH"
    End Function
    Public Shared Function DeleteFromProductGroup(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String, ByVal ItemCode As String) As Boolean
        Return ExecuteCommand("Delete From ItemSharingCollectionPG Where CONFIG = '" & ConfigtypeCode & "' AND YEAR = '" & Year & "' AND MONTH = '" & Month & "' AND  ITEMCODE = '" & ItemCode & "'")
    End Function
    Public Shared Function DeleteFromItemSharingCollection(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String, ByVal ItemCode As String) As Boolean
        Return ExecuteCommand("Delete From ItemSharingCollection Where CONFIG = '" & ConfigtypeCode & "' AND YEAR = '" & Year & "' AND MONTH = '" & Month & "' AND  ITEMCODE = '" & ItemCode & "'")
    End Function
    Public Shared Function DeleteItemSharingMajorCollection(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String, ByVal ItemCode As String) As Boolean
        Return ExecuteCommand("Delete From ItemSharingMajor Where CONFIG = '" & ConfigtypeCode & "' AND YEAR = '" & Year & "' AND MONTH = '" & Month & "' AND  ITEMCODE = '" & ItemCode & "'")
    End Function
    Public Shared Function DeleteItemSharingJoniorCollection(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String, ByVal ItemCode As String) As Boolean
        Return ExecuteCommand("Delete From ItemSharingJonior Where CONFIG = '" & ConfigtypeCode & "' AND YEAR = '" & Year & "' AND MONTH = '" & Month & "' AND  ITEMCODE = '" & ItemCode & "'")
    End Function
    Public Shared Function DeleteFromItemSharingSC03(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String, ByVal ItemCode As String) As Boolean
        Return ExecuteCommand("Delete From SC03 Where Configtypecode = '" & ConfigtypeCode & "' AND YEAR = '" & Year & "' AND MONTH = '" & Month & "' AND  [Item Mother Code] = '" & ItemCode & "'")
    End Function
    Public Shared Function CheckofCopyFromExist(ByVal Month As String, ByVal Year As String, ByVal ConfigCode As String, ByVal ItemCode As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM CustomerItemSharing Where Month = '" & Month & "' And Year = '" & Year & "' And CONFIG = '" & ConfigCode & "'  And ITEMCODE = " & ItemCode) = "A"
    End Function
End Class
Public Class ItemSharingCollection
    Inherits List(Of ItemSharing)
End Class
Public Class ItemSharingPGCollection
    Inherits List(Of ItemSharing)
End Class
