Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class CustomerItemSharing
	Private m_ID As Integer = -1
	Private m_TRSCODE As String = String.Empty
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
	Private m_PMRORG As String = String.Empty
	Private m_PMRORGName As String = String.Empty
	Private m_PERSHRORG As Decimal = 0
	Private m_PMRCO As String = String.Empty
	Private m_PMRCOName As String = String.Empty
	Private m_PERSHRCO As Decimal = 0
	Private m_IsActive As Boolean = True
	Private m_CRTBY As String = String.Empty

	Private m_YearFrom As String = String.Empty

	Private m_MonthFrom As String = String.Empty

	Private m_YearTo As String = String.Empty

	Private m_MonthTo As String = String.Empty



	Public ReadOnly Property CustomerItemSharingID As Integer
		Get
			Return m_ID
		End Get
	End Property
	Public Property TRSCODE As String
		Get
			Return m_TRSCODE
		End Get
		Set(value As String)
			m_TRSCODE = value
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
	Public Property PMRCO As String
		Get
			Return m_PMRCO
		End Get
		Set(value As String)
			m_PMRCO = value
		End Set
	End Property
	Public Property PMRCOName As String
		Get
			Return m_PMRCOName
		End Get
		Set(value As String)
			m_PMRCOName = value
		End Set
	End Property
	Public Property PERSHRORG As String
		Get
			Return m_PERSHRORG
		End Get
		Set(value As String)
			m_PERSHRORG = value
		End Set
	End Property
	Public Property PMRORG As String
		Get
			Return m_PMRORG
		End Get
		Set(value As String)
			m_PMRORG = value
		End Set
	End Property
	Public Property PMRORGName As String
		Get
			Return m_PMRORGName
		End Get
		Set(value As String)
			m_PMRORGName = value
		End Set
	End Property
	Public Property PERSHRCO As String
		Get
			Return m_PERSHRCO
		End Get
		Set(value As String)
			m_PERSHRCO = value
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
	Public Property YearFrom As String
		Get
			Return m_YearFrom
		End Get
		Set(value As String)
			m_YearFrom = value
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

	Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As CustomerItemSharingCollection
		Dim col As New CustomerItemSharingCollection
		For j As Integer = 0 To Table.Rows.Count - 1
			Dim m_CustomerItemSharing As New CustomerItemSharing
			Dim row As DataRow = Table.Rows(j)
			m_CustomerItemSharing.m_TRSCODE = row("TRSCODE")
			m_CustomerItemSharing.m_Year = row("Year")
			m_CustomerItemSharing.m_Month = row("Month")
			m_CustomerItemSharing.m_ConfigtypeCode = row("ConfigtypeCode")
			m_CustomerItemSharing.m_ConfigtypeName = row("ConfigtypeDescription")
			m_CustomerItemSharing.m_ChannelCode = row("ChannelCode")
			m_CustomerItemSharing.m_ChannelName = row("ChannelDescription")
			m_CustomerItemSharing.m_CustomerCode = row("CustomerCode")
			m_CustomerItemSharing.m_CustomerName = row("CustomerName")
			m_CustomerItemSharing.m_ShiptoCode = row("ShiptoCode")
			m_CustomerItemSharing.m_ItemCode = row("ItemCode")
			m_CustomerItemSharing.m_ItemName = row("ItemName")
			m_CustomerItemSharing.m_PMRORG = row("PMRORG")
			m_CustomerItemSharing.m_PMRORGName = row("PMRORGDescrition")
			m_CustomerItemSharing.m_PERSHRORG = row("PERSHRORG")
			m_CustomerItemSharing.m_PMRCO = row("PMRCO")
			m_CustomerItemSharing.m_PMRCOName = row("PMRCODescription")
			m_CustomerItemSharing.m_PERSHRCO = row("PERSHRCO")
			m_CustomerItemSharing.m_CRTBY = row("CRTBY")
			m_CustomerItemSharing.m_IsActive = row("IsActive")
			col.Add(m_CustomerItemSharing)
		Next
		Return col
	End Function
	Public Function Save() As Boolean
		If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
		Try
			Dim cmd As New SqlCommand("uspCustomerItemSharing", SPMSOPCI.ConnectionModule.SPMSConn2)
			cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.AddWithValue("@Action", "SAVE")
			cmd.Parameters.AddWithValue("@ID", m_ID)
			cmd.Parameters.AddWithValue("@TRSCODE", m_TRSCODE)
			cmd.Parameters.AddWithValue("@Year", m_Year)
			cmd.Parameters.AddWithValue("@Month", m_Month)
			cmd.Parameters.AddWithValue("@ConfigtypeCode", m_ConfigtypeCode)
			cmd.Parameters.AddWithValue("@ConfigtypeName", m_ConfigtypeName)
			cmd.Parameters.AddWithValue("@ChannelCode", m_ChannelCode)
			cmd.Parameters.AddWithValue("@ChannelName", m_ChannelName)
			cmd.Parameters.AddWithValue("@CustomerCode", m_CustomerCode)
			cmd.Parameters.AddWithValue("@CustomerName", m_CustomerName)
			cmd.Parameters.AddWithValue("@ShiptoCode", m_ShiptoCode)
			cmd.Parameters.AddWithValue("@ItemCode", m_ItemCode)
			cmd.Parameters.AddWithValue("@ItemName", m_ItemName)
			cmd.Parameters.AddWithValue("@PMRORG", m_PMRORG)
			cmd.Parameters.AddWithValue("@PMRORGName", m_PMRORGName)
			cmd.Parameters.AddWithValue("@PERSHRORG", m_PERSHRORG)
			cmd.Parameters.AddWithValue("@PMRCO", m_PMRCO)
			cmd.Parameters.AddWithValue("@PMRCOName", m_PMRCOName)
			cmd.Parameters.AddWithValue("@PERSHRCO", m_PERSHRCO)
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
			Dim cmd As New SqlCommand("uspCustomerItemSharing", SPMSOPCI.ConnectionModule.SPMSConn2)
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

	Public Function DataProcessSC02() As Boolean
		Try
			SPMSOPCI.ConnectionModule.Connect()
			Dim cmd As New SqlCommand("USPREBUILD", SPMSOPCI.ConnectionModule.SPMSConn2)
			cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.AddWithValue("@ConfigtypeCode", m_ConfigtypeCode)
			cmd.Parameters.AddWithValue("@CUTYEAR", m_Year)
			cmd.Parameters.AddWithValue("@CUTMO", m_Month)
			cmd.Parameters.AddWithValue("@COMID", m_ChannelCode)
			cmd.ExecuteNonQuery()
			SPMSOPCI.ConnectionModule.Disconnect()
			Return True
		Catch ex As System.Exception
			Throw
		End Try
	End Function
	Public Function DataProcessSC0File() As Boolean
		Try
			SPMSOPCI.ConnectionModule.Connect()
			Dim cmd As New SqlCommand("uspInsertIntoSC02FIle", SPMSOPCI.ConnectionModule.SPMSConn2)
			cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.AddWithValue("@ConfigtypeCode", m_ConfigtypeCode)
			cmd.Parameters.AddWithValue("@Cutyear", m_Year)
			cmd.Parameters.AddWithValue("@Cutmo", m_Month)
			cmd.Parameters.AddWithValue("@CompanyCode", m_ChannelCode)
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
			cmd.Parameters.AddWithValue("@ItemCode", m_ItemCode)
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
	Public Shared Function Filter(ByVal Condition As String) As CustomerItemSharingCollection
		Return BaseFilter(GetRecords("SELECT * FROM [CustomerItemSharing]  WHERE IsActive = 1 AND " & IIf(Condition <> "", Condition, "")))
	End Function
	Public Overloads Shared Function Load() As CustomerItemSharingCollection
		Return Filter("")
	End Function
	Public Overloads Shared Function Load(ByVal ID As Integer) As CustomerItemSharing
		Return Filter("ID = " & ID)(0)
	End Function
	Public Shared Function LoadByCode(ByVal TRSCODE As String) As CustomerItemSharing
		Return Filter("TRSCODE = '" & RefineSQL(TRSCODE) & "'")(0)
	End Function
	Public Shared Function GetCustomerItemSharingSql() As String
		Return "Select Distinct  A.TRSCODE,A.ChannelCode [Channel Code],A.CustomerCode [Customer Code],B.CDANAME [Customer Name],A.ShiptoCode [Shipto Code],B.CDACADD1 +' '+B.CDACADD2 AS [Address]  from CustomerItemSharing A Inner Join Customershipto B ON A.CustomerCode = B.CUSTOMERCD AND A.ShiptoCode = B.CDACD AND A.ChannelCode = B.COMID  Where A.IsActive = 1 "
	End Function
	Public Shared Function GetCustomerItemSharingPMRSHSql(ByVal TRSCODE As String) As String
		Return "Select PMRCO,PMRCODescription,PERSHRCO From CustomerItemSharing where TRSCODE = '" & TRSCODE & "' Order by ID"
	End Function
	Public Shared Function GetCustomerItemSharingPMRORGSql(ByVal TRSCODE As String) As String
		Return "Select Distinct PMRORG,PMRORGDescrition,PERSHRORG From CustomerItemSharing where TRSCODE = '" & TRSCODE & "'"
	End Function
	Public Shared Function GetResetRecordSql(ByVal TRSCODE As String) As String
		ExecuteCommand("Delete From CustomerItemSharing where TRSCODE = '" & TRSCODE & "'")
	End Function
	Public Shared Function GetResetCopyFromSql(ByVal ConfigtypeCode As String, ByVal ChannelCode As String, ByVal Year As String, ByVal Month As String) As String
		ExecuteCommand("Delete  from CustomerItemSharingUploading Where ConfigtypeCode = '" & ConfigtypeCode & "' And Year = '" & Year & "' And Month = '" & Month & "' And ChannelCode  = '" & ChannelCode & "'")
	End Function
	Public Shared Function CheckofCopyFromExist(ByVal Month As String, ByVal Year As String, ByVal ConfigCode As String, ByVal ItemCode As String) As Boolean
		Return ExecuteCommand("SELECT 'A' FROM CustomerItemSharing Where Month = '" & Month & "' And Year = '" & Year & "' And ConfigtypeCode = '" & ConfigCode & "'  And ITEMCODE = " & ItemCode) = "A"
	End Function

	Public Shared Function GetCustomerItemSharingSQL(ByVal ConfigtypeCode As String, ByVal ItemCode As String, ByVal Year As String, ByVal Month As String) As String
		Return "Select Distinct TRSCODE from CustomerItemSharing Where ConfigtypeCode = 'Y2024' And Year = '2024' And Month = '08' And ItemCode  = 'P009' "
	End Function

End Class
Public Class CustomerItemSharingCollection
	Inherits List(Of CustomerItemSharing)
End Class
