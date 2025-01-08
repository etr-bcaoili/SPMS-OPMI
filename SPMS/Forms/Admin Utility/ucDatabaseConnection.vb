Imports ETRSKL.SerialNumbers
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.GlobalFunctionsModule
Imports System.IO

Public Class ucDatabaseConnection
    Private MasterCnn As New ADODB.Connection
    Private Cnn As New ADODB.Connection
    Private Sub PopulateComboBoxes()
        Dim rs As New ADODB.Recordset
        rs = RsDatabase()
        cmbDatabases.Items.Clear()
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbDatabases.Items.Add(rs.Fields("name").Value)
                rs.MoveNext()
            Next
        End If
    End Sub

    Private Sub CnnConnect()
        On Error GoTo errorhandler
        If Cnn.State = 1 Then Cnn.Close()
        Cnn.Open("Provider=SQLOLEDB.1;Persist Security Info=False;User ID=" & txtUsername.Text & "; Password = " & txtPassword.Text & ";Initial Catalog=" & cmbDatabases.Text & ";Data Source=" & txtServer.Text)

        Exit Sub

errorhandler:
        ConnectionFailed()
        Err.Clear()
    End Sub

    Private Sub ConnectMaster()
        On Error GoTo ErrorHandler
        If MasterCnn.State = 1 Then MasterCnn.Close()
        MasterCnn.Open("Provider=SQLOLEDB.1;Persist Security Info=False;User ID=" & txtUsername.Text & "; Password = " & txtPassword.Text & ";Initial Catalog=MASTER;Data Source=" & txtServer.Text)
        ConnectionSuccess()
        Exit Sub
ErrorHandler:
        ConnectionFailed()
        Err.Clear()
    End Sub

    Private Function RsDatabase() As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        rs.Open("select name from sysdatabases ", MasterCnn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs

    End Function

    Private Sub buttonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheck.Click, btnConnect.Click, btnClose.Click
        If sender Is btnCheck Then
            ConnectMaster()

            If MasterCnn.State = 1 Then
                PopulateComboBoxes()

            End If
        ElseIf sender Is btnConnect Then

            Dim checker As New ETRSKL.SerialNumbers
           ' If checker.ValidSerial(txtSerial.Text) = True Then



                CnnConnect()
                If Cnn.State = 1 Then
                    Dim Connection As String = "'"
                    Dim SqlConnection As String = ""
                    Connection = "Provider=SQLOLEDB.1;Persist Security Info=False;User ID=" & txtUsername.Text & "; Password = " & txtPassword.Text & ";Initial Catalog=" & cmbDatabases.Text & ";Data Source=" & txtServer.Text
                    Connection = Encrypts(Connection, 22)
                    SqlConnection = Encrypts("data source=" & txtServer.Text & "; initial catalog=" & cmbDatabases.Text & "; user id=" & txtUsername.Text & "; password=" & txtPassword.Text & ";", 22)
                    WriteToFile(Connection, System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Connections\DBConn.txt")
                    WriteToFile(SqlConnection, System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Connections\SqlConn.txt")
                    If OpenConnection() <> True Then
                        ConnectionFailed()
                    Else
                        On Error Resume Next
                        Dim m_TabPage As TabPage = Me.Parent
                        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
                        Me.Dispose()
                    End If
                End If
            'Else
            'ShowInformation("Serial Not valid", "Invalid Serial")
            'End If

        ElseIf sender Is btnClose Then
            On Error Resume Next
            Dim m_TabPage As TabPage = Me.Parent
            CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
            Me.Dispose()
        End If

    End Sub

    Private Sub WriteToFile(ByVal StringtoWrite As String, ByVal FilePath As String)

        Dim textfile As New StreamWriter(FilePath)

        textfile.WriteLine(StringtoWrite)
        textfile.Close()


    End Sub

    Private Sub ucDatabaseConnection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerial.TextChanged

    End Sub
End Class
