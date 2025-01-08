Imports System.Data.SqlClient
Imports System.Data.Sql
Imports SPMSOPCI.ConnectionModule

Public Class RebatesCompanyMonthYear

    Private m_Year As Integer
    Private m_CompanyCode As String
    Private m_Month As Integer

    Public Property Month() As Integer
        Get
            Return m_Month
        End Get
        Set(value As Integer)
            m_Month = value
        End Set
    End Property

    Public Property CompanyCode() As String
        Get
            Return m_CompanyCode
        End Get
        Set(value As String)
            m_CompanyCode = value
        End Set
    End Property

    Public Property Year() As Integer
        Get
            Return m_Year
        End Get
        Set(value As Integer)
            m_Year = value
        End Set
    End Property


    Private Function GetYear(table As DataTable) As RebatesCompanyMonthYearCollection

        Dim rbcm As New RebatesCompanyMonthYear
        Dim myrow As DataRow
        Dim collector As New RebatesCompanyMonthYearCollection

        For Each myrow In table.Rows
            rbcm = New RebatesCompanyMonthYear
            rbcm.m_Year = myrow.Item("CAYR")
            collector.Add(rbcm)

        Next

        Return collector

    End Function

    Public Function YearLoader() As RebatesCompanyMonthYearCollection
        Dim yeartab As New DataTable
        Dim scommand As New SqlCommand
        Dim sadapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim sqlQuery As String
        Dim rcmcollec As New RebatesCompanyMonthYearCollection

        sqlQuery = "Select distinct CAYR from CALENDAR"

        Try
            Connect()
            scommand = New SqlCommand(sqlQuery, SPMSConn2)
            sadapter = New SqlDataAdapter(scommand)

            sadapter.Fill(yeartab)

            rcmcollec = GetYear(yeartab)
            sadapter.Dispose()
            scommand.Dispose()

            Disconnect()


        Catch ex As Exception

        End Try

        Return rcmcollec

    End Function

    'for loading months

    Private Function GetMonth(table As DataTable) As RebatesCompanyMonthYearCollection

        Dim rbcm As New RebatesCompanyMonthYear
        Dim myrow As DataRow
        Dim collector As New RebatesCompanyMonthYearCollection

        For Each myrow In table.Rows
            rbcm = New RebatesCompanyMonthYear
            rbcm.m_Month = myrow.Item("CAPN")
            collector.Add(rbcm)
        Next

        Return collector

    End Function

    Public Function MonthLoader() As RebatesCompanyMonthYearCollection
        Dim monthtab As New DataTable
        Dim scommand As New SqlCommand
        Dim sadapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim sqlQuery As String
        Dim rcmcollec As New RebatesCompanyMonthYearCollection


        sqlQuery = "Select distinct CAPN from CALENDAR"

        Try
            Connect()
            scommand = New SqlCommand(sqlQuery, SPMSConn2)
            sadapter = New SqlDataAdapter(scommand)

            sadapter.Fill(monthtab)

            Disconnect()
            sadapter.Dispose()
            scommand.Dispose()

            rcmcollec = GetMonth(monthtab)

            Disconnect()

        Catch ex As Exception

        End Try

        Return rcmcollec

    End Function

    'for  loading companycode

    Private Function GetCompanyCode(table As DataTable) As RebatesCompanyMonthYearCollection

        Dim rbcm As New RebatesCompanyMonthYear
        Dim myrow As DataRow
        Dim collector As New RebatesCompanyMonthYearCollection

        For Each myrow In table.Rows
            rbcm = New RebatesCompanyMonthYear
            rbcm.m_CompanyCode = myrow.Item("CompanyCode")
            collector.Add(rbcm)
        Next

        Return collector

    End Function




    Public Function CompanyCodeLoader(TableCaller As String) As RebatesCompanyMonthYearCollection
        Dim comptab As New DataTable
        Dim scommand As New SqlCommand
        Dim sadapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim sqlQuery As String
        Dim rcmcollec As New RebatesCompanyMonthYearCollection


        Try
            Connect()

            If TableCaller = "Rebates" Then
                sqlQuery = "Select distinct CompanyCode from Rebates"
                scommand = New SqlCommand(sqlQuery, SPMSConn2)
            ElseIf TableCaller = "RawData" Then
                sqlQuery = "Select distinct CompanyCode from RawData"
                scommand = New SqlCommand(sqlQuery, SPMSConn2)
            ElseIf TableCaller = "RebatesDetail" Then
                sqlQuery = "Select distinct CompanyCode from RebatesDetail"
                scommand = New SqlCommand(sqlQuery, SPMSConn2)
            End If

            sadapter = New SqlDataAdapter(scommand)

            sadapter.Fill(comptab)

            sadapter.Dispose()
            scommand.Dispose()

            rcmcollec = GetCompanyCode(comptab)

            Disconnect()


        Catch ex As Exception

        End Try

        Return rcmcollec

    End Function

End Class

Public Class RebatesCompanyMonthYearCollection
    Inherits List(Of RebatesCompanyMonthYear)
End Class