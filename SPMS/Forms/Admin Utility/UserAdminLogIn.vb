Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.GlobalFunctionsModule
Public Class UserAdminLogIn
    Private b_Status As Boolean

    Public Property Status() As Boolean
        Get
            Return b_Status
        End Get
        Set(ByVal value As Boolean)
            b_status = value
        End Set
    End Property


    Private Sub ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click, btnClose.Click
        If sender Is btnAccept Then
            If txtuser.Text <> "ETR" Then
                IncorrectUser()
                b_Status = False
            ElseIf txtPass.Text <> "@pr!l!62oo6" Then
                IncorrectPassword()
                b_Status = False
            Else
                b_Status = True
                LoginSuccess()
                Me.Dispose()


                'MainWindow.TabControl1.TabPages.Add(MainWindow.TabControl1.TabPages.Count)
                'Dim mine As New UCScriptUpdater
                'mine.Width = Me.Width
                'mine.Height = MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Height - 30
                'MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Text = mine.Name
                'MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Controls.Add(mine)
                'MainWindow.TabControl1.TabPages(MainWindow.TabControl1.TabPages.Count - 1).Text = "Script Updater"
                'MainWindow.TabControl1.SelectTab(MainWindow.TabControl1.TabPages.Count - 1)
            End If
        ElseIf sender Is btnClose Then
            Me.Dispose()

        End If

    End Sub
End Class