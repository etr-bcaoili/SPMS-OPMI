
Module InformationMessagesModule
    'place all message box for the information messages


    Public Sub SaveSuccess()
        'message will be used for a 
        ShowInformation("Record Successfully Saved", "")
    End Sub
    Public Sub SaveSuccessCopyFrom()
        'message will be used for a 
        ShowInformation("Record Successfully Saved", "")
    End Sub
    Public Sub InsertSC03()
        'message will be used for a 
        ShowInformation("Record Successfully Shared Item", "Shared Item")
    End Sub
    Public Sub TransferSuccess()
        'message will be used for a 
        ShowInformation("Record Successfully Transfers", "Source Data Pivot")
    End Sub
    Public Sub TransferSuccessDeleted()
        'message will be used for a 
        ShowInformation("Record Successfully Transfers", "Source Data Pivot")
    End Sub
    Public Sub CompyFromPriceSuccess()
        'message will be used for a 
        ShowInformation("Price Record Successfully Copy from", "")
    End Sub
    Public Sub UploadSuccess()
        ShowInformation("Record Successfully Upload", "Uploading...")
    End Sub
    Public Sub UnUploadSuccess()
        ShowExclamation("Record not Uploaded", "Uploading...")
    End Sub
    Public Sub UnSuccesSave()
        ShowExclamation("Record not Saved.", "Save")
    End Sub
    Public Sub DeleteSuccess()
        ShowInformation("Record Successfully Deleted", "Delete")
    End Sub
    Public Sub ItemModifiedsalesSuccess()
        ShowInformation("Record Successfully Item Modified Sales", "Updated")
    End Sub
    Public Sub UnItemModifiedsalesSuccess()
        ShowExclamation("Record not Change.", "Invalid Update")
    End Sub
    Public Sub UnDeleteSuccess()
        ShowExclamation("Record not deleted.", "Delete")
    End Sub
    Public Sub ChannelFind()
        ShowInformation("Plase Select the Channel before find the Customer list", "Find Customer")
    End Sub
    Public Sub CustomerProponent()
        ShowExclamation("Warning Customer Code and Proponent is invalid ", "Invalid Selected")
    End Sub
    Public Sub ChannelItemPrice()
        ShowExclamation("Warning Channel Item Price parameter  is missing Value please Check it already recorded ", "Invalid parameter")
    End Sub
    Public Sub ShowQuestion1()
        ShowQuestion("Are you sure you want to delete this record?", "Delete")
    End Sub
    Public Sub EntryHasReference()
        ShowInformation("Delete Operation Cannot be completed: Record is already Referenced", "")
    End Sub
    Public Sub ShowExclamationCompleteDetails()
        ShowExclamation("Please Select the Details", "Invalid parameter")
    End Sub
    Public Sub ConnectionSuccess()
        ShowInformation("Connection to the server Succeeded", "Connection Success")
    End Sub

    'place all message box code for the question
    Public Function ConfirmExit() As MsgBoxResult
        Return ShowQuestion("Are you sure you want to exit?", "")
    End Function

    Public Sub LoginSuccess()
        ShowInformation("Login Success", "Successfully Logged in")
    End Sub
    Public Function ConfirmCloseofTransaction() As MsgBoxResult
        Return ShowQuestion("Are you sure you want to close this Transaction", "Close Transaction")
    End Function
    Public Sub PartialUpdate()
        ShowInformation("Update of records were Partially done Because some of them is locked", "Partial Update done")
    End Sub
   
   
End Module
