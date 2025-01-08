Imports System.Data.SqlClient
Imports SPMSOPCI.ConnectionModule
Public Class SystemSequences
    Private m_SequenceCode As String = String.Empty
    Private m_SequenceValue As Integer = 0
    Public Property SequenceCode() As String
        Get
            Return m_SequenceCode
        End Get
        Set(ByVal value As String)
            m_SequenceCode = value
        End Set
    End Property
    Public Property SequenceValue() As Integer
        Get
            Return m_SequenceValue
        End Get
        Set(ByVal value As Integer)
            m_SequenceValue = value
        End Set
    End Property

    Private Shared Function GetSequence(ByVal SequenceCode As String) As String
        If SPMSConn2.State = ConnectionState.Closed Or SPMSConn2.State = ConnectionState.Broken Then Connect()
        Dim m_Code As String = String.Empty
        Try
            Dim cmd As New SqlCommand("uspSystemSequences", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "GetSequence")
            cmd.Parameters.AddWithValue("@SequenceCode", SequenceCode)
            m_Code = cmd.ExecuteScalar
            Return m_Code
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return String.Empty
        End Try
    End Function

    Public Shared Function GetItemBudgetAllocationSequence() As String
        Return GetSequence("ItemBudgetAllocation")
    End Function

    Public Shared Function GetItemAllocation() As String
        Return GetSequence("ItemAllocation")
    End Function

    Public Shared Function GetItemReceival() As String
        Return GetSequence("ItemReceival")
    End Function

    Public Shared Function GetCoveragePlanSequence() As String
        Return GetSequence("CoveragePlan")
    End Function

    Public Shared Function GetActualCoverageSequence() As String
        Return GetSequence("ActualCoverage")
    End Function

    Public Shared Function GetExpenseNextSequence() As String
        Return GetSequence("Expense")
    End Function
    Public Shared Function GetMedicalDoctorSequence() As String
        Return GetSequence("MedicalDoctor")
    End Function

    Public Shared Function GetBillingOrderSequence() As String
        Return GetSequence("BillingOrder")
    End Function

    Private Shared Function ResetSequeces(ByVal SequenceCode As String) As String
        If SPMSConn2.State = ConnectionState.Closed Or SPMSConn2.State = ConnectionState.Broken Then Connect()
        Dim m_Code As String = String.Empty
        Try
            Dim cmd As New SqlCommand("uspSystemSequences", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "ResetSequence")
            cmd.Parameters.AddWithValue("@SequenceCode", SequenceCode)
            m_Code = cmd.ExecuteScalar
            Return m_Code
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return String.Empty
        End Try
    End Function



    Private Shared Function RegisterSequence(ByVal SequenceCode As String) As String
        If SPMSConn2.State = ConnectionState.Closed Or SPMSConn2.State = ConnectionState.Broken Then Connect()
        Dim m_Code As String = String.Empty
        Try
            Dim cmd As New SqlCommand("uspSystemSequences", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "RegisterSequence")
            cmd.Parameters.AddWithValue("@SequenceCode", SequenceCode)
            m_Code = cmd.ExecuteScalar
            Return m_Code
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return String.Empty
        End Try
    End Function

    Public Shared Function GetPMRSequence() As String
        Return GetSequence("MedicalDoctor")
    End Function

End Class


Public Class SystemSequencesCollection
    Inherits List(Of SystemSequences)
End Class
