Imports System.Windows.Forms
Imports SPMSOPCI.ConnectionModule
Public Class Dialogs
    Public Shared Function ShowSearchDialog(ByVal SqlString As String, Optional ByVal FormName As String = "Search") As SelectionTags
        Dim m_Search As New SearchDialog
        m_Search.Query = SqlString
        If m_Search.ShowDialog = DialogResult.OK Then
            Dim m_Tags As New SelectionTags(m_Search.Keycolumn, m_Search.Keycolumn1, m_Search.Keycolumn2, m_Search.Keycolumn3, m_Search.Keycolumn4)
            Return m_Tags
        Else
            Return Nothing
        End If
        Return Nothing
    End Function
    Public Shared Sub ShowInformation(ByVal Message As String, ByVal Caption As String)
        MessageBox.Show(Message, Caption, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Shared Function ShowQuestionBox(ByVal Message As String, ByVal Caption As String) As DialogResult
        Dim result As DialogResult = MessageBox.Show(Message, Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Return result
    End Function

    Public Shared Sub ShowExclamation(ByVal Message As String, ByVal Caption As String)
        MessageBox.Show(Message, Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Public Shared Function ShowApproveDialog() As DialogResult
        Dim result As DialogResult = MessageBox.Show("Are you sureyou want to approved this record?", "Approve", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Return result
    End Function
    Public Shared Function ShowFinalizedDialog() As DialogResult
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to finalized this record?", "Finalize", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Return result
    End Function

    Public Shared Function ShowRejectionDialog() As DialogResult
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to reject this record?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Return result
    End Function

    Public Shared Function ShowCancelDialog() As DialogResult
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to cancel this record?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Return result
    End Function

    Public Shared Function ShowDeleteDialog() As DialogResult
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Return result
    End Function
    Public Shared Function ShowProcessDialog() As DialogResult
        Dim result As DialogResult = MessageBox.Show("Do you want to proceed?", "Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Return result
    End Function

    Public Shared Function ShowIsAlreadyExist() As DialogResult
        Dim result As DialogResult = MessageBox.Show("Record is Aready Exist, Are you sure you want to replace the Record", "Record is Already", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Return result
    End Function

    Public Shared Function ShowLockTransaction() As DialogResult
        Dim result As DialogResult = MessageBox.Show("Are you sure want to lock this Transaction?", "Lock Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Return result
    End Function
    Public Shared Function ShowUpdateItemModifiedSalesDialog() As DialogResult
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to Change the Item Details this record?", "Item Modified Sales", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Return result
    End Function


    Public Shared Function ShowDeleteSelectedDialog() As DialogResult
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete the selected items?", "Delete Selected", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Return result
    End Function
    Public Shared Sub ShowSaveSuccessfullUploading()
        MessageBox.Show("Uploading Successfull saved.", "Uploaded", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Public Shared Sub ShowSaveSuccessfulDialog()
        MessageBox.Show("Record Saved Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Shared Sub ShowSaveUnsucesssfulDialog()
        MessageBox.Show("Record not saved.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Public Shared Sub ShowApproveSuccessfulDialog()
        MessageBox.Show("Record Successfully Approved", "Approve", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Public Shared Sub ShowCopyFromSuccessfulDialog()
        MessageBox.Show("Record Successfully Copy From", "Copy", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Public Shared Sub ShowRejectionUnsuccessful()
        MessageBox.Show("Record not Rejected.", "Reject", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub
    Public Shared Sub ShowRejectionSuccessfulDialog()
        MessageBox.Show("Record Successfully Rejected", "Reject", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Public Shared Sub ShowApprovedUnsuccessful()
        MessageBox.Show("Record not Approved.", "Approve", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Public Shared Sub ShowDeleteSuccessfulDialog()
        MessageBox.Show("Record Successfully Deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Public Shared Sub ShowDeleteUnsuccessful()
        MessageBox.Show("Record not deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub
    Public Shared Sub ShowCancelledSuccessfulDialog()
        MessageBox.Show("Record Successfully Cancelled", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Shared Sub ShowCancelledUnsuccessful()
        MessageBox.Show("Record not Cancelled.", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

End Class
