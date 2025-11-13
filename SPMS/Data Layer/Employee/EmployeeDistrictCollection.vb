Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Imports Telerik.WinControls.UI.PivotFieldList
Public Class EmployeeDistrictCollection
    Private m_EmployeeID As Integer = -1

    Private m_DistrictCode As String = String.Empty

    Private m_ConfigtypeCode As String = String.Empty

    Private m_DateStartEffectivity As Date = "1/1/1900"

    Private m_DateEndEffectivity As Date = "1/1/1900"
    Public Property EmployeeID As Integer
        Get
            Return m_EmployeeID
        End Get
        Set(value As Integer)
            m_EmployeeID = value
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
    Public Property DateStartEffectivity As Date
        Get
            Return m_DateStartEffectivity
        End Get
        Set(value As Date)
            m_DateStartEffectivity = value
        End Set
    End Property
    Public Property DateEndEffectivity As Date
        Get
            Return m_DateEndEffectivity
        End Get
        Set(value As Date)
            m_DateEndEffectivity = value
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


    Public Function Save() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspEmployeeDistrictCollection", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@EmployeeID", m_EmployeeID)
            cmd.Parameters.AddWithValue("@DistrictCode", m_DistrictCode)
            cmd.Parameters.AddWithValue("@EffectivityStartDate", m_DateStartEffectivity)
            cmd.Parameters.AddWithValue("@EffectivityEndDate", m_DateEndEffectivity)
            cmd.Parameters.AddWithValue("@ConfigtypeCode", m_ConfigtypeCode)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Public Shared Function EmployeeCollectionDelete(ByVal EmployeeID As Integer) As Boolean
        Return ExecuteCommand("DELETE FROM [EmployeeDistrictCollection] WHERE EmployeeID = '" & EmployeeID & "'")
    End Function
    Public Shared Function GetEmployeeCollection(ByVal EmployeeID As Integer)
        Return "Select DistrictCode,ConfigtypeCode,EffectivityStartDate,EffectivityEndDate From [EmployeeDistrictCollection] Where EmployeeID = '" & EmployeeID & "'"
    End Function
    Public Shared Function GetEmployeeCollection2(ByVal EmployeeID As Integer)
        Return "Select Distinct A.DistrictCode,A.EffectivityStartDate,A.EffectivityEndDate,A.ConfigtypeCode From [EmployeeDistrictCollection] A Inner Join SalesMatrix B ON A.DistrictCode = B.STDISTRCTCD  Where  EmployeeID = '" & EmployeeID & "'"
    End Function
    Public Shared Function GetEmployeeCollectionDistrict(ByVal DistrictCode As String, ByVal EmployeeID As Integer)
        Return "Select A.DistrictCode,B.LastName +' '+B.FirstName [EmployeeName],A.EffectivityStartDate,A.EffectivityEndDate,A.ConfigtypeCode From EmployeeDistrictCollection A Inner Join EmployeeDistrictManager B ON A.EmployeeID = B.EmployeeID Where A.DistrictCode = '" & DistrictCode & "' And B.EmployeeID <> '" & EmployeeID & "' And B.IsDeleted = 0 "
    End Function
End Class
