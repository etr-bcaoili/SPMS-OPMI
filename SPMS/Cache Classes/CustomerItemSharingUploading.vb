Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class CustomerItemSharingUploading
	Private m_ID As Integer = -1
	Private m_Year As String = String.Empty
	Private m_Month As String = String.Empty
	Private m_ConfigtypeCode As String = String.Empty
	Private m_ConfigtypeName As String = String.Empty
	Private m_ChannelCode As String = String.Empty
	Private m_ChannelName As String = String.Empty
	Private m_CustomerCode As String = String.Empty
	Private m_CustomerName As String = String.Empty
	Private m_ShiptoCode As String = String.Empty
	Private m_ItemCode As String = String.Empty
	Private m_ItemName As String = String.Empty
	Private m_SalesAgentCode As String = String.Empty
	Private m_TerritoryName As String = String.Empty
	Private m_Shared As Decimal = 0
	Private m_OR_SH As String = String.Empty
	Private m_IsActive As Boolean = True
	Private m_CRTBY As String = String.Empty
	Private m_YearFrom As String = String.Empty
	Private m_YearTo As String = String.Empty
	Private m_MonthFrom As String = String.Empty
	Private m_MonthTo As String = String.Empty
	Public ReadOnly Property CustomerItemSharingID As Integer
		Get
			Return m_ID
		End Get
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
	Public Property ConfigtypeCode As String
		Get
			Return m_ConfigtypeCode
		End Get
		Set(value As String)
			m_ConfigtypeCode = value
		End Set
	End Property
	Public Property ConfigtypeName As String
		Get
			Return m_ConfigtypeName
		End Get
		Set(value As String)
			m_ConfigtypeName = value
		End Set
	End Property
	Public Property ChannelCode As String
		Get
			Return m_ChannelCode
		End Get
		Set(value As String)
			m_ChannelCode = value
		End Set
	End Property
	Public Property ChannelName As String
		Get
			Return m_ChannelName
		End Get
		Set(value As String)
			m_ChannelName = value
		End Set
	End Property
	Public Property CustomerCode As String
		Get
			Return m_CustomerCode
		End Get
		Set(value As String)
			m_CustomerCode = value
		End Set
	End Property
	Public Property CustomerName As String
		Get
			Return m_CustomerName
		End Get
		Set(value As String)
			m_CustomerName = value
		End Set
	End Property
	Public Property ShiptoCode As String
		Get
			Return m_ShiptoCode
		End Get
		Set(value As String)
			m_ShiptoCode = value
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
	Public Property ItemName As String
		Get
			Return m_ItemName
		End Get
		Set(value As String)
			m_ItemName = value
		End Set
	End Property
	Public Property SalesAgentCode As String
		Get
			Return m_SalesAgentCode
		End Get
		Set(value As String)
			m_SalesAgentCode = value
		End Set
	End Property
	Public Property TerritoryName As String
		Get
			Return m_TerritoryName
		End Get
		Set(value As String)
			m_TerritoryName = value
		End Set
	End Property
	Public Property Shareds As String
		Get
			Return m_Shared
		End Get
		Set(value As String)
			m_Shared = value
		End Set
	End Property
	Public Property CRTBY As String
		Get
			Return m_CRTBY
		End Get
		Set(value As String)
			m_CRTBY = value
		End Set
	End Property
	Public Property OR_SH As String
		Get
			Return m_OR_SH
		End Get
		Set(value As String)
			m_OR_SH = value
		End Set
	End Property
	Public Property YearFrom As String
		Get
			Return m_YearFrom
		End Get
		Set(value As String)
			m_YearFrom = value
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
	Public Property MonthFrom As String
		Get
			Return m_MonthFrom
		End Get
		Set(value As String)
			m_MonthFrom = value
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
	Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As CustomerItemSharingUploadingCollection
		Dim col As New CustomerItemSharingUploadingCollection
		For j As Integer = 0 To Table.Rows.Count - 1
			Dim m_CustomerItemSharing As New CustomerItemSharingUploading
			Dim row As DataRow = Table.Rows(j)
			m_CustomerItemSharing.m_Year = row("Year")
			m_CustomerItemSharing.m_Month = row("Month")
			m_CustomerItemSharing.m_ConfigtypeCode = row("ConfigtypeCode")
			m_CustomerItemSharing.m_ChannelCode = row("ChannelCode")
			m_CustomerItemSharing.m_CustomerCode = row("CustomerCode")
			m_CustomerItemSharing.m_CustomerName = row("CustomerName")
			m_CustomerItemSharing.m_ShiptoCode = row("ShiptoCode")
			m_CustomerItemSharing.m_ItemCode = row("ItemCode")
			m_CustomerItemSharing.m_SalesAgentCode = row("P")
			m_CustomerItemSharing.m_Shared = row("Shared")
			m_CustomerItemSharing.m_CRTBY = row("CRTBY")
			m_CustomerItemSharing.m_IsActive = row("IsActive")
			m_CustomerItemSharing.m_OR_SH = row("OR-SH")
			col.Add(m_CustomerItemSharing)
		Next
		Return col
	End Function
	Public Function Save() As Boolean
		If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
		Try
			Dim cmd As New SqlCommand("uspCustomerItemSharingUploading", SPMSOPCI.ConnectionModule.SPMSConn2)
			cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.AddWithValue("@Action", "SAVE")
			cmd.Parameters.AddWithValue("@ID", m_ID)
			cmd.Parameters.AddWithValue("@Year", m_Year)
			cmd.Parameters.AddWithValue("@Month", m_Month)
			cmd.Parameters.AddWithValue("@ConfigtypeCode", m_ConfigtypeCode)
			cmd.Parameters.AddWithValue("@ChannelCode", m_ChannelCode)
			cmd.Parameters.AddWithValue("@CustomerCode", m_CustomerCode)
			cmd.Parameters.AddWithValue("@CustomerName", m_CustomerName)
			cmd.Parameters.AddWithValue("@ShiptoCode", m_ShiptoCode)
			cmd.Parameters.AddWithValue("@ItemCode", m_ItemCode)
			cmd.Parameters.AddWithValue("@SalesAgentCode", m_SalesAgentCode)
			cmd.Parameters.AddWithValue("@Shared", m_Shared)
			cmd.Parameters.AddWithValue("@ORSH", m_OR_SH)
			cmd.Parameters.AddWithValue("@IsActive", m_IsActive)
			cmd.Parameters.AddWithValue("@CRTBY", m_CRTBY)
			m_ID = cmd.ExecuteScalar
			SPMSOPCI.ConnectionModule.Disconnect()
			Return True
		Catch ex As Exception
			SPMSOPCI.ConnectionModule.Disconnect()
		End Try
	End Function
	Public Function Delete() As Boolean
		Try
			SPMSOPCI.ConnectionModule.Connect()
			Dim cmd As New SqlCommand("uspCustomerItemSharingUploading", SPMSOPCI.ConnectionModule.SPMSConn2)
			cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.AddWithValue("@Action", "DELETE")
			cmd.Parameters.AddWithValue("@ID", m_ID)
			cmd.ExecuteNonQuery()
			SPMSOPCI.ConnectionModule.Disconnect()
			Return True
		Catch ex As System.Exception
			Throw
		End Try
	End Function
	Public Function CustomerItemSharingCopyFrom()
		Try
			SPMSOPCI.ConnectionModule.Connect()
			Dim cmd As New SqlCommand("uspCustomerItemSharingCopyFrom", SPMSOPCI.ConnectionModule.SPMSConn2)
			cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.AddWithValue("@Action", "CustomerItemSharingCopyFrom")
			cmd.Parameters.AddWithValue("@ConfigtypeCode", m_ConfigtypeCode)
			cmd.Parameters.AddWithValue("@ChannelCode", m_ChannelCode)
			cmd.Parameters.AddWithValue("@YearFrom", m_YearFrom)
			cmd.Parameters.AddWithValue("@MonthFrom", m_MonthFrom)
			cmd.Parameters.AddWithValue("@YearTo", m_YearTo)
			cmd.Parameters.AddWithValue("@MonthTo", m_MonthTo)
			cmd.ExecuteNonQuery()
			SPMSOPCI.ConnectionModule.Disconnect()
			Return True
		Catch ex As System.Exception
			Throw
		End Try
	End Function
	Public Shared Function CheckUploadingFileExist(ByVal Month As String, ByVal Year As String, ByVal ConfigCode As String, ByVal ChannelCode As String) As Boolean
		Return ExecuteCommand("SELECT 'A' FROM CustomerItemSharingUploading Where Month = '" & Month & "' And Year = '" & Year & "' And ConfigtypeCode = '" & ConfigCode & "' And ChannelCode = '" & ChannelCode & "'") = "A"
	End Function
	Public Shared Function DeleteExistList(ByVal Month As String, ByVal Year As String, ByVal ConfigCode As String, ByVal ChannelCode As String) As Boolean
		Return ExecuteCommand("DELETE FROM CustomerItemSharingUploading Where ChannelCode = '" & ChannelCode & "' AND Year = '" & Year & "' AND Month = '" & Month & "' AND ConfigtypeCode = '" & ConfigCode & "'")
	End Function
	Public Shared Function GetItemSharingListSql() As String
		Return "Select Distinct ConfigtypeCode,ChannelCode,Year,Month,ConfigtypeCode From CustomerItemSharingUploading Order by Year,Month,ChannelCode"
	End Function
	Public Shared Function GetCustomerItemSharingListSql(ByVal ChannelCode As String, ByVal Year As String, ByVal Month As String, ByVal ConfigtypeCode As String) As String
		Return "Select Distinct ChannelCode,Year,Month,ConfigtypeCode From CustomerItemSharingUploading Where ChannelCode = '" & ChannelCode & "' And Year = '" & Year & "' And Month = '" & Month & "' And ConfigtypeCode = '" & ConfigtypeCode & "'"
	End Function
End Class
Public Class CustomerItemSharingUploadingCollection
	Inherits List(Of CustomerItemSharingUploading)
End Class
