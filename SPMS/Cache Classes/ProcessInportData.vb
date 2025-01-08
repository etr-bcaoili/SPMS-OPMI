Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Module ProcessInportData
    Private _FileNameSales As String = String.Empty

    Public Property FinalNameSales As String
        Get
            Return _FileNameSales
        End Get
        Set(value As String)
            _FileNameSales = value
        End Set
    End Property

    Sub Main()
        If File.Exists(ReturnExePath() & "Report" & "\Publishing Reports" & "\" & FinalNameSales & ".csv") Then

            Dim filePath As String = ReturnExePath() & "Report" & "\Publishing Reports" & "\" & FinalNameSales & ".csv"
            Dim connectionString As String = "Data Source=LAPTOP-DELL011\SQL2022;Initial Catalog=SPMSOPCIY2024_TEST2;User ID=sa;Password=Etr@2024"
            Dim tableName As String = "FinalSales"
            Dim dataTable As DataTable = LoadCsvIntoDataTable(filePath)

            If dataTable IsNot Nothing Then
                BulkInsertDataTable(dataTable, tableName, connectionString)
                Console.WriteLine("Data import completed successfully.")
            Else
                Console.WriteLine("No data to import.")
            End If
        End If
    End Sub
    Private Function LoadCsvIntoDataTable(csvFilePath As String) As DataTable
        Dim dataTable As New DataTable()

        Try
            Using parser As New TextFieldParser(csvFilePath)
                parser.TextFieldType = FieldType.Delimited
                parser.SetDelimiters(",")

                Dim headers As String() = parser.ReadFields()
                For Each header As String In headers
                    dataTable.Columns.Add(New DataColumn(header, GetType(String)))
                Next

                While Not parser.EndOfData
                    Dim fields As String() = parser.ReadFields()
                    dataTable.Rows.Add(fields)
                End While
            End Using
            Console.WriteLine("CSV data loaded into DataTable.")
        Catch ex As Exception
            Console.WriteLine("An error occurred while loading CSV data: " & ex.Message)
        End Try

        Return dataTable
    End Function
    Private Sub BulkInsertDataTable(dataTable As DataTable, tableName As String, connectionString As String)
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()


                Using bulkCopy As New SqlBulkCopy(connection)
                    bulkCopy.DestinationTableName = tableName
                    bulkCopy.BatchSize = 1000
                    bulkCopy.WriteToServer(dataTable)
                End Using
            End Using

            Console.WriteLine("DataTable bulk-inserted into SQL table successfully.")
        Catch ex As Exception
            Console.WriteLine("An error occurred during bulk insert: " & ex.Message)
        End Try
    End Sub
End Module
