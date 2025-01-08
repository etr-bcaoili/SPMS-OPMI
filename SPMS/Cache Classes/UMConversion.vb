Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class UMConversion
    Private m_UMConversionID As Integer = -1

    Private m_Code As String = String.Empty

    Private m_Description As String = String.Empty

    Private m_UnitFromCode As String = String.Empty

    Private m_UnitTo As String = String.Empty

    Private m_ConversionQty As String = String.Empty

    Private m_MathOperation As String = String.Empty

    Private m_ItemCode As String = String.Empty

    Private m_CreateDate As Date = "1/1/1900"

    Private m_CreatedBy As String = String.Empty

    Private m_LastModifiedDate As Date = "1/1/1900"

    Private m_LastModifiedBy As String = String.Empty

    Private m_IsDeleted As Boolean = False

    Private m_IsActive As Boolean = True

    Public ReadOnly Property UMConversionID As Integer
        Get
            Return m_UMConversionID
        End Get
    End Property
    Public Property Code As String
        Get
            Return m_Code
        End Get
        Set(value As String)
            m_Code = value
        End Set
    End Property
    Public Property DescriptionName As String
        Get
            Return m_Description
        End Get
        Set(value As String)
            m_Description = value
        End Set
    End Property
    Public Property UnitFromCode As String
        Get
            Return m_UnitFromCode
        End Get
        Set(value As String)
            m_UnitFromCode = value
        End Set
    End Property
    Public Property ConversionQty As String
        Get
            Return m_ConversionQty
        End Get
        Set(value As String)
            m_ConversionQty = value
        End Set
    End Property
    Public Property UnitTo As String
        Get
            Return m_UnitTo
        End Get
        Set(value As String)
            m_UnitTo = value
        End Set
    End Property
    Public Property MathOperation As String
        Get
            Return m_MathOperation
        End Get
        Set(value As String)
            m_MathOperation = value
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
    Public Property CreateDate As Date
        Get
            Return m_CreateDate
        End Get
        Set(value As Date)
            m_CreateDate = value
        End Set
    End Property
    Public Property Createby As String
        Get
            Return m_CreatedBy
        End Get
        Set(value As String)
            m_CreatedBy = value
        End Set
    End Property
    Public Property LastModifielDate As Date
        Get
            Return m_LastModifiedDate
        End Get
        Set(value As Date)
            m_LastModifiedDate = value
        End Set
    End Property
    Public Property LastModifielby As String
        Get
            Return m_LastModifiedBy
        End Get
        Set(value As String)
            m_LastModifiedBy = value
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
    Public Property IsActive As Boolean
        Get
            Return m_IsActive
        End Get
        Set(value As Boolean)
            m_IsActive = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As UMConversionCollection
        Dim col As New UMConversionCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim _UMConversion As New UMConversion
            Dim row As DataRow = table.Rows(j)
            _UMConversion.m_UMConversionID = row("ConversionID")
            _UMConversion.m_Code = row("Code")
            _UMConversion.m_Description = row("Description")
            _UMConversion.m_UnitFromCode = row("UnitFromCode")
            _UMConversion.m_UnitTo = row("UnitToCode")
            _UMConversion.m_ConversionQty = row("ConversionQuantity")
            _UMConversion.m_MathOperation = row("MathOperation")
            _UMConversion.m_ItemCode = row("ItemCode")
            _UMConversion.m_CreateDate = row("CreateDate")
            _UMConversion.m_CreatedBy = row("CreateBy")
            _UMConversion.m_LastModifiedDate = row("LastModifiedDate")
            _UMConversion.m_LastModifiedBy = row("LastModifiedBy")
            _UMConversion.m_IsDeleted = row("IsDeleted")
            _UMConversion.m_IsActive = row("IsActive")
            col.Add(_UMConversion)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspUMConversion", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "Save")
            cmd.Parameters.AddWithValue("@ConversionID", m_UMConversionID)
            cmd.Parameters.AddWithValue("@Code", m_Code)
            cmd.Parameters.AddWithValue("@Description", m_Description)
            cmd.Parameters.AddWithValue("@ConversionQuantity", m_ConversionQty)
            cmd.Parameters.AddWithValue("@UnitFromCode", m_UnitFromCode)
            cmd.Parameters.AddWithValue("@UnitToCode", m_UnitTo)
            cmd.Parameters.AddWithValue("@MathOperation", m_MathOperation)
            cmd.Parameters.AddWithValue("@ItemCode", m_ItemCode)
            cmd.Parameters.AddWithValue("@Createby", m_CreatedBy)
            cmd.Parameters.AddWithValue("@IsDeleted", m_IsDeleted)
            cmd.Parameters.AddWithValue("@IsActive", m_IsActive)
            cmd.Parameters.AddWithValue("@LastModifiedBy", m_LastModifiedBy)
            m_UMConversionID = cmd.ExecuteScalar
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
            Dim cmd As New SqlCommand("uspUMConversion", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "Delete")
            cmd.Parameters.AddWithValue("@UMConversionID", m_UMConversionID)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As UMConversionCollection
        Return BaseFilter(GetRecords("Select * From UMConversion Where IsDeleted = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As UMConversionCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal UMConversionID As Integer) As UMConversion
        Return Filter("ConversionID = " & UMConversionID)(0)
    End Function

    Public Overloads Shared Function LoadByCode(ByVal Code As String) As UMConversion
        Return Filter("Code = '" & RefineSQL(Code) & "'")(0)
    End Function
    Public Shared Function GetUMConversionSql(Optional ByVal Code As String = "") As String
        Return "Select ConversionID,Code [Code],Description [Description Name] From UMConversion Where IsDeleted = 0  "
    End Function
    Public Shared Function CheckUMConversion(ByVal Code As String, ByVal UMConversionID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM UMConversion  WHERE  IsDeleted = 0 AND Code = '" & Code & "' AND ConversionID <> " & UMConversionID) = "A"
    End Function
End Class
Public Class UMConversionCollection
    Inherits List(Of UMConversion)
End Class