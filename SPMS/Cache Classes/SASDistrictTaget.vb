Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class SASDistrictTaget
	Private m_ID As Integer = -1
	Private m_ConfigtypeCode As String = String.Empty
	Private m_Year As String = String.Empty
	Private m_Month As String = String.Empty
	Private m_DistrictCode As String = String.Empty
	Private m_TargetValue As Decimal = 0
	Private m_Createby As String = String.Empty

	Public ReadOnly Property ID As Integer
		Get
			Return m_ID
		End Get
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
	Public Property DistrictCode As String
		Get
			Return m_DistrictCode
		End Get
		Set(value As String)
			m_DistrictCode = value
		End Set
	End Property
	Public Property TagetValue As Decimal
		Get
			Return m_TargetValue
		End Get
		Set(value As Decimal)
			m_TargetValue = value
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

	Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As SASDistrictTagetCollection
		Dim col As New SASDistrictTagetCollection
		For j As Integer = 0 To Table.Rows.Count - 1
			Dim m_SASDistrictTaget As New SASDistrictTaget
			Dim row As DataRow = Table.Rows(j)
			m_SASDistrictTaget.m_ConfigtypeCode = row("ConfigtypeCode")
			m_SASDistrictTaget.m_Year = row("Year")
			m_SASDistrictTaget.m_Month = row("Month")
			m_SASDistrictTaget.m_DistrictCode = row("DistrictCode")
			m_SASDistrictTaget.m_TargetValue = row("TargetAmount")
			m_SASDistrictTaget.m_Createby = row("Createby")
			col.Add(m_SASDistrictTaget)
		Next
		Return col
	End Function
	Public Function Save() As Boolean
		If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
		Try
			Dim cmd As New SqlCommand("uspSASDistrictTarget", SPMSOPCI.ConnectionModule.SPMSConn2)
			cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.AddWithValue("@Action", "SAVE")
			cmd.Parameters.AddWithValue("@ID", m_ID)
			cmd.Parameters.AddWithValue("@ConfigtypeCode", m_ConfigtypeCode)
			cmd.Parameters.AddWithValue("@Year", m_Year)
			cmd.Parameters.AddWithValue("@Month", m_Month)
			cmd.Parameters.AddWithValue("@DistrictCode", m_DistrictCode)
			cmd.Parameters.AddWithValue("@TargetAmount", m_TargetValue)
			cmd.Parameters.AddWithValue("@Createby", m_Createby)
			m_ID = cmd.ExecuteScalar
			SPMSOPCI.ConnectionModule.Disconnect()
			Return True
		Catch ex As Exception
			SPMSOPCI.ConnectionModule.Disconnect()
		End Try
	End Function
	Public Shared Function DeleteExistList(ByVal Year As String, ByVal ConfigCode As String) As Boolean
		Return ExecuteCommand("DELETE FROM [SASDistrictTarget] Where Year = '" & Year & "' AND ConfigtypeCode = '" & ConfigCode & "'")
	End Function

	Public Shared Function LoadSASDistrictSQL() As String
		Return "Select Distinct A.DistrictCode,B.STDISTRCTNAME,A.TargetAmount From [SASDistrictTarget] A Inner Join STDISTRICT B On A.DistrictCode = B.DistrictGroup"
	End Function

End Class
Public Class SASDistrictTagetCollection
	Inherits List(Of SASDistrictTaget)
End Class