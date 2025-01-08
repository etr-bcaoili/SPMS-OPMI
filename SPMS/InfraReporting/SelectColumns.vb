Public Class SelectColumns
    Private v_TableName As String = String.Empty

    Private v_SqlColumns As String = String.Empty

    Private v_SqlQuery As String = String.Empty

    Public Property TableName() As String
        Get
            Return v_TableName
        End Get
        Set(ByVal value As String)
            v_TableName = value
        End Set
    End Property

    Public ReadOnly Property SqlColumns() As String
        Get
            Return v_SqlColumns
        End Get
    End Property

    Public ReadOnly Property SqlQuery() As String
        Get
            Return v_SqlQuery
        End Get
    End Property

    Private Sub JButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JButton1.Click
        Dim v_sqlCol As String = String.Empty
        Dim v_SqlQu As String = String.Empty
        For i As Integer = 0 To dgTableColumns.Rows.Count - 1
            Dim row As DataGridViewRow = dgTableColumns.Rows(i)
            Dim chk As DataGridViewCheckBoxCell = row.Cells(colSelect.Index)
            If chk.Value = True Then
                v_sqlCol = v_sqlCol & IIf(v_sqlCol = String.Empty, row.Cells(colName.Index).Value, "; " & row.Cells(colName.Index).Value)
                v_SqlQu = v_SqlQu & IIf(v_SqlQu = String.Empty, row.Cells(colName.Index).Value, ", " & row.Cells(colName.Index).Value) & IIf(row.Cells(colAlias.Index).Value = String.Empty, "", " [" & row.Cells(colAlias.Index).Value & "] ")
            End If
        Next

        v_SqlColumns = IIf(v_sqlCol = String.Empty, "Select Columns.", "Select " & v_SqlQu & " From " & v_TableName)
        v_SqlQuery = IIf(v_sqlCol = String.Empty, "", "Select " & v_SqlQu & " From " & v_TableName)
        Me.Close()
    End Sub

    Private Sub SelectColumns_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Althea.Base.UI.Utilities.ApplyGridTheme(dgTableColumns)
        dgTableColumns.AutoGenerateColumns = False

        dgTableColumns.DataSource = InfraReporting.GetTableColumns(v_TableName)
    End Sub
End Class