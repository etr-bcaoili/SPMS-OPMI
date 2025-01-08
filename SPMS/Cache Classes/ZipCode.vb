Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class ZipCodes
    Private m_ZipID As Integer = -1
    Private m_ZipCode As String = String.Empty
    Private m_ZipAreaCode As String = String.Empty
    Private m_ZipAreaName As String = String.Empty
    Private m_RegionCode As String = String.Empty
    Private m_DistrictCode As String = String.Empty
    Private m_Createby As String = String.Empty

    Public ReadOnly Property ZIPID As Integer
        Get
            Return m_ZipID
        End Get
    End Property
    Public Property ZipCode As String
        Get
            Return m_ZipCode
        End Get
        Set(value As String)
            m_ZipCode = value
        End Set
    End Property

    Public Property ZipAreaCode As String
        Get
            Return m_ZipAreaCode
        End Get
        Set(value As String)
            m_ZipAreaCode = value
        End Set
    End Property
    Public Property ZipAreaName As String
        Get
            Return m_ZipAreaName
        End Get
        Set(value As String)
            m_ZipAreaName = value
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
    Public Property RegionCode As String
        Get
            Return m_RegionCode
        End Get
        Set(value As String)
            m_RegionCode = value
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
    Private Shared Function BaseFilter(ByVal Table As System.Data.DataTable) As ZIPCodeCollection
        Dim col As New ZIPCodeCollection
        For j As Integer = 0 To Table.Rows.Count - 1
            Dim _ZipCode As New ZipCodes
            Dim row As DataRow = Table.Rows(j)
            _ZipCode.m_ZipID = row("ZIPID")
            _ZipCode.m_ZipCode = row("ZIPCD")
            _ZipCode.m_ZipAreaName = row("AREANAME")
            _ZipCode.m_RegionCode = row("REGCD")
            _ZipCode.m_DistrictCode = row("DISTRCTCD")
            _ZipCode.m_ZipAreaCode = row("AREACD")
            col.Add(_ZipCode)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspZipCOde", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "SAVE")
            cmd.Parameters.AddWithValue("@ZIPID", m_ZipID)
            cmd.Parameters.AddWithValue("@DLTFLG", False)
            cmd.Parameters.AddWithValue("@ZIPCD", m_ZipCode)
            cmd.Parameters.AddWithValue("@AREACD", m_ZipAreaCode)
            cmd.Parameters.AddWithValue("@AREANAME", m_ZipAreaName)
            cmd.Parameters.AddWithValue("@REGCD", m_RegionCode)
            cmd.Parameters.AddWithValue("@DISTRCTCD", m_DistrictCode)
            cmd.Parameters.AddWithValue("@ISACTIVE", True)
            m_ZipID = cmd.ExecuteScalar
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
            Dim cmd As New SqlCommand("uspZipCOde", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", "DELETE")
            cmd.Parameters.AddWithValue("@REGCD", m_RegionCode)
            cmd.Parameters.AddWithValue("@DISTRCTCD", m_DistrictCode)
            cmd.Parameters.AddWithValue("@AREACD", m_ZipAreaCode)
            cmd.Parameters.AddWithValue("@ZIPCD", m_ZipCode)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As ZIPCodeCollection
        Return BaseFilter(GetRecords("Select * From ZIPCODE Where DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As ZIPCodeCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal ID As Integer) As ZipCodes
        Return Filter("ZIPID = " & ID)(0)
    End Function

    Public Overloads Shared Function LoadByCode(ByVal Code As String) As ZipCodes
        Return Filter("ZIPCD = '" & RefineSQL(Code) & "'")(0)
    End Function
    Public Shared Function GeZipCodeSql(Optional ByVal Code As String = "") As String
        Return "SELECT ZIPCD,ZIPCD [ZipCode],AREANAME [Area Name] FROM ZIPCODE Where DLTFLG = 0  "
    End Function
    Public Shared Function GeZipCodeSql1(Optional ByVal Code As String = "") As String
        Return "SELECT ZIPID,ZIPCD [ZipCode],AREANAME [Area Name],REGCD [Region Code],DISTRCTCD [District Code] FROM ZIPCODE Where DLTFLG = 0"
    End Function
    Public Shared Function GetZipCodebyRegionAndDistrictAndArea(ByVal RegionCode As String, ByVal DistrictCode As String, ByVal AreaCode As String) As String
        Return "SELECT ZIPCD,ZIPCD [ZipCode],AREANAME [Area Name] FROM ZIPCODE Where DLTFLG = 0 And REGCD = '" & RegionCode & "' AND Distrctcd = '" & DistrictCode & "' AND AREACD = '" & AreaCode & "'"
    End Function
    Public Shared Function GetZipCode(ByVal RegionCode As String, ByVal DistrictCode As String, ByVal AreaCode As String) As String
        Return "SELECT Distinct ZIPCD FROM ZIPCODE Where DLTFLG = 0 And REGCD = '" & RegionCode & "' AND Distrctcd = '" & DistrictCode & "' AND AREACD = '" & AreaCode & "'"
    End Function
    Public Shared Function CheckCustomerZipCode(ByVal CustomerZipCode As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM ZIPCODE  WHERE  DLTFLG = 0 AND ZIPCD ='" & CustomerZipCode & "'") = "A"
    End Function
    Public Shared Function CheckCustomerZipCode1(ByVal CustomerZipCode As String, ByVal ID As Integer) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM ZIPCODE  WHERE  DLTFLG = 0 AND ZIPCD ='" & CustomerZipCode & "' And ZIPID <> " & ID) = "A"
    End Function
End Class
Public Class ZIPCodeCollection
    Inherits List(Of ZipCodes)
End Class