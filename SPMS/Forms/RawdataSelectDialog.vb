Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ucMasterRegion
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class RawdataSelectDialog
    Dim m_CompanyCode As String
    Dim m_BatchNo As String
    Dim m_Cutmo As String
    Dim m_Cutyear As String
    Public Property CompanyCode() As String
        Get
            Return m_CompanyCode
        End Get
        Set(ByVal value As String)
            m_CompanyCode = value
        End Set
    End Property
    Public Property Batch() As String
        Get
            Return m_BatchNo
        End Get
        Set(ByVal value As String)
            m_BatchNo = value
        End Set
    End Property
    Public Property Cutmonth() As String
        Get
            Return m_Cutmo
        End Get
        Set(ByVal value As String)
            m_Cutmo = value
        End Set
    End Property
    Public Property Cutyear() As String
        Get
            Return m_Cutyear
        End Get
        Set(ByVal value As String)
            m_Cutyear = value
        End Set
    End Property

  

    Private Sub RawdataSelectDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call loadingViewdata()

    End Sub
    Private Sub loadingViewdata()
        Dim m_Raw As New UCRawDataAnalyzer2
        Connect()
        Dim cmd As New SqlCommand("uspViewRawUploading", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@CompanyCode", m_CompanyCode)
        cmd.Parameters.AddWithValue("@RawMont", m_Cutmo)
        cmd.Parameters.AddWithValue("@RawYear", m_Cutyear)
        Dim sqlda As SqlDataAdapter = New SqlDataAdapter(cmd)


        Dim tb As New DataTable
        sqlda.Fill(tb)
        If tb.Rows.Count = 0 Then
            dgData.Rows.Clear()
        Else
            For m As Integer = 0 To tb.Rows.Count - 1
                Dim dr As DataRow = tb.Rows(m)
                Dim row As DataGridViewRow = dgData.Rows(dgData.Rows.Add)
                row.Cells(colCompanycode.Index).Value = dr("companycode")
                row.Cells(colBatch.Index).Value = dr("Batch No")
                row.Cells(colmonth.Index).Value = dr("Month")
                row.Cells(colyear.Index).Value = dr("Year")
                row.Cells(colamounth.Index).Value = dr("Total Gross Amount")
                row.Cells(colqauntity.Index).Value = dr("Total Quantity")
                row.Cells(colProductDisc.Index).Value = dr("Total Product Disc")
                row.Cells(colnetamount.Index).Value = dr("Total Net Amount")
                row.Cells(colUploadDate.Index).Value = dr("UploadDate")
            Next
        End If

    End Sub

    Private Sub dgData_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgData.CellContentDoubleClick
        Dim row As DataGridViewRow = dgData.Rows(e.RowIndex)
        CompanyCode = row.Cells(colCompanycode.Index).Value
        Batch = row.Cells(colBatch.Index).Value
        Cutyear = row.Cells(colyear.Index).Value
        Cutmonth = row.Cells(colmonth.Index).Value
        Me.Dispose()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class