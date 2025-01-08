Option Explicit On
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule

Public Class UCResetPassword
    Private Function RsLockedUser(Optional ByVal Filter As String = "", Optional ByVal OrderBy As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If
        If OrderBy <> "" Then
            OrderBy = " ORDER BY " & OrderBy
        End If
        rs.Open("select * from useraccess where dltflg = 0 " & Filter & OrderBy, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function

    Private Function RsUser(Optional ByVal Filter As String = "", Optional ByVal Orderby As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " and " & Filter
        End If
        If Orderby <> "" Then
            Orderby = " ORDER BY " & Orderby
        End If
        rs.Open("select * from useraccess where dltflg = 0 " & Filter & Orderby, SPMSConn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Return rs
    End Function

    Private Sub Clearform()
        cmbUserName.SelectedIndex = -1
        txtPass.Text = ""
    End Sub

    Private Sub PopulateComboBox()
        Dim rs As New ADODB.Recordset
        rs = RsLockedUser()
        cmbUserName.Items.Clear()
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbUserName.Items.Add(rs.Fields("UserName").Value)
                rs.MoveNext()
            Next
        End If
    End Sub

    Private Function ValidFields() As Boolean
        If cmbUserName.Text = "" Then
            ShowExclamation("Please select a user", "No user selected")
            Return False
        ElseIf txtPass.Text = "" Then
            ShowExclamation("Password should not be empty", "Empty password")
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub UCResetPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateComboBox()
        Clearform()
    End Sub



    Private Sub ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click, btnClose.Click
        If sender Is btnAccept Then
            If ValidFields() = True Then
                Dim rs As ADODB.Recordset = RsUser("username = '" & cmbUserName.Text & "'")
                If rs.RecordCount > 0 Then
                    rs.Fields("Password").Value = txtPass.Text
                    rs.Update()
                    SaveSuccess()
                    Clearform()
                End If
            End If
        ElseIf sender Is btnClose Then
            On Error Resume Next
            Dim m_TabPage As TabPage = Me.Parent
            CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
            Me.Dispose()
        End If
    End Sub
End Class
