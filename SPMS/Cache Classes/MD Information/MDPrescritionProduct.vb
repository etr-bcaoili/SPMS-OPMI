Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class MDPrescritionProduct

    Private m_ID As Integer = -1

    Private m_MDID As Integer = -1

    Private m_ItemCode As String = String.Empty

    Private m_ItemDescription As String = String.Empty

    Private m_ProductGroup As String = String.Empty

    Private m_IsDeleted As Boolean = False

    Private m_CreatedBy As String = String.Empty

    Private m_LastModifiedBy As String = String.Empty


    Public ReadOnly Property ID As Integer
        Get
            Return m_ID
        End Get
    End Property
    Public Property MDID As String
        Get
            Return m_MDID
        End Get
        Set(value As String)
            m_MDID = value
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
    Public Property ItemDescription As String
        Get
            Return m_ItemDescription
        End Get
        Set(value As String)
            m_ItemDescription = value
        End Set
    End Property
    Public Property ProductGroup As String
        Get
            Return m_ProductGroup
        End Get
        Set(value As String)
            m_ProductGroup = value
        End Set
    End Property
    Public Property IsDeleted As Boolean
        Get
            Return m_IsDeleted
        End Get
        Set(value As Boolean)
            m_IsDeleted = value
        End Set
    End Property

    Public Property CreatedBy As String
        Get
            Return m_CreatedBy
        End Get
        Set(value As String)
            m_CreatedBy = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As MDPrescritionProductCollection
        Dim col As New MDPrescritionProductCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim m_MDPrescritionProduct As New MDPrescritionProduct
            Dim row As DataRow = Table.Rows(j)
            m_MDPrescritionProduct.m_ID = row("ID")
            m_MDPrescritionProduct.m_MDID = row("MDID")
            m_MDPrescritionProduct.m_ItemCode = row("ItemCode")
            m_MDPrescritionProduct.m_ItemDescription = row("ItemDescription")
            m_MDPrescritionProduct.m_ProductGroup = row("ProductGroup")
            m_MDPrescritionProduct.m_IsDeleted = row("IsDeleted")
            m_MDPrescritionProduct.m_CreatedBy = row("CreatedBy")
            m_MDPrescritionProduct.m_LastModifiedBy = row("LastModifiedBy")
            col.Add(m_MDPrescritionProduct)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspMDPrescritionProduct", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.Parameters.AddWithValue("@MDID", m_MDID)
            cmd.Parameters.AddWithValue("@ITEMCODE", m_ItemCode)
            cmd.Parameters.AddWithValue("@ITEMDESCRITPION", m_ItemDescription)
            cmd.Parameters.AddWithValue("@PRODUCTGROUP", m_ProductGroup)
            cmd.Parameters.AddWithValue("@IsDeleted", m_IsDeleted)
            cmd.Parameters.AddWithValue("@CreatedBy", m_CreatedBy)
            cmd.Parameters.AddWithValue("@LastModifiedBy", m_LastModifiedBy)
            m_MDID = cmd.ExecuteScalar
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            SPMSOPCI.ConnectionModule.Disconnect()
        End Try
    End Function
    Public Function Delete() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspMDPrescritionProduct", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "DELETE")
            cmd.Parameters.AddWithValue("@MDID", m_MDID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As MDPrescritionProductCollection
        Return BaseFilter(GetRecords("SELECT * FROM MDPrescritionProduct  WHERE IsDeleted = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load(ByVal MDID As Integer) As MDPrescritionProduct
        Return Filter("MDID = " & MDID)(0)
    End Function
    Public Shared Function LoadByCode(ByVal SpecialtyCode As String) As MDPrescritionProduct
        Return Filter("SpecialtyCode = '" & RefineSQL(SpecialtyCode) & "'")(0)
    End Function

    Public Shared Function GetMDPrescriptionSql() As String
        Return "SELECT A.MDID,A.MDCode AS [Doctor Code],RTRIM(LTRIM(A.LastName + ' ' + A.FirstName + CASE WHEN A.MiddleName IS NOT NULL AND A.MiddleName <> '' THEN ' ' + A.MiddleName ELSE '' END)) AS [Doctor Name],B.SpecialtyName [Specilization] FROM [dbo].[MDPrescrition] A LEFT JOIN [Specialization] B ON B.SpecialtyCode = A.SPCode WHERE A.IsDeleted = 1"
    End Function
    Public Shared Function GetMDPrescriptionProductSql(ByVal MDID As Integer) As String
        Return "Select ItemCode,ItemDescription,ProductGroup From [MDPrescritionProduct] Where MDID = '" & MDID & "'"
    End Function
    Public Shared Function CheckItemCodeIsAlreadyExist(ByVal ItemCode As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM Item Where ITEMDEL = 0 AND ITEMCD = '" & RefineSQL(ItemCode) & "' AND ID <> " & ID) = "A"
    End Function
End Class
Public Class MDPrescritionProductCollection
    Inherits List(Of MDPrescritionProduct)
End Class