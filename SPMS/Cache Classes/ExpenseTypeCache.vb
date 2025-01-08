Imports SPMSOPCI.ConnectionModule
Imports System.Data.SqlClient
Public Class ExpenseTypeCache
    Private dt As New DataTable
    Private dv As DataView

    Private m_ExpenseCode As String
    Private m_ExpenseDescription As String

    Public Property ExpenseCode() As String
        Get
            Return m_ExpenseCode
        End Get
        Set(ByVal value As String)
            m_ExpenseCode = value
        End Set
    End Property

    Public Property ExpenseDescription() As String
        Get
            Return m_ExpenseDescription
        End Get
        Set(ByVal value As String)
            m_ExpenseDescription = value
        End Set
    End Property

    Public Sub InitializedCache()
        dt = LoadDataTable()
    End Sub
    Private Function LoadDataTable() As DataTable
        Connect()
        Dim cmd As New SqlCommand("uspExpenseParticulars", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure

        Dim da As New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        Disconnect()
        Return dt
    End Function

    Private Function RefineFilter(ByVal Value As String) As String
        Value = Replace(Value, "[", "")
        Value = Replace(Value, "]", "")
        Return IIf(Value Is Nothing, "", Value)
    End Function

    Public Function FilterDv() As DataView

        dv = dt.DefaultView

        Dim m_Filter As String = String.Empty

        If m_ExpenseCode <> "" Then
            m_Filter = "Code like '%" & HandleSingleQuoteInSql(RefineFilter(m_ExpenseCode)) & "%' "
        End If
        If m_ExpenseDescription <> "" Then
            If m_Filter <> "" Then m_Filter &= " AND "
            m_Filter &= "Description like '%" & HandleSingleQuoteInSql(RefineFilter(m_ExpenseDescription)) & "%' "
        End If
      
        dv.RowFilter = m_Filter

        Return dv
    End Function
End Class
