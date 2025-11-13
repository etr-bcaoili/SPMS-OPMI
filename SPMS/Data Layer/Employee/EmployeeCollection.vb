Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Imports Telerik.WinControls.UI.PivotFieldList
Public Class EmployeeCollection
    Private m_EmployeeID As Integer = -1

    Private m_TerritoryCode As String = String.Empty

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
    Public Property TerritoryCode As String
        Get
            Return m_TerritoryCode
        End Get
        Set(value As String)
            m_TerritoryCode = value
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
            Dim cmd As New SqlCommand("uspEmployeeSalesmanCollection", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@EmployeeID", m_EmployeeID)
            cmd.Parameters.AddWithValue("@TerritoryCode", m_TerritoryCode)
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
        Return ExecuteCommand("DELETE FROM [EmployeeSalesmanCollection] WHERE EmployeeID = '" & EmployeeID & "'")
    End Function
    Public Shared Function SalesAccountSpecialistCollectionDelete(ByVal EmployeeID As Integer) As Boolean
        Return ExecuteCommand("DELETE FROM [SalesAccountSpecialistCollection] WHERE SalesAccountSpecialistID = '" & EmployeeID & "'")
    End Function

    Public Shared Function GetEmployeeCollection(ByVal EmployeeID As Integer)
        Return "Select TerritoryCode,ConfigtypeCode,EffectivityStartDate,EffectivityEndDate From [EmployeeSalesmanCollection] Where EmployeeID = '" & EmployeeID & "'"
    End Function
    Public Shared Function GetEmployeeCollection2(ByVal EmployeeID As Integer)
        Return "Select Distinct  A.TerritoryCode,B.STACOVNAME,A.EffectivityStartDate,A.EffectivityEndDate,A.ConfigtypeCode From [EmployeeSalesmanCollection] A Inner Join SalesMatrix B ON A.TerritoryCode = B.STSLSMNCD  Where  EmployeeID = '" & EmployeeID & "'"
    End Function
    Public Shared Function GetEmployeeCollectionPMR(ByVal PMRCode As String, ByVal EmployeeID As Integer)
        Return "Select A.TerritoryCode,B.LastName +' '+B.FirstName [EmployeeName],A.EffectivityStartDate,A.EffectivityEndDate,A.ConfigtypeCode From EmployeeSalesmanCollection A Inner Join EmployeeSalesman B ON A.EmployeeID = B.EmployeeID Where A.TerritoryCode = '" & PMRCode & "' And B.EmployeeID <> '" & EmployeeID & "' And B.Position = 'Professional Medical Representative' And B.IsDeleted = 0 "
    End Function
End Class
