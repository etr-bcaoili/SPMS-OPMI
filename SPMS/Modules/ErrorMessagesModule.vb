Imports SPMSOPCI.GlobalFunctionsModule
Module ErrorMessagesModule
    'space below is for level 1 error messages
    'place the Error Number and the message for that kind of error
    Public Sub ConnectionFailed()
        ShowExclamation("Database Connection Failed", "Connection Failed")
    End Sub

    Public Sub RecordExists()
        ShowExclamation("Record Already Exists", "Record Exists")
    End Sub

    Public Sub RecordInexist()
        ShowExclamation("Record Does not Exist", "Record not Existing")
    End Sub

    Public Sub InvalidValues()
        ShowExclamation("Values are not valid", "Invalid Value")
    End Sub

    Public Sub NothingSelected()
        ShowExclamation("There is nothing selected", "Nothing Selected")
    End Sub
    'for level 2 error messages
    'place the Error Number and the message for that kind of error



    'for level 3 error messages
    'place the Error Number and the message for that kind of error
    Public Sub IncorrectUser()
        ShowInformation("User Name Incorrect", "User name is Incorrect")
    End Sub

    Public Sub IncorrectPassword()
        ShowInformation("Password Incorrect", "Password is Incorrect")
    End Sub

    Public Sub UserinUse()
        ShowExclamation("User is Already in Use", "User in Use")
    End Sub
    Public Sub UserNotFound()
        ShowExclamation("User does not Exist", "User not found")
    End Sub
End Module
