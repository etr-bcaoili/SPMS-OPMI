Imports SPMSOPCI.ConnectionModule
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.IO
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.Text
Imports System.Web
Imports System.Configuration
Imports Ionic.Zip
Imports System.Security.Policy


Public Class UIPublishReport
    Dim objApp As Excel.Application
    Dim objBook As Excel._Workbook
    Dim Table As New DataTable
    Private m_Configtype As New Configuration
    Dim m_HasError As Boolean = False
    Private m_Err As New ErrorProvider
    Private m_PublishData As New PublshData
    Dim objExcel As Excel.Application
    Private m_DistributorCode As String = "OPCI"
    Private m_ClientCode As String = "VXC3_"
    Private m_BasePath As String

    Private Sub btnNexts_Click(sender As Object, e As EventArgs) Handles btnNexts.Click
        If TabControl1.SelectedIndex = 0 Then
            If ValidateData() Then
                TabControl1.SelectedTab = TabPage3
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then
            ' TabControl1.SelectTab(TabPage4)
        End If
    End Sub
    Private Sub btnBacks_Click(sender As Object, e As EventArgs) Handles btnBacks.Click
        If TabControl1.SelectedIndex = 3 Then
            TabControl1.SelectedTab = TabPage3
        ElseIf TabControl1.SelectedIndex = 2 Then
            TabControl1.SelectedTab = TabPage1
        ElseIf TabControl1.SelectedIndex = 1 Then
            TabControl1.SelectTab(TabPage1)
        End If
    End Sub

    Private Sub FindConfigtype_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles FindConfigtype.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Medical Configuration")
        If Not tag Is Nothing Then
            txtConfigCode.Text = tag.KeyColumn11
            txtConfigurationName.Text = tag.KeyColumn33
        End If
    End Sub

    Private Sub DropYear_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles DropYear.SelectedIndexChanged
        If DropYear.SelectedIndex = -1 Then Exit Sub
        LoadMonth(m_DistributorCode, DropYear.Text)
    End Sub
    Private Sub LoadMonth(ByVal DistributorCode As String, ByVal Year As String)
        DropMonth.Items.Clear()
        Table = GetRecords(Configuration.GetMonthConfigtype(DistributorCode, Year))
        For i As Integer = 0 To Table.Rows.Count - 1
            DropMonth.Items.Add(Table.Rows(i)("CAPN"))
        Next
    End Sub

    Private Sub UIPublishReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadYear()
    End Sub
    Private Sub LoadYear()
        Table = GetRecords(Configuration.GetYearbyConfig)
        For i As Integer = 0 To Table.Rows.Count - 1
            DropYear.Items.Add(Table.Rows(i)("CAYR"))
        Next
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If txtConfigCode.Text = "" Then
            m_Err.SetError(txtConfigurationName, "Configuration is Required!")
            m_HasError = True
        End If

        If txtConfigurationName.Text = "" Then
            m_Err.SetError(txtConfigurationName, "EmployeeEmployee Last Name is Required!")
            m_HasError = True
        End If

        If DropYear.Text = "" Then
            m_Err.SetError(txtInvalidYear, "Year is Required!")
            m_HasError = True
        End If

        If DropMonth.Text = "" Then
            m_Err.SetError(txtInvalidMonth, "Month is Required!")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
    Private Sub LoadChannel()
        Table = GetRecords(Distributor.GetChannelSql())
        GrdChannel.Rows.Clear()
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdChannel.Rows.AddNew
            rowinfo.Cells(0).Value = False
            rowinfo.Cells(1).Value = Table.Rows(i)("DISTCOMID")
            rowinfo.Cells(2).Value = Table.Rows(i)("DISTNAME")
        Next
    End Sub

    Private Sub btnStartData_Click(sender As Object, e As EventArgs) Handles btnStartData.Click
        If txtConfigCode.Text = "" Then
            MsgBox("Select the ConfigTypeCode", MsgBoxStyle.Exclamation)
        ElseIf DropYear.Text = String.Empty Then
            MsgBox("Select the  from Year ", MsgBoxStyle.Exclamation)
        ElseIf DropMonth.Text = String.Empty Then
            MsgBox("Select the Month set from", MsgBoxStyle.Exclamation)
        Else
            For m As Integer = 0 To GrdChannel.Rows.Count - 1
                Dim rowinfos As GridViewRowInfo = GrdChannel.Rows(m)
                If rowinfos.Cells(0).Value = True Then
                    m_PublishData.ConfigtypeCode = txtConfigCode.Text
                    m_PublishData.Year = DropYear.Text
                    m_PublishData.Month = DropMonth.Text
                    'm_PublishData.ChannelCode = rowinfos.Cells(1).Value
                    'txtListChannel.Text = "Channel Code" & "" & rowinfos.Cells(1).Value
                    m_PublishData.Save()
                    txtListChannel.Text = String.Empty
                End If
            Next
            GeneratedFileExcel(txtConfigCode.Text, DropYear.Text, DropMonth.Text)
            ProcessInportData.Main()
        End If
    End Sub
    Private Sub GeneratedFileExcel(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String)
        Try
            Dim zipFilePath As String = ConfigurationManager.AppSettings("ZipFilePath")
            ' Generate the timestamp (yyyyMMddHHmmss)
            Dim timestamp As String = DateTime.Now.ToString("yyyyMMddHHmmss")

            ' Call the ZipDirectory method

            m_BasePath = ConfigurationManager.AppSettings("ReportBasePath")

            ' Create the directory
            Directory.CreateDirectory(m_BasePath)

            SyncFinalSalesCSV(ConfigtypeCode, Year, Month)
            SyncDataSalesmatrixCSV(ConfigtypeCode, Year, Month)
            SyncDataTerritoriesCSV(ConfigtypeCode, Year, Month)
            SyncDataDistrictsCSV(ConfigtypeCode, Year, Month)
            SyncDataAgentsCSV(ConfigtypeCode, Year, Month)
            SyncDataSalesManagerCSV(ConfigtypeCode, Year, Month)
            SyncDataItemsCSV(ConfigtypeCode, Year, Month)
            SyncDataTargetCSV(ConfigtypeCode, Year, Month)
            SyncDataCustomerCSV(ConfigtypeCode, Year, Month)
            ZipDirectory(m_BasePath, zipFilePath)
            Timer1.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            m_HasError = True
            Me.Close()
        End Try
    End Sub
    Sub ZipDirectory(ByVal sourceDirectory As String, ByVal zipFilePath As String)
        ' Check if the source directory exists
        If Directory.Exists(sourceDirectory) Then
            ' Create a new ZIP file
            Using zip As New ZipFile()
                ' Set the compression level (optional)
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression

                ' Add the directory to the ZIP file
                zip.AddDirectory(sourceDirectory)

                ' Save the ZIP file
                zip.Save(zipFilePath)
            End Using
            Console.WriteLine("Directory successfully zipped to " & zipFilePath)


            ' Generate the timestamp (yyyyMMddHHmmss)
            Dim timestamp As String = m_ClientCode & DateTime.Now.ToString("yyyyMMddHHmmss")

            ' Construct the new file name with .m4 extension
            Dim directory As String = Path.GetDirectoryName(zipFilePath)
            Dim newFileName As String = $"{timestamp}.m4"
            Dim newFilePath As String = Path.Combine(directory, newFileName)

            ' Rename the ZIP file to .m4
            Try
                If File.Exists(zipFilePath) Then
                    File.Move(zipFilePath, newFilePath)
                    Console.WriteLine("File successfully renamed to: " & newFilePath)
                Else
                    Console.WriteLine("Temporary ZIP file does not exist.")
                End If
            Catch ex As Exception
                ' Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}")
            End Try

        Else
            Console.WriteLine("Source directory does not exist.")
        End If
    End Sub
    Private Function SyncDataCustomerCSV(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String)
        Try
            Table = PublishReport.GetSyncDataCustomer(ConfigtypeCode, Year, Month)

            Dim csvFilePath As String = m_BasePath & "\SyncDataCustomer.csv"
            ' Create a StreamWriter to write to the file
            Using writer As New StreamWriter(csvFilePath)
                ' Write the header row with column names
                Dim columnHeaders = String.Join(",", Table.Columns.Cast(Of DataColumn)().Select(Function(col) col.ColumnName).ToArray())
                writer.WriteLine(columnHeaders)

                ' Write each row in the DataTable
                For Each row As DataRow In Table.Rows
                    ' Use quotes around each field to handle commas or special characters within values
                    Dim rowValues = String.Join(",", row.ItemArray.Select(Function(value) """" & value.ToString().Replace("""", """""") & """").ToArray())
                    writer.WriteLine(rowValues)
                Next
            End Using

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Function
    Private Function SyncDataTargetCSV(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String)
        Try
            Table = PublishReport.GetSyncDataTarget(ConfigtypeCode, Year, Month)

            Dim csvFilePath As String = m_BasePath & "\SyncDataTarget.csv"
            ' Create a StreamWriter to write to the file
            Using writer As New StreamWriter(csvFilePath)
                ' Write the header row with column names
                Dim columnHeaders = String.Join(",", Table.Columns.Cast(Of DataColumn)().Select(Function(col) col.ColumnName).ToArray())
                writer.WriteLine(columnHeaders)

                ' Write each row in the DataTable
                For Each row As DataRow In Table.Rows
                    ' Use quotes around each field to handle commas or special characters within values
                    Dim rowValues = String.Join(",", row.ItemArray.Select(Function(value) """" & value.ToString().Replace("""", """""") & """").ToArray())
                    writer.WriteLine(rowValues)
                Next
            End Using

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Function
    Private Function SyncDataItemsCSV(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String)
        Try
            Table = PublishReport.GetSyncDataItems(ConfigtypeCode, Year, Month)

            Dim csvFilePath As String = m_BasePath & "\SyncDataItems.csv"
            ' Create a StreamWriter to write to the file
            Using writer As New StreamWriter(csvFilePath)
                ' Write the header row with column names
                Dim columnHeaders = String.Join(",", Table.Columns.Cast(Of DataColumn)().Select(Function(col) col.ColumnName).ToArray())
                writer.WriteLine(columnHeaders)

                ' Write each row in the DataTable
                For Each row As DataRow In Table.Rows
                    ' Use quotes around each field to handle commas or special characters within values
                    Dim rowValues = String.Join(",", row.ItemArray.Select(Function(value) """" & value.ToString().Replace("""", """""") & """").ToArray())
                    writer.WriteLine(rowValues)
                Next
            End Using

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Function
    Private Function SyncDataSalesManagerCSV(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String)
        Try
            Table = PublishReport.GetSyncDataSalesManager(ConfigtypeCode, Year, Month)

            Dim csvFilePath As String = m_BasePath & "\SyncDataSalesManager.csv"
            ' Create a StreamWriter to write to the file
            Using writer As New StreamWriter(csvFilePath)
                ' Write the header row with column names
                Dim columnHeaders = String.Join(",", Table.Columns.Cast(Of DataColumn)().Select(Function(col) col.ColumnName).ToArray())
                writer.WriteLine(columnHeaders)

                ' Write each row in the DataTable
                For Each row As DataRow In Table.Rows
                    ' Use quotes around each field to handle commas or special characters within values
                    Dim rowValues = String.Join(",", row.ItemArray.Select(Function(value) """" & value.ToString().Replace("""", """""") & """").ToArray())
                    writer.WriteLine(rowValues)
                Next
            End Using

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Function
    Private Function SyncDataAgentsCSV(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String)
        Try
            Table = PublishReport.GetSyncDataAgents(ConfigtypeCode, Year, Month)

            Dim csvFilePath As String = m_BasePath & "\SyncDataAgents.csv"
            ' Create a StreamWriter to write to the file
            Using writer As New StreamWriter(csvFilePath)
                ' Write the header row with column names
                Dim columnHeaders = String.Join(",", Table.Columns.Cast(Of DataColumn)().Select(Function(col) col.ColumnName).ToArray())
                writer.WriteLine(columnHeaders)

                ' Write each row in the DataTable
                For Each row As DataRow In Table.Rows
                    ' Use quotes around each field to handle commas or special characters within values
                    Dim rowValues = String.Join(",", row.ItemArray.Select(Function(value) """" & value.ToString().Replace("""", """""") & """").ToArray())
                    writer.WriteLine(rowValues)
                Next
            End Using

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Function
    Private Function SyncDataDistrictsCSV(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String)
        Try
            Table = PublishReport.GetSyncDataDistricts(ConfigtypeCode, Year, Month)

            Dim csvFilePath As String = m_BasePath & "\SyncDataDistricts.csv"
            ' Create a StreamWriter to write to the file
            Using writer As New StreamWriter(csvFilePath)
                ' Write the header row with column names
                Dim columnHeaders = String.Join(",", Table.Columns.Cast(Of DataColumn)().Select(Function(col) col.ColumnName).ToArray())
                writer.WriteLine(columnHeaders)

                ' Write each row in the DataTable
                For Each row As DataRow In Table.Rows
                    ' Use quotes around each field to handle commas or special characters within values
                    Dim rowValues = String.Join(",", row.ItemArray.Select(Function(value) """" & value.ToString().Replace("""", """""") & """").ToArray())
                    writer.WriteLine(rowValues)
                Next
            End Using

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Function
    Private Function SyncDataSalesmatrixCSV(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String)
        Try

            Table = PublishReport.GetSyncDataSalesmatrix(ConfigtypeCode, Year, Month)

            Dim csvFilePath As String = m_BasePath & "\SyncDataSalesmatrix.csv"
            ' Create a StreamWriter to write to the file
            Using writer As New StreamWriter(csvFilePath)
                ' Write the header row with column names
                Dim columnHeaders = String.Join(",", Table.Columns.Cast(Of DataColumn)().Select(Function(col) col.ColumnName).ToArray())
                writer.WriteLine(columnHeaders)

                ' Write each row in the DataTable
                For Each row As DataRow In Table.Rows
                    ' Use quotes around each field to handle commas or special characters within values
                    Dim rowValues = String.Join(",", row.ItemArray.Select(Function(value) """" & value.ToString().Replace("""", """""") & """").ToArray())
                    writer.WriteLine(rowValues)
                Next
            End Using

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Function
    Private Function SyncDataTerritoriesCSV(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String)
        Try
            Table = PublishReport.GetSyncDataTerritories(ConfigtypeCode, Year, Month)

            Dim csvFilePath As String = m_BasePath & "\SyncDataTerritories.csv"
            ' Create a StreamWriter to write to the file
            Using writer As New StreamWriter(csvFilePath)
                ' Write the header row with column names
                Dim columnHeaders = String.Join(",", Table.Columns.Cast(Of DataColumn)().Select(Function(col) col.ColumnName).ToArray())
                writer.WriteLine(columnHeaders)

                ' Write each row in the DataTable
                For Each row As DataRow In Table.Rows
                    ' Use quotes around each field to handle commas or special characters within values
                    Dim rowValues = String.Join(",", row.ItemArray.Select(Function(value) """" & value.ToString().Replace("""", """""") & """").ToArray())
                    writer.WriteLine(rowValues)
                Next
            End Using

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Function
    Private Function SyncFinalSalesCSV(ByVal ConfigtypeCode As String, ByVal Year As String, ByVal Month As String)
        Try

            Table = PublishReport.GetSyncDataFinalSales(ConfigtypeCode, Year, Month)

            Dim csvFilePath As String = m_BasePath & "\SyncDataFinalSales.csv"
            ''Dim csvFilePath As String = ReturnExePath() & "\Report" & "\Publishing Reports\SyncDataFinalSales.csv"
            ' Create a StreamWriter to write to the file
            Using writer As New StreamWriter(csvFilePath)
                ' Write the header row with column names
                Dim columnHeaders = String.Join(",", Table.Columns.Cast(Of DataColumn)().Select(Function(col) col.ColumnName).ToArray())
                writer.WriteLine(columnHeaders)

                ' Write each row in the DataTable
                For Each row As DataRow In Table.Rows
                    ' Use quotes around each field to handle commas or special characters within values
                    Dim rowValues = String.Join(",", row.ItemArray.Select(Function(value) """" & value.ToString().Replace("""", """""") & """").ToArray())
                    writer.WriteLine(rowValues)
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value <= ProgressBar1.Maximum - 1 Then
            ProgressBar1.Value += 1
            If ProgressBar1.Value >= 100 Then
                Timer1.Enabled = False
                MsgBox("Publish Sales Successfully Export!", MsgBoxStyle.Information, "")
            End If
        End If
    End Sub
End Class