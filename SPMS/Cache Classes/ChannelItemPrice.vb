Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class ChannelItemPrice
	Private _ID As Integer = -1
	Private _ChannelCode As String = String.Empty
	Private _ItemMotherCode As String = String.Empty
	Private _ItemCode As String = String.Empty
	Private _Price As Decimal = 0
	Private _StartDate As Date = "1/1/1990"
	Private _EndDate As Date = "1/1/1990"
	Private _IsActive As Boolean = True
	Private _Status As Integer = 1
	Private _ReferenceItemID As Integer = -1
	Private _ChannelItemStatusID As Integer = -1

	Public ReadOnly Property Id As Integer
		Get
			Return _ID
		End Get
	End Property
	Public Property ChannelCode As String
		Get
			Return _ChannelCode
		End Get
		Set(value As String)
			_ChannelCode = value
		End Set
	End Property
	Public Property ItemMotherCode As String
		Get
			Return _ItemMotherCode
		End Get
		Set(value As String)
			_ItemMotherCode = value
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
	Public Property Price As Decimal
		Get
			Return _Price
		End Get
		Set(value As Decimal)
			_Price = value
		End Set
	End Property
	Public Property StartDate As Date
		Get
			Return _StartDate
		End Get
		Set(value As Date)
			_StartDate = value
		End Set
	End Property
	Public Property EndDate As Date
		Get
			Return _EndDate
		End Get
		Set(value As Date)
			_EndDate = value
		End Set
	End Property
	Public Property IsActive As Boolean
		Get
			Return _IsActive
		End Get
		Set(value As Boolean)
			_IsActive = value
		End Set
	End Property
	Public Property Status As Integer
		Get
			Return _Status
		End Get
		Set(value As Integer)
			_Status = value
		End Set
	End Property

	Public Property ChannelItemStatusID As Integer
		Get
			Return _ChannelItemStatusID
		End Get
		Set(value As Integer)
			_ChannelItemStatusID = value
		End Set
	End Property
	Public Property ReferenceItemID As Integer
		Get
			Return _ReferenceItemID
		End Get
		Set(value As Integer)
			_ReferenceItemID = value
		End Set
	End Property
	Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As ChannelItemPriceCollection
		Dim col As New ChannelItemPriceCollection
		For j As Integer = 0 To Table.Rows.Count - 1
			Dim _ChannelItemPrice As New ChannelItemPrice
			Dim row As DataRow = Table.Rows(j)
			_ChannelItemPrice._ID = row("ID")
			_ChannelItemPrice._ChannelCode = row("ChannelCode")
			_ChannelItemPrice._ItemMotherCode = row("ItemMotherCode")
			_ChannelItemPrice._ItemCode = row("ItemCode")
			_ChannelItemPrice._Price = row("Price")
			_ChannelItemPrice._StartDate = row("StartDate")
			_ChannelItemPrice._EndDate = row("EndDate")
			_ChannelItemPrice._IsActive = row("IsActive")
			_ChannelItemPrice._Status = row("Status")
			_ChannelItemPrice._ChannelItemStatusID = row("ChannelItemStatusID")
			col.Add(_ChannelItemPrice)
		Next
		Return col
	End Function
	Public Function Save() As Boolean
		If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
		Try
			Dim cmd As New SqlCommand("uspChannelItemPrice", SPMSOPCI.ConnectionModule.SPMSConn2)
			cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.AddWithValue("@Action", "Save")
			cmd.Parameters.AddWithValue("@ID", _ID)
			cmd.Parameters.AddWithValue("@ChannelCode", _ChannelCode)
			cmd.Parameters.AddWithValue("@ItemMotherCode", _ItemMotherCode)
			cmd.Parameters.AddWithValue("@ItemCode", _ItemCode)
			cmd.Parameters.AddWithValue("@Price", _Price)
			cmd.Parameters.AddWithValue("@StartDate", _StartDate)
			cmd.Parameters.AddWithValue("@EndDate", _EndDate)
			cmd.Parameters.AddWithValue("@Status", _Status)
			cmd.Parameters.AddWithValue("@IsActive", True)
			cmd.Parameters.AddWithValue("@ReferenceItemID", _ReferenceItemID)
			cmd.Parameters.AddWithValue("@ChannelItemStatusID", _ChannelItemStatusID)
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
			Dim cmd As New SqlCommand("uspChannelItemPrice", SPMSOPCI.ConnectionModule.SPMSConn2)
			cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.AddWithValue("@Action", "Delete")
			cmd.Parameters.AddWithValue("@ID", Id)
			cmd.ExecuteNonQuery()
			SPMSOPCI.ConnectionModule.Disconnect()
			Return True
		Catch ex As Exception
			Throw
		End Try
	End Function
	Public Shared Function Filter(ByVal Condition As String) As ChannelItemPriceCollection
		Return BaseFilter(GetRecords("Select * From [ChannelItemPrice] Where  " & IIf(Condition <> "", Condition, "")))
	End Function
	Public Overloads Shared Function Load() As ChannelItemPriceCollection
		Return Filter("")
	End Function
	Public Overloads Shared Function Load(ByVal ID As Integer) As ChannelItemPrice
		Return Filter("ID =" & ID)(0)
	End Function
	Public Shared Function GetChannelItemPriceViewSql(Optional ByVal ChannelCode As String = "") As String
		Return "Select Distinct ChannelCode,ChannelCode [Channel Code],StartDate,EndDate From [ChannelItemPrice] Where IsActive = 1 Order by ChannelCode,StartDate"
	End Function
	Public Shared Function GetSpecificChannelItemPriceSql(ByVal ChannelCode As String, ByVal EndDate As String) As String
		Return "Select Distinct A.ChannelCode,D.DISTNAME,A.ItemMotherCode,I.ITEMMDES,A.ItemCode,A.Price,A.StartDate,A.EndDate,A.IsActive  From [ChannelItemPrice] A Inner Join Item I ON A.ItemMotherCode = I.Itemthr Inner Join Distributor D ON A.ChannelCode = D.DISTCOMID Where [Status] = 0 And ChannelCode = '" & ChannelCode & "' and Year(EndDate) = '" & EndDate & "'"
	End Function
	Public Shared Function GetCloseSpecificChannelItemPriceSql(ByVal ChannelCode As String, ByVal EndDate As String) As String
		Return "Select Distinct A.ChannelCode,D.DISTNAME,A.ItemMotherCode,I.ITEMMDES,A.ItemCode,A.Price,A.StartDate,A.EndDate,A.IsActive  From [ChannelItemPrice] A Inner Join Item I ON A.ItemMotherCode = I.Itemthr Inner Join Distributor D ON A.ChannelCode = D.DISTCOMID Where [Status] = 1 And ChannelCode = '" & ChannelCode & "' and Year(EndDate) = '" & EndDate & "'"
	End Function

	Public Shared Function GetItem() As String
		Return "Select ID,Itemcd [Item Code],itemthr [Parent Item Code],Itemmdes [Parent Item Description],Itemdivcd [Product Group] From Item Where IsActive = 1 "
	End Function
	Public Shared Function GetSelectItem(ByVal ItemID As Integer) As String
		Return "Select ID,ITEMCD,IMDBRN2,itemthr,ITEMMDES,ITEMDIVCD From Item Where IsActive = 1 AND ID = '" & ItemID & "'"
	End Function

	Public Shared Function GetViewChannelItem() As String
		Return "Select A.ItemMotherCode,B.ITEMMDES,A.ItemCode,B.IMDBRN2,A.Price,A.StartDate,A.EndDate From ChannelItemPrice A Inner Join Item B ON A.ItemCode = B.ITEMCD  And A.ItemMotherCode = B.itemthr   Where A.IsActive = 1 and A.[Status] = 0 And A.ChannelItemStatusID = 1"
	End Function
	Public Shared Function GetValidateChannelItemPrice(ByVal ChannelCode As String, ByVal ItemCode As String, ByVal ParentItemCode As String) As Boolean
		Dim result As Object = ExecuteCommand("Select 'A' from ChannelItemPrice Where ChannelCode = '" & ChannelCode & "' And ItemCode = '" & ItemCode & "' And ItemMotherCode = '" & ParentItemCode & "'")

		If result IsNot Nothing AndAlso result.ToString() = "A" Then
			Return True
		End If

		Return False
	End Function
End Class


Public Class ChannelItemPriceCollection
	Inherits List(Of ChannelItemPrice)
End Class

