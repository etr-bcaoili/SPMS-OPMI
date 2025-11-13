Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class Company
	Private m_ID As Integer = -1
	Private m_CompanyCode As String = String.Empty
	Private m_CompanyName As String = String.Empty
	Private m_CompanyAddress As String = String.Empty
	Private m_ContactNumber As String = String.Empty
	Private m_CompanyEmail As String = String.Empty
	Private m_CompanyTin As String = String.Empty

	Public ReadOnly Property ID
		Get
			Return m_ID
		End Get
	End Property
	Public Property CompanyCode As String
		Get
			Return m_CompanyCode
		End Get
		Set(value As String)
			m_CompanyCode = value
		End Set
	End Property
	Public Property CompanyName As String
		Get
			Return m_CompanyName
		End Get
		Set(value As String)
			m_CompanyName = value
		End Set
	End Property
	Public Property CompanyAddress As String
		Get
			Return m_CompanyAddress
		End Get
		Set(value As String)
			m_CompanyAddress = value
		End Set
	End Property
	Public Property CompanyNumber As String
		Get
			Return m_ContactNumber
		End Get
		Set(value As String)
			m_ContactNumber = value
		End Set
	End Property
	Public Property CompanyEmail As String
		Get
			Return m_CompanyEmail
		End Get
		Set(value As String)
			m_CompanyEmail = value
		End Set
	End Property
	Public Property CompanyTin As String
		Get
			Return m_CompanyTin
		End Get
		Set(value As String)
			m_CompanyTin = value
		End Set
	End Property
	Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As CompanyCollection
		Dim col As New CompanyCollection
		For j As Integer = 0 To Table.Rows.Count - 1
			Dim m_Company As New Company
			Dim row As DataRow = Table.Rows(j)
			m_Company.m_CompanyCode = row("Year")
			col.Add(m_Company)
		Next
		Return col
	End Function
	Public Shared Function GetCompanySql() As String
		Return "Select COMID from Company"
	End Function

End Class
Public Class CompanyCollection
	Inherits List(Of Company)
End Class