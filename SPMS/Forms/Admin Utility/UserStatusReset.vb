Option Explicit On
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ErrorMessagesModule


Public Class UserStatusReset
    Private Sub ClearFields()
        txtuser.Text = ""
        txtPass.Text = ""
    End Sub

    Private Function LockedUserAccess(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If
        rs.Open("select * from useraccess where dltflg = 0  " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function

    Private Function userAccess(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If
        rs.Open("select * from useraccess  where dltflg = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Return rs
    End Function

    Private Sub ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click, btnclose.Click
        If sender Is btnAccept Then
            PerformOperation()
        ElseIf sender Is btnclose Then
            If ConfirmExit() = MsgBoxResult.Yes Then
                Me.Close()
            End If
        End If

    End Sub

    Private Sub PerformOperation()
        If UserExists() = False Then
            IncorrectUser()
        ElseIf PasswordExists() = False Then
            IncorrectPassword()
        Else
            Fixuser()
            SaveSuccess()
            ClearFields()
        End If
    End Sub

    Private Function UserExists() As Boolean
        Dim rs As New ADODB.Recordset
        rs = LockedUserAccess("UserName = '" & txtuser.Text & "' ")
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function PasswordExists() As Boolean
        Dim rs As New ADODB.Recordset
        rs = LockedUserAccess("userName = '" & txtuser.Text & "' and password = '" & txtPass.Text & "'  ")
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Fixuser()
        On Error GoTo ErrorHandler
        SPMSConn.Execute("UPDATE UserAccess SET IsActive= 0 WHERE UserName = '" & txtuser.Text & "' AND Password = '" & txtPass.Text & "' AND DLTFLG = 0")
        Exit Sub
ErrorHandler:
        ShowInformation("Error: " & Err.Number & " - " & Err.Description, "Error")
    End Sub

    Private Sub UserStatusReset_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ClearFields()
    End Sub

    Private Sub txtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPass.KeyPress
        If Asc(e.KeyChar) = 13 Then
            PerformOperation()
        End If
    End Sub

End Class

