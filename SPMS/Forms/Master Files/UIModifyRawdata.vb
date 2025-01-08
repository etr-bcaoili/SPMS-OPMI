Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Imports System.Data.OleDb
Imports System
Imports System.IO
Imports System.Collections
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class UIModifyRawdata
    Dim table As New DataTable
    Dim dt As New DataTable
    Dim dts As SqlDataReader
    Private m_RawData As New RawData
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_DoctorName As String = String.Empty
    Private m_CompanyCode As String = String.Empty
    Private m_Month As String = String.Empty
    Private m_Year As String = String.Empty


    Private m_PTR As String = String.Empty

    Public Property DoctorName As String
        Get
            Return m_DoctorName
        End Get
        Set(value As String)
            m_DoctorName = value
        End Set
    End Property
    Public Property PTRNO As String
        Get
            Return m_PTR
        End Get
        Set(value As String)
            m_PTR = value
        End Set
    End Property
    Public Property CompanyCode As String
        Get
            Return m_CompanyCode
        End Get
        Set(value As String)
            m_CompanyCode = value
        End Set
    End Property
    Public Property Month As String
        Get
            Return m_Month
        End Get
        Set(value As String)
            m_Month = value
        End Set
    End Property
    Public Property Year As String
        Get
            Return m_Year
        End Get
        Set(value As String)
            m_Year = value
        End Set
    End Property

    Private Sub UIModifyRawdata_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMedicalDoctor(m_CompanyCode, m_Year, m_Month, m_DoctorName)
    End Sub
    Private Sub LoadMedicalDoctor(ByVal CompanyCode As String, ByVal Year As String, ByVal Month As String, ByVal DoctorName As String)
        If SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Closed Or SPMSOPCI.ConnectionModule.SPMSConn2.State = ConnectionState.Broken Then SPMSOPCI.ConnectionModule.Connect()
        Try
            Dim cmd As New SqlCommand("uspRawDataMedicalDoctor", SPMSOPCI.ConnectionModule.SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "ModifyDoctor")
            cmd.Parameters.AddWithValue("@CompanyCode", CompanyCode)
            cmd.Parameters.AddWithValue("@Year", Year)
            cmd.Parameters.AddWithValue("@Month", Month)
            cmd.Parameters.AddWithValue("@CustomerName", DoctorName)


            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Clear()

            da.Fill(dt)

            GrdViewRawData.DataSource = dt
            Disconnect()

            GrdViewRawData.Columns(0).Width = 150
            GrdViewRawData.Columns(1).Width = 150
            GrdViewRawData.Columns(2).Width = 150
            GrdViewRawData.Columns(3).Width = 150
            GrdViewRawData.Columns(4).Width = 150
            GrdViewRawData.Columns(5).Width = 150
            GrdViewRawData.Columns(6).Width = 150
            GrdViewRawData.Columns(7).Width = 150
            GrdViewRawData.Columns(8).Width = 150
            GrdViewRawData.Columns(9).Width = 150
            GrdViewRawData.Columns(10).Width = 150
            GrdViewRawData.Columns(11).Width = 150
            GrdViewRawData.Columns(12).Width = 150
            GrdViewRawData.Columns(12).FormatString = "{0:F2}"
            GrdViewRawData.Columns(13).Width = 150
            GrdViewRawData.Columns(13).FormatString = "{0:F2}"
            Disconnect()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class