Attribute VB_Name = "SQLConnection"
Public cnn As ADODB.Connection
Public Function GetSQLSMSConnection() As String
    Dim fso As New FileSystemObject
    Dim ts As TextStream
    If fso.FileExists(App.Path & "\UploaderSetup.txt") = True Then
        Set ts = fso.OpenTextFile(App.Path & "\UploaderSetup.txt", ForReading)
            GetSQLSMSConnection = ts.ReadAll
        Set ts = Nothing
    Else
        GetSQLSMSConnection = Empty
        Exit Function
    End If
End Function
Public Sub SQLConnect()
    
    Set cnn = New ADODB.Connection
        cnn.CursorLocation = adUseClient
        cnn.Open GetSQLSMSConnection
    
End Sub
