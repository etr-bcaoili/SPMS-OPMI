Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class MedicalRepresentative
    Private m_DLTFLG As Boolean = 0
    Private m_SLSMNCD As String = String.Empty
    Private m_SLSMNNAME As String = String.Empty
    Private m_ISACTIVE As Boolean = 1
    Private m_PositionCode As String = String.Empty
    Private m_PositionName As String = String.Empty
    Private m_TerritoryCode As String = String.Empty
    Private m_TerritoryName As String = String.Empty
    Private m_ConfigTypeCode As String = String.Empty
    Private m_EffectivityStartDate As Date = "1/1/1990"
    Private m_EffectivityEndDate As Date = "1/1/1990"
    Private m_EmailAddress As String = String.Empty
    Private m_IsActiveEmail As Boolean = True

    Public Property DLTFLG As Boolean
        Get
            Return m_DLTFLG
        End Get
        Set(value As Boolean)
            m_DLTFLG = value
        End Set
    End Property
    Public Property SLSMNCD As String
        Get
            Return m_SLSMNCD
        End Get
        Set(value As String)
            m_SLSMNCD = value
        End Set
    End Property
    Public Property SLSMNNAME As String
        Get
            Return m_SLSMNNAME
        End Get
        Set(value As String)
            m_SLSMNNAME = value
        End Set
    End Property
    Public Property ISACTIVE As Boolean
        Get
            Return m_ISACTIVE
        End Get
        Set(value As Boolean)
            m_ISACTIVE = value
        End Set
    End Property
    Public Property PositionCode As String
        Get
            Return m_PositionCode
        End Get
        Set(value As String)
            m_PositionCode = value
        End Set
    End Property
    Public Property PositionName As String
        Get
            Return m_PositionName
        End Get
        Set(value As String)
            m_PositionName = value
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
    Public Property TerritoryName As String
        Get
            Return m_TerritoryName
        End Get
        Set(value As String)
            m_TerritoryName = value
        End Set
    End Property
    Public Property ConfigTypeCode As String
        Get
            Return m_ConfigTypeCode
        End Get
        Set(value As String)
            m_ConfigTypeCode = value
        End Set
    End Property
    Public Property EffectivityStartDate As Date
        Get
            Return m_EffectivityStartDate
        End Get
        Set(value As Date)
            m_EffectivityStartDate = value
        End Set
    End Property
    Public Property EffectivityEndDate As Date
        Get
            Return m_EffectivityEndDate
        End Get
        Set(value As Date)
            m_EffectivityEndDate = value
        End Set
    End Property
    Public Property EmailAddress As String
        Get
            Return m_EmailAddress
        End Get
        Set(value As String)
            m_EmailAddress = value
        End Set
    End Property
    Public Property IsActiveEmail As Boolean
        Get
            Return m_IsActiveEmail
        End Get
        Set(value As Boolean)
            m_IsActiveEmail = value
        End Set
    End Property
    Private Shared Function BaseFilter(ByVal table As System.Data.DataTable) As MedicalRepresentativeCollection
        Dim col As New MedicalRepresentativeCollection
        For j As Integer = 0 To table.Rows.Count - 1
            Dim m_MedicalRepresentative As New MedicalRepresentative
            Dim row As DataRow = table.Rows(j)
            m_MedicalRepresentative.m_SLSMNCD = row("SLSMNCD")
            m_MedicalRepresentative.m_DLTFLG = row("DLTFLG")
            m_MedicalRepresentative.m_SLSMNNAME = row("SLSMNNAME")
            m_MedicalRepresentative.m_PositionCode = row("PositionCode")
            m_MedicalRepresentative.m_PositionName = row("PositionName")
            m_MedicalRepresentative.m_TerritoryCode = row("TerritoryCode")
            m_MedicalRepresentative.m_TerritoryName = row("TerritoryName")
            m_MedicalRepresentative.m_ConfigTypeCode = row("ConfigTypeCode")
            m_MedicalRepresentative.m_EffectivityStartDate = row("EffectivityStartDate")
            m_MedicalRepresentative.m_EffectivityEndDate = row("EffectivityEndDate")
            m_MedicalRepresentative.m_EmailAddress = row("EmailAddress")
            m_MedicalRepresentative.m_IsActiveEmail = row("IsActiveEmail")
            col.Add(m_MedicalRepresentative)
        Next
        Return col
    End Function
    Public Function Save() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspMedicalRep", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "SAVE")
            cmd.Parameters.AddWithValue("@DLTFLG", m_DLTFLG)
            cmd.Parameters.AddWithValue("@SLSMNCD", m_SLSMNCD)
            cmd.Parameters.AddWithValue("@SLSMNNAME", m_SLSMNNAME)
            cmd.Parameters.AddWithValue("@IsActive", m_ISACTIVE)
            cmd.Parameters.AddWithValue("@PositionCode", m_PositionCode)
            cmd.Parameters.AddWithValue("@PositionName", m_PositionName)
            cmd.Parameters.AddWithValue("@TerritoryCode", m_TerritoryCode)
            cmd.Parameters.AddWithValue("@TerritoryName", m_TerritoryName)
            cmd.Parameters.AddWithValue("@ConfigTypeCode", m_ConfigTypeCode)
            cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", m_EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", m_EffectivityEndDate)
            cmd.Parameters.AddWithValue("@EmailAddress", m_EmailAddress)
            cmd.Parameters.AddWithValue("@IsActiveEmail", m_IsActiveEmail)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Function Update() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspMedicalRep", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "UPDATE")
            cmd.Parameters.AddWithValue("@DLTFLG", m_DLTFLG)
            cmd.Parameters.AddWithValue("@SLSMNCD", m_SLSMNCD)
            cmd.Parameters.AddWithValue("@SLSMNNAME", m_SLSMNNAME)
            cmd.Parameters.AddWithValue("@IsActive", m_ISACTIVE)
            cmd.Parameters.AddWithValue("@PositionCode", m_PositionCode)
            cmd.Parameters.AddWithValue("@PositionName", m_PositionName)
            cmd.Parameters.AddWithValue("@TerritoryCode", m_TerritoryCode)
            cmd.Parameters.AddWithValue("@TerritoryName", m_TerritoryName)
            cmd.Parameters.AddWithValue("@ConfigTypeCode", m_ConfigTypeCode)
            cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", m_EffectivityStartDate)
            cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", m_EffectivityEndDate)
            cmd.Parameters.AddWithValue("@EmailAddress", m_EmailAddress)
            cmd.Parameters.AddWithValue("@IsActiveEmail", m_IsActiveEmail)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            SPMSOPCI.ConnectionModule.Disconnect()
            Throw
        End Try
    End Function
    Public Function Delete() As Boolean
        Try
            SPMSOPCI.ConnectionModule.Connect()
            Dim cmd As New SqlCommand("uspMedicalRep", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Delete")
            cmd.Parameters.AddWithValue("@DLTFLG", True)
            cmd.Parameters.AddWithValue("@SLSMNCD", m_SLSMNCD)
            cmd.ExecuteNonQuery()
            SPMSOPCI.ConnectionModule.Disconnect()
            Return True
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Public Shared Function Filter(ByVal Condition As String) As MedicalRepresentativeCollection
        Return BaseFilter(GetRecords("SELECT * FROM MEDICALREP  WHERE DLTFLG = 0 AND " & IIf(Condition <> "", Condition, "")))
    End Function
    Public Overloads Shared Function Load() As MedicalRepresentativeCollection
        Return Filter("")
    End Function
    Public Shared Function LoadByCode(ByVal SLSMNCD As String) As MedicalRepresentative
        Return Filter("SLSMNCD = '" & RefineSQL(SLSMNCD) & "'")(0)
    End Function
    Public Shared Function CheckofMedicalRepAlreadyExist(ByVal Code As String) As Boolean
        Return ExecuteCommand("SELECT 'A' FROM MEDICALREP WHERE DLTFLG = 0 AND  SLSMNCD = '" & RefineSQL(Code) & "'") = "A"
    End Function
    Public Shared Function GetMedicalRepSql(Optional ByVal SLSMNCD As String = "") As String
        Return "SELECT SLSMNCD, SLSMNCD [PMR Code], SLSMNNAME [PMR Name],PositionCode [Position Code],PositionName[Position Name] FROM MEDICALREP Where DLTFLG = 0 "
    End Function
    Public Shared Function GetPMRSql(Optional ByVal SLSMNCD As String = "") As String
        Return "SELECT SLSMNCD, SLSMNCD [PMR Code], SLSMNNAME [PMR Name],PositionCode [Position Code],PositionName[Position Name] FROM MEDICALREP Where DLTFLG = 0 "
    End Function
    Public Shared Function GetSourceData(ByVal PMRCode As String, ByVal ConfigtypeCode As String) As String
        'Return "Select Distinct Year,Case Month When '01' Then 'January' When '02' Then 'February' When '03' Then 'March' When '04' Then 'April' When '05' Then 'May' When '06' Then 'June' When '07' Then 'July' When '08' Then 'August' When '09' Then 'September' When '10' Then 'October' When '11' Then 'November' When '12' Then 'December' End AS MONTHS ,Configtypecode,MONTH From SC02File Where [Territory Code] = '" & PMRCode & "'And Configtypecode = '" & ConfigtypeCode & "' Order by Month,Year DESC"
        Return ExecuteCommand("uspTMLbyConfig '" & PMRCode & "','" & ConfigtypeCode & "'")
    End Function
    Public Shared Function UpdateRecordSharing(ByVal ConfigtypeCode As String, ByVal PMRCode As String, ByVal PMRName As String) As Boolean
        Return ExecuteCommand("Update Sharing Set TERRCD = '" & PMRCode & "',STSLSMNCD = '" & PMRCode & "',STSLSMNNAME = '" & PMRName & "' Where Configtypecode = '" & ConfigtypeCode & "' And TERRCD = '" & PMRCode & "'")
    End Function
    Public Shared Function UpdateRecordSalesmatrix(ByVal ConfigtypeCode As String, ByVal PMRCode As String, ByVal PMRName As String, ByVal TerritoryName As String) As Boolean
        Return ExecuteCommand("Update SalesMatrix Set STACOVNAME = '" & TerritoryName & "',STSLSMNNAME  = '" & PMRName & "' Where STSLSMNCD = '" & PMRCode & "' And Configtypecode = '" & ConfigtypeCode & "'")
    End Function
    Public Shared Function UpdateRecordSc02(ByVal ConfigtypeCode As String, ByVal PMRCode As String, ByVal PMRName As String, ByVal TerritoryName As String) As Boolean
        Return ExecuteCommand("Update SC02File Set [Territory Name] = '" & TerritoryName & "',[Territory Manager Name] = '" & PMRName & "' Where [Territory Code] = '" & PMRCode & "' And Configtypecode = '" & ConfigtypeCode & "'")
    End Function
    Public Shared Function GetPMRSql() As String
        Return "Select Distinct SLSMNCD,SLSMNCD [PMR Code],SLSMNNAME [PMR Name],ConfigTypeCode From MEDICALREP Where  DLTFLG = 0 Order by SLSMNCD  "
    End Function
    Public Shared Function GetPMRCollectionSql(ByVal PMRCode As String) As String
        Return "Select Distinct A.SLSMNCD,A.SLSMNCD [PMR Code],A.SLSMNNAME [PMR Name],A.ConfigTypeCode  From MEDICALREP A INNER JOIN SALESMATRIX B ON A.ConfigTypeCode = B.Configtypecode Where B.DLTFLG = 0 AND A.SLSMNCD = '" & PMRCode & "'"
    End Function
    Public Shared Function CheckofPMRTaggingAlreadyExist(ByVal PMRCode As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal ConfigCode As String) As Boolean
        Return ExecuteCommand("Select 'A' from EmployeeSalesmanCollection Where TerritoryCode = '" & PMRCode & "' And EffectivityStartDate = '" & StartDate & "' And EffectivityEndDate = '" & EndDate & "' And ConfigtypeCode = '" & ConfigCode & "'") = "A"
    End Function
End Class
Public Class MedicalRepresentativeCollection
    Inherits List(Of MedicalRepresentative)
End Class
