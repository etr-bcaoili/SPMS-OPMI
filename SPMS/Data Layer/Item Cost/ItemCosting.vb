
Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports SPMSOPCI.ConnectionModule

Public Class ItemCosting
    
    Public Const ItemCostingTableConstant As String = "ItemCosting"
    
    Private m_ItemCostingID As Integer = -1
    
    Private m_CompanyCode As String = String.Empty
    
    Private m_Month As String = String.Empty
    
    Private m_Year As String = String.Empty
    
    Private m_Remarks As String = String.Empty
    
    Private m_CreatedBy As Integer = 0
    
    Private m_CreateDate As Date = "1/1/1900"
    
    Private m_LastModifiedBy As Integer = 0
    
    Private m_LastModifiedDate As Date = "1/1/1900"
    
    Private m_ItemCostingDetails As New ItemCostingDetailsCollection
    
    Public ReadOnly Property ItemCostingID() As Integer
        Get
            Return m_ItemCostingID
        End Get
    End Property
    
    Public Property CompanyCode() As String
        Get
            Return m_CompanyCode
        End Get
        Set
            m_CompanyCode = value
        End Set
    End Property
    
    Public Property Month() As String
        Get
            Return m_Month
        End Get
        Set
            m_Month = value
        End Set
    End Property
    
    Public Property Year() As String
        Get
            Return m_Year
        End Get
        Set
            m_Year = value
        End Set
    End Property
    
    Public Property Remarks() As String
        Get
            Return m_Remarks
        End Get
        Set
            m_Remarks = value
        End Set
    End Property
    
    Public Property CreatedBy() As Integer
        Get
            Return m_CreatedBy
        End Get
        Set
            m_CreatedBy = value
        End Set
    End Property
    
    Public ReadOnly Property CreateDate() As Date
        Get
            Return m_CreateDate
        End Get
    End Property
    
    Public Property LastModifiedBy() As Integer
        Get
            Return m_LastModifiedBy
        End Get
        Set
            m_LastModifiedBy = value
        End Set
    End Property
    
    Public ReadOnly Property LastModifiedDate() As Date
        Get
            Return m_LastModifiedDate
        End Get
    End Property
    
    Public ReadOnly Property ItemCostingDetailsCollection() As ItemCostingDetailsCollection
        Get
            Return m_ItemCostingDetails
        End Get
    End Property
    
    Public Function Save() As Boolean
        Connect()
        Try 

            Dim cmd As New SqlCommand("uspItemCosting", SPMSConn2)
				cmd.CommandType = CommandType.StoredProcedure
				cmd.Parameters.AddWithValue("@Action", "Save")
				cmd.Parameters.AddWithValue("@ItemCostingID", m_ItemCostingID)
				cmd.Parameters.AddWithValue("@CompanyCode", m_CompanyCode)
				cmd.Parameters.AddWithValue("@Month", m_Month)
				cmd.Parameters.AddWithValue("@Year", m_Year)
				cmd.Parameters.AddWithValue("@Remarks", m_Remarks)
				cmd.Parameters.AddWithValue("@CreatedBy", m_CreatedBy)
				cmd.Parameters.AddWithValue("@CreateDate", m_CreateDate)
				cmd.Parameters.AddWithValue("@LastModifiedBy", m_LastModifiedBy)
				cmd.Parameters.AddWithValue("@LastModifiedDate", m_LastModifiedDate)
				m_ItemCostingID = cmd.ExecuteScalar()
            Disconnect()
				For j As Integer = 0 To m_ItemCostingDetails.Count - 1
					m_ItemCostingDetails(j).ItemCostingID = m_ItemCostingID
					If Not m_ItemCostingDetails(j).Save Then
						Throw New Exception("Error saving ItemCostingDetails Index " & j)
					End if
				Next
				Return True
        Catch ex As System.Exception
            Disconnect()
            Throw
        End Try
    End Function
    
    Public Function Delete() As Boolean
        Connect()
        Try 
				For j As Integer = 0 To m_ItemCostingDetails.Count - 1
					If Not m_ItemCostingDetails(j).Delete Then
						Throw New Exception("Error deleting ItemCostingDetails Index " & j)
					End If
				Next

            Dim cmd As New SqlCommand("uspItemCosting", SPMSConn2)
				cmd.CommandType = CommandType.StoredProcedure
				cmd.Parameters.AddWithValue("@Action", "Delete")
				cmd.Parameters.AddWithValue("@ItemCostingID", m_ItemCostingID)
				cmd.ExecuteNonQuery()
            Disconnect()
				Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As ItemCostingCollection
        Dim col as New ItemCostingCollection
        For j As Integer = 0 To table.Rows.Count - 1
        	Dim m_ItemCosting as New ItemCosting
        	Dim row as DataRow = table.Rows(j)
				m_ItemCosting.m_ItemCostingID = row("ItemCostingID")
				m_ItemCosting.m_CompanyCode = row("CompanyCode")
				m_ItemCosting.m_Month = row("Month")
				m_ItemCosting.m_Year = row("Year")
				m_ItemCosting.m_Remarks = row("Remarks")
				m_ItemCosting.m_CreatedBy = row("CreatedBy")
				m_ItemCosting.m_CreateDate = row("CreateDate")
				m_ItemCosting.m_LastModifiedBy = row("LastModifiedBy")
				m_ItemCosting.m_LastModifiedDate = row("LastModifiedDate")
            m_ItemCosting.m_ItemCostingDetails = ItemCostingDetails.LoadByItemCostingID(m_ItemCosting.m_ItemCostingID)
				col.Add(m_ItemCosting)
        Next
        Return col
    End Function
    
    Public Shared Function Filter(ByVal Condition As String) As ItemCostingCollection
        Return BaseFilter(GetRecords("SELECT * FROM ItemCosting " & IIf(Condition <> "", " WHERE " & Condition, "")))
    End Function
    
    Public Overloads Shared Function Load() As ItemCostingCollection
			Return Filter("")
    End Function
    
    Public Overloads Shared Function Load(ByVal ItemCostingID As Integer) As ItemCosting
			Return Filter("ItemCostingID = " & ItemCostingID)(0)
    End Function
    
 
End Class

Public Class ItemCostingCollection

    Inherits List(Of ItemCosting)
End Class
