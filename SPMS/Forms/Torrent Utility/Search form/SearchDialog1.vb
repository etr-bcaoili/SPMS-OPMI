Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports SPMSOPCI.ConnectionModule
Public Class SearchDialog1

    Private dt As New DataTable
    Private strTableName As String = ""
    Private strColumns As String = ""
    Private strCondition As String = ""
    Private strQuery As String = ""
    Private strKeyColumn As String = ""
    Private strKeyColumn1 As String = ""
    Private strKeyColumn2 As String = ""
    Private strKeyColumn4 As String = ""
    Private strKeyColumn5 As String = ""
    'edited by: Bordonada Michael Xernan A. 
    'on: June 3 2010

    Private strKeyColumn3 As String = "'"


    Private strFormName As String = "Search"

    Private m_ConnectionID As ADODB.Connection = ConnectionModule.SPMSConn

    Public Property ConnectionID() As ADODB.Connection
        Get
            Return m_ConnectionID
        End Get
        Set(ByVal value As ADODB.Connection)
            m_ConnectionID = value
            If Not SPMSConn.State = 1 Then
                SPMSOPCI.ConnectionModule.SPMSConn.Open()
            End If

        End Set
    End Property

    Public ReadOnly Property Keycolumn() As String
        Get
            Return strKeyColumn
        End Get
    End Property


    Public ReadOnly Property Keycolumn1() As String
        Get
            Return strKeyColumn1
        End Get
    End Property


    Public ReadOnly Property Keycolumn2() As String
        Get
            Return strKeyColumn2
        End Get
    End Property

    Public ReadOnly Property Keycolumn3() As String
        Get
            Return strKeyColumn3
        End Get
    End Property
    Public ReadOnly Property KeyColumn4() As String
        Get
            Return strKeyColumn4
        End Get
    End Property
    Public ReadOnly Property KeyColumn5() As String
        Get
            Return strKeyColumn5
        End Get
    End Property


    Public Property TableName() As String
        Get
            Return strTableName
        End Get
        Set(ByVal value As String)
            strTableName = value
        End Set
    End Property

    Public Property TableColumns() As String
        Get
            Return strColumns
        End Get
        Set(ByVal value As String)
            strColumns = value
        End Set
    End Property

    Public WriteOnly Property FormName() As String
        Set(ByVal value As String)
            strFormName = value
        End Set
    End Property

    Private Sub SearchDialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer

        FilterRows()
        Me.Text = strFormName
        cboColumns.Items.Clear()
        cboFieldName.Items.Clear()
        'cboColumns.Items.Add("All")
        'cboFieldName.Items.Add("All")
        For i = 1 To dgData.Columns.Count - 1
            cboColumns.Items.Add(dgData.Columns(i).Name)
        Next
        cboColumns.Text = ""
        Dim sCols() As String = strColumns.Trim.Split(";")
        For j As Integer = 0 To sCols.Length - 1
            cboFieldName.Items.Add(sCols(j))
        Next

        ApplyGridTheme(Me.dgData)
        'Do While strColumns <> ""
        '    cboFieldName.Items.Add(Mid(strColumns, 1, InStr(1, strColumns, ";") - 1))
        '    strColumns = Mid(strColumns, InStr(1, strColumns, ";") + 1, Len(strColumns))
        'Loop
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        SelectItem()
    End Sub

    Private Sub SelectItem()
        If dgData.SelectedRows.Count > 0 Then
            strKeyColumn = dgData.SelectedRows(0).Cells(0).Value
            If dgData.ColumnCount > 1 Then
                strKeyColumn1 = dgData.SelectedRows(0).Cells(1).Value
            Else
                strKeyColumn1 = ""
            End If
            If dgData.ColumnCount > 2 Then
                strKeyColumn2 = dgData.SelectedRows(0).Cells(2).Value
            Else
                strKeyColumn2 = ""
            End If
            If dgData.ColumnCount > 3 Then
                strKeyColumn3 = dgData.SelectedRows(0).Cells(3).Value
            Else
                strKeyColumn3 = ""
            End If
            If dgData.ColumnCount > 4 Then
                strKeyColumn4 = dgData.SelectedRows(0).Cells(4).Value
            Else
                strKeyColumn4 = ""
            End If
            If dgData.ColumnCount > 5 Then
                strKeyColumn5 = dgData.SelectedRows(0).Cells(5).Value
            Else
                strKeyColumn5 = ""
            End If
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub dgData_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgData.DoubleClick
        SelectItem()
    End Sub

    Private Sub txtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged

        Dim i As Integer
        Dim strOperator As String

        If cboCondition.Items.IndexOf(cboCondition.Text) = 0 Then
            strOperator = "Like"
        ElseIf cboCondition.Items.IndexOf(cboCondition.Text) = 1 Then
            strOperator = "="
        ElseIf cboCondition.Items.IndexOf(cboCondition.Text) = 2 Then
            strOperator = ">="
        ElseIf cboCondition.Items.IndexOf(cboCondition.Text) = 3 Then
            strOperator = "<="
        Else
            strOperator = "<>"
        End If

        strCondition = ""
        If txtCode.Text = "" Then
            strCondition = ""
        Else
            If strTableName.ToUpper.IndexOf("WHERE") = -1 Then
                strCondition &= " WHERE "
            Else
                strCondition &= " "
            End If


            If cboFieldName.Text = "All" Then
                For i = 1 To cboFieldName.Items.Count - 1
                    If strCondition = "" OrElse Trim(strCondition) = "WHERE" Then
                        strCondition &= "  CAST(" + cboFieldName.Items.Item(i) + " AS VARCHAR(250))  " + strOperator + " " + Chr(39) + HandleSingleQuoteInSql(txtCode.Text) + IIf(strOperator = "Like", "%", "") + Chr(39)
                    Else
                        If strCondition = " " Then
                            strCondition = strCondition + " and CAST(" + cboFieldName.Items.Item(i) + " AS VARCHAR(250)) " + strOperator + " " + Chr(39) + HandleSingleQuoteInSql(txtCode.Text) + IIf(strOperator = "Like", "%", "") + Chr(39)
                        Else
                            strCondition = strCondition + IIf(cboFieldName.Items.Item(i) <> "", " OR CAST(" + cboFieldName.Items.Item(i) + " AS VARCHAR(250)) " + strOperator + " " + Chr(39) + HandleSingleQuoteInSql(txtCode.Text) + IIf(strOperator = "Like", "%", "") + Chr(39), "")
                        End If

                    End If
                Next
            Else
                If strCondition = "" Then
                    strCondition &= IIf(cboFieldName.Text <> "", " CAST(" + cboFieldName.Text + " AS VARCHAR(250)) ", "") + strOperator + " " + Chr(39) + HandleSingleQuoteInSql(txtCode.Text) + IIf(strOperator = "Like", "%", "") + Chr(39)
                Else
                    '  strCondition &= IIf(cboFieldName.Text <> "", " AND CAST(" + cboFieldName.Text + " AS VARCHAR(250)) ", "") + strOperator + " " + Chr(39) + HandleSingleQuoteInSql(txtCode.Text) + IIf(strOperator = "Like", "%", "") + Chr(39)
                End If

            End If
        End If
        FilterRows()

    End Sub

    Public Sub FilterRows()
        '
        Dim strFilter As String = strTableName + strCondition
        Dim rs As New ADODB.Recordset
        rs.Open(strFilter, SPMSOPCI.ConnectionModule.SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Try

            Dim da As New OleDb.OleDbDataAdapter

            dt.Clear()
            da.Fill(dt, rs)
            dgData.DataSource = dt
            dgData.Refresh()
            'dgData.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgData.Columns(0).Visible = False

            'dgData.Columns(0).Visible = True


        Catch ex As Exception
            ShowInformation(ex.Message, "Search error")
        End Try
    End Sub

    Private Sub txtDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FilterRows()
    End Sub

    Private Sub cboColumns_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboColumns.SelectedIndexChanged

        Dim returnValue As Integer
        returnValue = cboColumns.Items.IndexOf(cboColumns.Text)
        cboFieldName.Text = cboFieldName.Items.Item(returnValue + 0)

    End Sub

    Private Sub btnCancel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgData.KeyPress, cboColumns.KeyPress, cboFieldName.KeyPress, txtCode.KeyPress
        If Asc(e.KeyChar) = 27 Then
            DialogResult = Windows.Forms.DialogResult.No
            Me.Close()
        End If
    End Sub

    Private Sub dgData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgData.CellContentClick

    End Sub
End Class
