Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient

Public Class MedicalRep

    Private m_DLTFLG As Boolean = False
    Private m_SalesAgentCode As String = String.Empty
    Private m_SalesAgentName As String = String.Empty
    Private m_CRTDATE As Date = "1/1/1990"
    Private m_CRTU As String = String.Empty
    Private m_UPDD As Date = "1/1/1990"
    Private m_UPDU As String = String.Empty
    Private m_EffectivityStartDate As Date = "1/1/1990"
    Private m_EffectivityEndDate As Date = "1/1/1990"
    Private m_IsActive As Boolean = False

    Private m_MobileNumber1 As String = String.Empty
    Private m_MobileNumber2 As String = String.Empty
    'Private m_SalesAgentCoverageCustomers As New SalesAgentCoverageCustomersCollection

    'Public ReadOnly Property SalesAgentCoverageCustomersCol() As SalesAgentCoverageCustomersCollection
    '    Get
    '        Return m_SalesAgentCoverageCustomers
    '    End Get
    'End Property

    Public Property DLTFLG() As Boolean
        Get
            Return m_DLTFLG
        End Get
        Set(ByVal value As Boolean)
            m_DLTFLG = value
        End Set
    End Property

    Public Property SalesAgentCode() As String
        Get
            Return m_SalesAgentCode
        End Get
        Set(ByVal value As String)
            m_SalesAgentCode = value
        End Set
    End Property

    Public Property SalesAgentName() As String
        Get
            Return m_SalesAgentName
        End Get
        Set(ByVal value As String)
            m_SalesAgentName = value
        End Set
    End Property

    Public Property CRTDATE() As Date
        Get
            Return m_CRTDATE
        End Get
        Set(ByVal value As Date)
            m_CRTDATE = value
        End Set
    End Property

    Public Property CRTU() As String
        Get
            Return m_CRTU
        End Get
        Set(ByVal value As String)
            m_CRTU = value
        End Set
    End Property

    Public Property UPDD() As String
        Get
            Return m_UPDD
        End Get
        Set(ByVal value As String)
            m_UPDD = value
        End Set
    End Property

    Public Property UPDU() As String
        Get
            Return m_UPDU
        End Get
        Set(ByVal value As String)
            m_UPDU = value
        End Set
    End Property

    Public Property EffectivityStartDate() As Date
        Get
            Return m_EffectivityStartDate
        End Get
        Set(ByVal value As Date)
            m_EffectivityStartDate = value
        End Set
    End Property

    Public Property EffectivityEndDate() As Date
        Get
            Return m_EffectivityEndDate
        End Get
        Set(ByVal value As Date)
            m_EffectivityEndDate = value
        End Set
    End Property

    Public Property IsActive() As Boolean
        Get
            Return m_IsActive
        End Get
        Set(ByVal value As Boolean)
            m_IsActive = value
        End Set
    End Property

    Public Property MobileNumber1() As String
        Get
            Return m_MobileNumber1
        End Get
        Set(ByVal value As String)
            m_MobileNumber1 = value
        End Set
    End Property

    Public Property MobileNumber2() As String
        Get
            Return m_MobileNumber2
        End Get
        Set(ByVal value As String)
            m_MobileNumber2 = value
        End Set
    End Property

    Private Shared Function BaseFilter(ByVal dtMedicalRep As DataTable) As MedicalRepCollection
        Dim col As New MedicalRepCollection

        For m As Integer = 0 To dtMedicalRep.Rows.Count - 1
            Dim dr As DataRow = dtMedicalRep.Rows(m)
            Dim m_Med As New MedicalRep
            m_Med.m_DLTFLG = dr("DLTFLG")
            m_Med.m_SalesAgentCode = dr("SLSMNCD")
            m_Med.m_SalesAgentName = dr("SLSMNNAME")
            m_Med.m_CRTDATE = dr("CRTDATE")
            m_Med.m_CRTU = dr("CRTU")
            m_Med.m_UPDD = dr("UPDD")
            m_Med.m_UPDU = dr("UPDU")
            m_Med.m_EffectivityStartDate = dr("EffectivityStartDate")
            m_Med.m_EffectivityEndDate = dr("EffectivityEndDate")
            m_Med.m_IsActive = dr("IsActive")
            ' m_Med.m_MobileNumber1 = dr("MobileNumber1")
            'm_Med.m_MobileNumber2 = dr("MobileNumber2")
            'm_Med.m_SalesAgentCoverageCustomers = SalesAgentCoverageCustomers.LoadBySalesAgentCode(m_Med.m_SalesAgentCode)
            col.Add(m_Med)
        Next
        Return col
    End Function

    Public Function Update() As Boolean
        If Save("UPDATE") Then
            Return True
        End If
    End Function

    Public Function Save(Optional ByVal Action As String = "ADD") As Boolean
        Try

            Connect()
            Dim cmd As New SqlCommand("uspMedicalRep", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ACTION", Action)
            cmd.Parameters.AddWithValue("@DLTFLG", 0)
            cmd.Parameters.AddWithValue("@SLSMNCD", m_SalesAgentCode)
            cmd.Parameters.AddWithValue("@SLSMNNAME", m_SalesAgentName)
            cmd.Parameters.AddWithValue("@MobileNumber1", m_MobileNumber1)
            cmd.Parameters.AddWithValue("@MobileNumber2", m_MobileNumber2)
            cmd.Parameters.AddWithValue("@IsActive", 1)

            cmd.ExecuteNonQuery()

            'For m As Integer = 0 To m_SalesAgentCoverageCustomers.Count - 1
            '    If Not SalesAgentCoverageCustomers.CheckIfCustomerAlreadyExist(m_SalesAgentCoverageCustomers(m).CustomerCode, m_SalesAgentCoverageCustomers(m).SalesAgentCode, m_SalesAgentCoverageCustomers(m).SalesAgentCoverageCustomerID) Then
            '        m_SalesAgentCoverageCustomers(m).Save()
            '    End If
            'Next
            Disconnect()
            Return True
        Catch ex As Exception
            Disconnect()
            Throw New Exception(ex.Message)
        End Try

    End Function

    Public Function Delete() As Boolean
        'Try

        '    Connect()
        '    Dim cmd As New SqlCommand("uspMedicalRep", SPMSConn2)
        '    cmd.CommandType = CommandType.StoredProcedure
        '    cmd.Parameters.AddWithValue("@ACTION", "UPDATE")
        '    cmd.Parameters.AddWithValue("@DLTFLG", 0)
        '    cmd.Parameters.AddWithValue("@SLSMNCD", m_SalesAgentCode)
        '    cmd.Parameters.AddWithValue("@SLSMNNAME", m_SalesAgentName)
        '    cmd.Parameters.AddWithValue("@MobileNumber1", m_MobileNumber1)
        '    cmd.Parameters.AddWithValue("@MobileNumber2", m_MobileNumber2)
        '    cmd.Parameters.AddWithValue("@IsActive", 1)
        '    Disconnect()
        'Catch ex As Exception
        '    Disconnect()
        'End Try
    End Function


    Private Shared Function Filter(ByVal Condition As String) As MedicalRepCollection
        Return BaseFilter(GetRecords("SELECT * FROM MedicalRep WHERE DLTFLG = 0 " & IIf(Condition <> "", " AND " & Condition, "")))
    End Function

    Public Overloads Shared Function Load() As MedicalRepCollection
        Return Filter("")
    End Function
    Public Overloads Shared Function Load(ByVal Salesmancode As String) As MedicalRep
        Return Filter("SLSMNCD = " & Salesmancode)(0)
    End Function

    Public Shared Function LoadByMobileNumber(ByVal MobileNumber As String) As MedicalRep
        If Filter("MobileNumber1 = '" & HandleSingleQuoteInSql(MobileNumber) & "' OR MobileNumber2 = '" & HandleSingleQuoteInSql(MobileNumber) & "'").Count > 0 Then
            Return Filter("MobileNumber1 = '" & HandleSingleQuoteInSql(MobileNumber) & "' OR MobileNumber2 = '" & HandleSingleQuoteInSql(MobileNumber) & "'")(0)
        Else
            Return Nothing
        End If

    End Function
    Public Shared Function LoadByCodes(ByVal SLSMNCD As String) As MedicalRep
        If Filter("SLSMNCD = '" & HandleSingleQuoteInSql(SLSMNCD) & "' ").Count > 0 Then
            Return Filter("SLSMNCD = '" & HandleSingleQuoteInSql(SLSMNCD) & "' ")(0)
        Else
            Return Nothing
        End If
    End Function


    Public Shared Function LoadByCode(ByVal SalesAgentCode As String) As MedicalRep
        Return Filter("SLSMNCD = '" & HandleSingleQuoteInSql(SalesAgentCode) & "'")(0)
    End Function

    Public Shared Function GetSalesAgentName(ByVal SalesAgentCode As String) As String
        Return LoadByCode(SalesAgentCode).SalesAgentName
    End Function
    Public Shared Function GetMedicalRepSql(Optional ByVal SalesmanCode As String = "") As String
        Return "SELECT SLSMNCD, SLSMNCD [MR Code], SLSMNNAME [MR Name] FROM MedicalRep Where DLTFLG = 0 AND IsActive = 1"
    End Function
    Public Shared Function GetMedicalRepColumns() As String
        Return "SLSMNCD; SLSMNCD;SLSMNNAME"
    End Function

    Public Shared Function GetMedicalRepForFiltering() As DataTable
        Return GetRecords("SELECT SLSMNCD [MRCode], SLSMNNAME [MRName],MobileNumber1 [MR Number1], MobileNumber2 [MR Number2] FROM MedicalRep WHERE DLTFLG = 0 AND IsActive = 1")
    End Function

End Class

Public Class MedicalRepCollection
    Inherits List(Of MedicalRep)
End Class
