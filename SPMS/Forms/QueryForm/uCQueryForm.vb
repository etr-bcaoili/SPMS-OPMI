Imports SPMSOPCI.ConnectionModule
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class uCQueryForm
    Shared Sub Main()
        Dim form1 As Form = New Form1
        Application.Run(form1)
    End Sub

    Private Sub btnfinalize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfinalize.Click
        ' Clear list view column headers and items
        Result.Columns.Clear()
        Result.Items.Clear()

        ' Get SQL Query from textbox
        Dim sql As String = SQLselect.Text

        ' Create Command object
        Dim NewQuery As New SqlCommand(sql, SPMSConn2)

        Try
            ' Open Connection
            SPMSConn2.Open()

            ' Execute Command and Get Data 
            Dim NewReader As SqlDataReader = NewQuery.ExecuteReader()

            ' Get column names for list view from data reader
            For i As Integer = 0 To NewReader.FieldCount - 1
                Dim header As New ColumnHeader
                header.Text = NewReader.GetName(i)
                Result.Columns.Add(header)
            Next

            ' Get rows of data and show in list view
            While NewReader.Read()
                ' Create list view item
                Dim NewItem As New ListViewItem

                ' Specify text and subitems of list view
                NewItem.Text = NewReader.GetValue(0).ToString()
                For i As Integer = 1 To NewReader.FieldCount - 1
                    NewItem.SubItems.Add(NewReader.GetValue(i).ToString())
                Next

                ' Add item to list view items collection
                Result.Items.Add(NewItem)
            End While

            ' Close data reader
            NewReader.Close()

        Catch ex As SqlException
            ' Create and error column header
            Dim ErrorHeader As New ColumnHeader
            ErrorHeader.Text = "SQL Error"
            Result.Columns.Add(ErrorHeader)

            ' Add Error List Item
            Dim ErrorItem As New ListViewItem(ex.Message)
            Result.Items.Add(ErrorItem)

        Catch ex As Exception
            ' Create and error column header
            Dim ErrorHeader As New ColumnHeader
            ErrorHeader.Text = "Error"
            Result.Columns.Add(ErrorHeader)

            ' Add Error List Item
            Dim ErrorItem As New ListViewItem("An error has occurred")
            Result.Items.Add(ErrorItem)

        Finally

            SPMSConn2.Close()

        End Try
    End Sub
End Class
