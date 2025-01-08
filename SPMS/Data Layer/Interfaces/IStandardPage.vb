Public Interface IStandardPage
    Sub NewRecord()
    Sub SaveData()
    Sub ShowData(ByVal RecordID As Integer)
    Function EditMode(ByVal IsEditMode As Boolean) As Boolean
    Sub Delete()
    Sub Close()
    Sub FindRecord()
    Sub Clear()
    Sub Undo()
    Function ValidateData() As Boolean


End Interface
