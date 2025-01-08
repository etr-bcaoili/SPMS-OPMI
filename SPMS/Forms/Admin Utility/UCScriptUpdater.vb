Imports System.IO
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.GlobalFunctionsModule
Public Class UCScriptUpdater
  
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'OD.ShowDialog()
        Dim FileName As String = ""
        FolderBrowserDialog1.ShowDialog()
        txtDirectory.Text = FolderBrowserDialog1.SelectedPath
        'If OD.FileName <> "" Then
        '    Dim di As New IO.DirectoryInfo(FolderBrowserDialog1.SelectedPath)
        '    Dim diar1 As IO.FileInfo() = di.GetFiles()
        '    Dim dra As IO.FileInfo

        '    'list the names of all files in the specified directory
        '    For Each dra In diar1
        '        'ListBox1.Items.Add(dra)
        '        FileName = dra.FullName


        '    Next
        'End If

    End Sub


  

    Private Sub ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click, btnClose.Click

        If sender Is btnUpdate Then
            On Error Resume Next
            If OD.FileName <> "" Then

                Dim FileName As String = ""
                Dim di As New IO.DirectoryInfo(txtDirectory.Text)
                Dim diar1 As IO.FileInfo() = di.GetFiles()
                Dim dra As IO.FileInfo

                'list the names of all files in the specified directory
                For Each dra In diar1
                    'ListBox1.Items.Add(dra)
                    FileName = dra.FullName
                    If FileName <> "" Then

                        SPMSConn.Execute(GetTextFileContent(FileName))



                    End If

                Next
                ShowInformation("Script Update Complete", "Update Complete")
            End If
        ElseIf sender Is btnClose Then
            On Error Resume Next
            Dim m_TabPage As TabPage = Me.Parent
            CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
            Me.Dispose()
        End If


    End Sub
End Class
