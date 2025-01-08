Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Imports System.IO
Public Class ucUploader
    Private Sub PopulateComboBox()
        Dim rs As New ADODB.Recordset
        cmbcompany.Items.Clear()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM DISTRIBUTOR WHERE /*DISTCOMID <> '" & "WAT" & "' AND*/ DLTFLG = 0", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            For i = 1 To rs.RecordCount
                cmbcompany.Items.Add(rs.Fields("DISTCOMID").Value)
                rs.MoveNext()
            Next i

        End If
    End Sub

    Private Sub TransactionUploadSelection_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PopulateComboBox()
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cmbcompany.Text = "" Then

        ElseIf cmbcompany.Text = "MDI" Then
            If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\MDI.exe") = True Then

                Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\MDI.exe", AppWinStyle.NormalFocus)
            End If
        ElseIf cmbcompany.Text = "MER" Then
            If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Mercury.exe") = True Then

                Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Mercury.exe", AppWinStyle.NormalFocus)
            End If
        ElseIf cmbcompany.Text = "GPI" Then
            If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\GPI.exe") = True Then

                Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\GPI.exe", AppWinStyle.NormalFocus)
            End If
        ElseIf cmbcompany.Text = "INH" Then
            If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\INH.exe") = True Then

                Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\INH.exe", AppWinStyle.NormalFocus)
            End If
        ElseIf cmbcompany.Text = "WAT" Then
            If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Watsons.exe") = True Then

                Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Watsons.exe", AppWinStyle.NormalFocus)
            End If
            'ElseIf cmbcompany.Text = "18" Then
            '    Dim RawData As New frmRawDataUploader
            '    RawData.ShowDialog()
        End If
    End Sub

    Private Sub cmbcompany_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcompany.Click
        
    End Sub

    Private Sub cmbcompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcompany.SelectedIndexChanged
            End Sub

    Private Sub lblClose_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub lblSelect_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblSelect.LinkClicked
        If cmbcompany.Text = "" Then

        ElseIf cmbcompany.Text = "MDI" Then
            If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\MDI.exe") = True Then
                Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\MDI.exe")
                'Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\MDI.exe", AppWinStyle.NormalFocus)
            End If
        ElseIf cmbcompany.Text = "MER" Then
            If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Mercury.exe") = True Then
                Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Mercury.exe")

                'Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Mercury.exe", AppWinStyle.NormalFocus)
            End If
        
        ElseIf cmbcompany.Text = "INH" Then
            If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\INH.exe") = True Then
                Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\INH.exe")
                'Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\INH.exe", AppWinStyle.NormalFocus)
            End If
        ElseIf cmbcompany.Text = "WAT" Then
            If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Watsons.exe") = True Then
                Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Watsons.exe")
                'Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Watsons.exe", AppWinStyle.NormalFocus)
            End If
        ElseIf cmbcompany.Text = "SSD" Then
            If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\INH.exe") = True Then
                Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\INH.exe")
                'Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Watsons.exe", AppWinStyle.NormalFocus)
            End If
            'ElseIf cmbcompany.Text = "18" Then
           
        Else

            If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\INH.exe") = True Then
                Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\INH.exe")
                'Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\INH.exe", AppWinStyle.NormalFocus)
            End If
            'Dim RawData As New frmRawDataUploader
            'RawData.ShowDialog()
            End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
End Class
