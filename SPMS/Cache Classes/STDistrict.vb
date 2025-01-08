Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class STDistrict
    Private m_ID As Integer = -1

    Private m_DistrictCode As String = String.Empty

    Private m_DistrictName As String = String.Empty

    Private m_RegionCode As String = String.Empty
    Public ReadOnly Property ID As Integer
        Get
            Return m_ID
        End Get
    End Property
    Public Property DistrictCode As String
        Get
            Return m_DistrictCode
        End Get
        Set(value As String)
            m_DistrictCode = value
        End Set
    End Property
    Public Property DistrictName As String
        Get
            Return m_DistrictName
        End Get
        Set(value As String)
            m_DistrictName = value
        End Set
    End Property
    Public Property RegionCode As String
        Get
            Return m_RegionCode
        End Get
        Set(value As String)
            m_RegionCode = value
        End Set
    End Property
    Public Function Save() As Boolean
        Connect()
        Try
            Dim cmd As New SqlCommand("uspStDistrictCreation", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Save")
            cmd.Parameters.AddWithValue("@StDistrictCreationID", m_ID)
            cmd.Parameters.AddWithValue("@DistCD", m_DistrictCode)
            cmd.Parameters.AddWithValue("@DistName", m_DistrictName)
            cmd.Parameters.AddWithValue("@RegionCode", m_RegionCode)
            m_ID = cmd.ExecuteScalar
            Disconnect()
            Return True
        Catch ex As System.Exception
            Disconnect()
        End Try
    End Function
    Public Function Delete() As Boolean
        Connect()
        Try
            Dim cmd As New SqlCommand("uspStDistrictCreation", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "DELETE")
            cmd.Parameters.AddWithValue("@ID", m_ID)
            cmd.ExecuteNonQuery()
            Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As STDistrictCollection
        Dim col As New STDistrictCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_District As New STDistrict
            Dim row As DataRow = table.Rows(j)
            m_District.m_ID = row("StDistrictCreationID")
            m_District.m_DistrictCode = row("DistCd")
            m_District.m_DistrictName = row("DistName")
            m_District.m_RegionCode = row("DivCd")
            col.Add(m_District)
        Next
        Return col
    End Function
    Public Shared Function Filter(ByVal Condition As String) As STDistrictCollection
        Return BaseFilter(GetRecords("Select * from StDistrictCreation  WHERE DLTFLG = 0" & IIf(Condition <> "", " AND " & Condition, "")))
    End Function
    Public Overloads Shared Function Load() As STDistrictCollection
        Return Filter("")
    End Function

    Public Overloads Shared Function Load(ByVal ID As Integer) As STDistrict
        Return Filter("StDistrictCreationID = " & ID)(0)
    End Function
    Public Shared Function LoadByCode(ByVal DistCd As String) As STDistrict
        Return Filter("DistCd = '" & HandleSingleQuoteInSql(DistCd) & "'")(0)
    End Function
    Public Shared Function CheckDistrictIsAlreadyExist(ByVal RegionCode As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM StDistrictCreation Where DLTFLG = 0 AND DistCd = '" & RefineSQL(RegionCode) & "' AND StDistrictCreationID <> " & ID) = "A"
    End Function
    Public Shared Function GetDistrictsql() As String
        Return "Select StDistrictCreationID, DistCd [District Code], DistName [District Name],DivCd [Region Code] From StDistrictCreation WHERE DLTFLG = 0 "
    End Function
    Public Shared Function GetDistrictWithRegionsql(ByVal RegionCode As String) As String
        Return "Select StDistrictCreationID, DistCd [District Code], DistName [District Name],DivCd [Region Code] From StDistrictCreation WHERE DLTFLG = 0 And DivCd = '" & RegionCode & "'"
    End Function
    Public Shared Function GetRegionbyDistrictCollectionsql(ByVal DistrictCode As String, ByVal RegionCode As String) As String
        Return "Select DistCd, DistName From StDistrictCreation WHERE DLTFLG = 0 And DistCd = '" & DistrictCode & "' And DivCd = '" & RegionCode & "'"
    End Function
End Class
Public Class STDistrictCollection
    Inherits List(Of STDistrict)
End Class