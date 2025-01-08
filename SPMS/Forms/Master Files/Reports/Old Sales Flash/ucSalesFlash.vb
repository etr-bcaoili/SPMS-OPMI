Imports SPMS.ConnectionModule
Imports System.Data
Imports System.Data.SqlClient

Public Class ucSalesFlash

    Private bindingSource1 As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.DataGridView1.ClearSelection()
        Me.Label4.Text = "NATIONAL - CONSOLIDATED  PRODUCT WISE TGT VS ACH NET  SALES (STM) REPORT FOR THE CURRENT MONTH"
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData(" EXECUTE dbo.uspVBSalesFlashNationalProductChannelWise ")

    End Sub

    Private Sub GetData(ByVal selectCommand As String)

        Try
            ' Specify a connection string. Replace the given value with a 
            ' valid connection string for a Northwind SQL Server sample
            ' database accessible to your system.
            Dim connectionString As String = ""

            If SqlConnectionExists() = True Then
                connectionString = GetSqlconnectionPath()

            Else
                connectionString = "data source=192.168.0.2; initial catalog=SPMS; user id=sa; password=;"
            End If

            ' Create a new data adapter based on the specified query.
            Me.dataAdapter = New SqlDataAdapter(selectCommand, connectionString)

            ' Create a command builder to generate SQL update, insert, and
            ' delete commands based on selectCommand. These are used to
            ' update the database.
            Dim commandBuilder As New SqlCommandBuilder(Me.dataAdapter)

            ' Populate a new data table and bind it to the BindingSource.
            Dim table As New DataTable()
            table.Locale = System.Globalization.CultureInfo.InvariantCulture
            Me.dataAdapter.Fill(table)
            Me.bindingSource1.DataSource = table

            ' Right Align double data types
            Dim style As DataGridViewCellStyle
            Dim i As Integer
            Dim j As Decimal
            style = New DataGridViewCellStyle()
            style.Alignment = DataGridViewContentAlignment.MiddleRight
            i = 0
            While i < DataGridView1.ColumnCount
                If (DataGridView1.Columns.Item(i).ValueType Is j.GetType) Then
                    DataGridView1.Columns.Item(i).DefaultCellStyle = style
                End If
                i = i + 1
            End While


        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.DataGridView1.ClearSelection()
        Me.Label4.Text = "Sales Report for Current Month"
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData(" EXECUTE dbo.uspVBSalesFlashNationalMedRepWise ")
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Me.DataGridView1.ClearSelection()
        Me.Label4.Text = "Sales Report for Current Month - Item Division 'CUTI'"
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData(" EXECUTE dbo.uspVBSalesFlashNationalProductAMWiseByDivision '01' ")
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Me.DataGridView1.ClearSelection()
        Me.Label4.Text = "Sales Report for Current Month - Item Division'RESPI'"
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData(" EXECUTE dbo.uspVBSalesFlashNationalProductAMWiseByDivision '02' ")
    End Sub

    Private Sub LinkLabel5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Me.DataGridView1.ClearSelection()
        Me.Label4.Text = "Sales Report for Current Month - IItem Division 'DEFAULT'"
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData(" EXECUTE dbo.uspVBSalesFlashNationalProductAMWiseByDivision '999' ")
    End Sub

    Private Sub ucSalesFlash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(DataGridView1)
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
