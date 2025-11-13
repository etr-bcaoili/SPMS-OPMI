Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class ProductManagerItem
	Private m_ID As Integer = -1
	Private m_ItemCode As String = String.Empty
	Private m_ItemName As String = String.Empty
	Private m_ProductGroupCode As String = String.Empty
	Private m_ConfigtypeCode As String = String.Empty
	Private m_Year As String = String.Empty
	Private m_Month As String = String.Empty
	Private m_Quantity As Decimal = 0
	Private m_Amount As Decimal = 0
	Private m_Createby As String = String.Empty

	Public ReadOnly Property ID As Integer
		Get
			Return m_ID
		End Get
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
	Public Property ProductGroupCode As String
		Get
			Return m_ProductGroupCode
		End Get
		Set(value As String)
			m_ProductGroupCode = value
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
	Public Property Quantity As Decimal
		Get
			Return m_Quantity
		End Get
		Set(value As Decimal)
			m_Quantity = value
		End Set
	End Property
	Public Property Amount As String
		Get
			Return m_Amount
		End Get
		Set(value As String)
			m_Amount = value
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
	Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As ProductManagerItemCollection
		Dim col As New ProductManagerItemCollection
		For j As Integer = 0 To Table.Rows.Count - 1
			Dim m_ProductManagerItem As New ProductManagerItem
			Dim row As DataRow = Table.Rows(j)
			m_ProductManagerItem.m_ItemCode = row("ItemCode")
			m_ProductManagerItem.m_ItemName = row("ItemName")
			m_ProductManagerItem.m_ProductGroupCode = row("ItemDivisionCode")
			m_ProductManagerItem.m_ConfigtypeCode = row("ConfigtypeCode")
			m_ProductManagerItem.m_Year = row("Year")
			m_ProductManagerItem.m_Month = row("Month")
			m_ProductManagerItem.m_Quantity = row("Quantity")
			m_ProductManagerItem.m_Amount = row("Amount")
			m_ProductManagerItem.m_Createby = row("Createby")
			col.Add(m_ProductManagerItem)
		Next
		Return col
	End Function
	Public Function Save() As Boolean
		If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
		Try
			Dim cmd As New SqlCommand("uspProductManagetTarget", SPMSOPCI.ConnectionModule.SPMSConn2)
			cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.AddWithValue("@Action", "SAVE")
			cmd.Parameters.AddWithValue("@ID", m_ID)
			cmd.Parameters.AddWithValue("@ItemCode", m_ItemCode)
			cmd.Parameters.AddWithValue("@ItemName", m_ItemName)
			cmd.Parameters.AddWithValue("@ItemDivisionCode", m_ProductGroupCode)
			cmd.Parameters.AddWithValue("@ConfigtypeCode ", m_ConfigtypeCode)
			cmd.Parameters.AddWithValue("@Year", m_Year)
			cmd.Parameters.AddWithValue("@Month", m_Month)
			cmd.Parameters.AddWithValue("@Quantity", m_Quantity)
			cmd.Parameters.AddWithValue("@Amount", m_Amount)
			cmd.Parameters.AddWithValue("@Createby", m_Createby)
			m_ID = cmd.ExecuteScalar
			SPMSOPCI.ConnectionModule.Disconnect()
			Return True
		Catch ex As Exception
			SPMSOPCI.ConnectionModule.Disconnect()
		End Try
	End Function
	Public Shared Function DeleteExistList(ByVal Year As String, ByVal ConfigCode As String) As Boolean
		Return ExecuteCommand("DELETE FROM ProductManagetTarget Where Year = '" & Year & "' AND ConfigtypeCode = '" & ConfigCode & "'")
	End Function
End Class
Public Class ProductManagerItemCollection
	Inherits List(Of ProductManagerItem)
End Class
