Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ErrorMessagesModule

Public Class UserLogin
    Private b_UserName As String = ""
    Private HasError As New ErrorProvider


    Public Property Username() As String
        Get
            Return b_UserName
        End Get
        Set(ByVal value As String)
            b_UserName = value
        End Set
    End Property

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        Accept()
    End Sub

    Private Sub Accept()
        Dim rs As New ADODB.Recordset

        If ValidFields() = False Then
        ElseIf UserExists() = False Then
        ElseIf CorrectPassword() = False Then
        Else
            rs = rsUserAccess("UserName = '" & txtuser.Text & "' AND Password = '" & txtPass.Text & "' ")
            If rs.RecordCount > 0 Then
                If rs.Fields("isActive").Value = 0 Then
                    Username = txtuser.Text
                    Me.Dispose()
                Else
                    'UserinUse()
                    Fixuser()
                End If

            End If
        End If
    End Sub

    Private Sub Fixuser()
        On Error GoTo ErrorHandler
        SPMSConn.Execute("UPDATE UserAccess SET IsActive= 0 WHERE UserName = '" & txtuser.Text & "' AND Password = '" & txtPass.Text & "' AND DLTFLG = 0")
        Exit Sub
ErrorHandler:
        ShowInformation("Error: " & Err.Number & " - " & Err.Description, "Error")
    End Sub

    Private Function CorrectPassword() As Boolean
        Dim rs As New ADODB.Recordset
        rs = rsUserAccess("UserName = '" & txtuser.Text & "' AND Password = '" & txtPass.Text & "' ")
        If rs.RecordCount > 0 Then
            Return True
        Else
            VDialog.Show("Access Invalid password", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
    End Function

    Private Function UserExists() As Boolean
        Dim rs As New ADODB.Recordset
        rs = rsUserAccess("UserName = '" & txtuser.Text & "' ")
        If rs.RecordCount > 0 Then
            Return True
        Else
            VDialog.Show("Access Invalid username", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
    End Function

    Private Function ValidFields() As Boolean
        Dim Err As Boolean = False

        HasError.Clear()

        If txtuser.Text = "" Then
            HasError.SetError(txtuser, "Username must not be blank")
            Err = True
        End If

        If txtPass.Text = "" Then
            HasError.SetError(txtPass, "Password must not be blank")
            Err = True
        End If


        Return Not Err
    End Function

    Private Function rsUserAccess(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If



        rs.Open("SELECT * FROM USERACCESS WHERE DLTFLG = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs

    End Function

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim q As MsgBoxResult
        q = VDialog.Show("Are you sure you want to exit?", "Exit-Login ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If q = MsgBoxResult.Yes Then
            End
        End If
    End Sub

    Private Sub txtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPass.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Accept()
        End If
    End Sub

    Private Sub txtPass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPass.TextChanged

    End Sub

    Private Sub lblUnlock_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblUnlock.LinkClicked
        UserStatusReset.ShowDialog()
    End Sub

    Private Sub txtuser_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtuser.TextChanged

    End Sub

    Private Sub UserLogin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt And e.KeyCode = Keys.F4 Then
            e.Handled = True
        ElseIf e.Control And e.KeyCode = Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub UserLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.KeyPreview = True
    End Sub
End Class