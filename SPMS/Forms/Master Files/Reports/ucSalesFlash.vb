Imports SPMSOPCI.ConnectionModule
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


    Private Sub ucSalesFlash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(DataGridView1)
    End Sub

    Private Sub LL_PS1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LL_PS1.LinkClicked
        Me.Label4.Text = "Processed Sales: Division and Product Wise Achievement"
        Me.DataGridView1.ClearSelection()
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData(" EXECUTE dbo.uspVBProcessedSalesAchievement_ProductWise ")
    End Sub

    Private Sub LL_PS2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LL_PS2.LinkClicked
        Me.Label4.Text = "Processed Sales: Division and Territory Wise Achievement"
        Me.DataGridView1.ClearSelection()
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData(" EXECUTE dbo.uspVBProcessedSalesAchievement_TerritoryWise ")
    End Sub

    Private Sub LL_PS3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LL_PS3.LinkClicked
        Me.Label4.Text = "Processed Sales: Division and District Wise Achievement"
        Me.DataGridView1.ClearSelection()
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData(" EXECUTE dbo.uspVBProcessedSalesAchievement_DistrictWise ")
    End Sub

    Private Sub LL_PS4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LL_PS4.LinkClicked
        Me.Label4.Text = "Processed Sales: Division and Region Wise Sales"
        Me.DataGridView1.ClearSelection()
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData(" EXECUTE dbo.uspVBProcessedSales_RegionWise ")
    End Sub

    Private Sub LL_PS5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LL_PS5.LinkClicked
        Me.Label4.Text = "Processed Sales: Division and Channel Wise Sales"
        Me.DataGridView1.ClearSelection()
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData(" EXECUTE dbo.uspVBProcessedSales_ChannelWise ")
    End Sub

    Private Sub LL_PS6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LL_PS6.LinkClicked
        Me.Label4.Text = "Processed Sales: Division and Customer Group Wise Sales"
        Me.DataGridView1.ClearSelection()
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData(" EXECUTE dbo.uspVBProcessedSales_CustGrpWise ")
    End Sub

    Private Sub LL_PS7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LL_PS7.LinkClicked
        Me.Label4.Text = "Processed Sales: Division and Customer Class Wise Sales"
        Me.DataGridView1.ClearSelection()
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData(" EXECUTE dbo.uspVBProcessedSales_CustClassWise ")
    End Sub

    Private Sub LL_PS8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LL_PS8.LinkClicked
        Me.Label4.Text = "Processed Sales: Division and Default Territory Wise Sales"
        Me.DataGridView1.ClearSelection()
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData(" EXECUTE dbo.uspVBProcessedSales_DefaultTerrWise ")
    End Sub

    Private Sub LL_UPS1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LL_UPS1.LinkClicked
        Me.Label4.Text = "Under-Processing Sales: Division and Channel Wise Unmapped Sales"
        Me.DataGridView1.ClearSelection()
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData(" EXECUTE dbo.uspVBUnderProcessingSales_ChannelWiseUnmapped ")
    End Sub

    Private Sub LL_UPS2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LL_UPS2.LinkClicked
        Me.Label4.Text = "Under-Processing Sales: Division and Channel Wise Mapped Sales"
        Me.DataGridView1.ClearSelection()
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData(" EXECUTE dbo.uspVBUnderProcessingSales_ChannelWiseMapped ")
    End Sub

    Private Sub LL_UPS3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LL_UPS3.LinkClicked
        Me.Label4.Text = "Under-Processing Sales: Division and Territory Wise Mapped Sales"
        Me.DataGridView1.ClearSelection()
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData(" EXECUTE dbo.uspVBUnderProcessingSales_TerritoryWiseMapped ")
    End Sub

    Private Sub LL_UPS4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LL_UPS4.LinkClicked
        Me.Label4.Text = "Under-Processing Sales: Division and Product Wise Unmapped Sales"
        Me.DataGridView1.ClearSelection()
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData(" EXECUTE dbo.uspVBUnderProcessingSales_ProductWiseUnmapped ")
    End Sub

    Private Sub LL_UPS5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LL_UPS5.LinkClicked
        Me.Label4.Text = "Under-Processing Sales: Division and Product Wise Mapped Sales"
        Me.DataGridView1.ClearSelection()
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData(" EXECUTE dbo.uspVBUnderProcessingSales_ProductWiseMapped ")
    End Sub
End Class
