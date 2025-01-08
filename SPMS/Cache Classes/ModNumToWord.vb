Module ModNumToWord
    Function SpellNumber(ByVal MyNumber As String) As String
        Dim Dollars As String = ""
        Dim Cents As String = ""
        Dim Temp As String = ""
        Dim DecimalPlace, Count As Integer
        Dim Place(9) As String
        Place(2) = "TH"
        Place(3) = "M"
        Place(4) = "B"
        Place(5) = "TR"
        ' String representation of amount.  
        MyNumber = Trim(Str(MyNumber))
        ' Position of decimal place 0 if none.
        DecimalPlace = InStr(MyNumber, ".")
        ' Convert cents and set MyNumber to dollar amount.
        If DecimalPlace > 0 Then
            Cents = GetTens(Left(Mid(MyNumber, DecimalPlace + 1) & _
            "00", 2))
            MyNumber = Trim(Left(MyNumber, DecimalPlace - 1))
        End If
        Count = 1
        Do While MyNumber <> ""
            Temp = GetHundreds(Right(MyNumber, 3))
            If Temp <> "" Then Dollars = Temp & Place(Count)
            If Len(MyNumber) > 3 Then
                MyNumber = Left(MyNumber, Len(MyNumber) - 3)
            Else
                MyNumber = ""
            End If
            Count = Count + 1
        Loop
        SpellNumber = Dollars
    End Function
    ' Converts a number from 100-999 into text 
    Function GetHundreds(ByVal MyNumber As String) As String
        Dim Result As String = ""
        If Val(MyNumber) = 0 Then : Return "" : Exit Function : End If
        MyNumber = Right("000" & MyNumber, 3)
        ' Convert the hundreds place.
        If Mid(MyNumber, 1, 1) <> "0" Then
            Result = GetDigit(Mid(MyNumber, 1, 1)) & ""
        End If
        ' Convert the tens and ones place.
        If Mid(MyNumber, 2, 1) <> "0" Then
            Result = Result & GetTens(Mid(MyNumber, 2))
        Else
            Result = Result & GetDigit(Mid(MyNumber, 3))
        End If
        GetHundreds = Result
    End Function
    ' Converts a number from 10 to 99 into text. 
    Function GetTens(ByVal TensText As String) As String
        Dim Result As String
        Result = ""           ' Null out the temporary function value.
        If Val(Left(TensText, 1)) = 1 Then   ' If value between 10-19...
            Select Case Val(TensText)
                Case 10 : Result = "10"
                Case 11 : Result = "11"
                Case 12 : Result = "12"
                Case 13 : Result = "13"
                Case 14 : Result = "14"
                Case 15 : Result = "15"
                Case 16 : Result = "16"
                Case 17 : Result = "17"
                Case 18 : Result = "18"
                Case 19 : Result = "19"
                Case Else
            End Select
        Else                                 ' If value between 20-99...
            Select Case Val(Left(TensText, 1))
                Case 1 : Result = "10"
                Case 2 : Result = "20"
                Case 3 : Result = "30"
                Case 4 : Result = "40"
                Case 5 : Result = "50"
                Case 6 : Result = "60"
                Case 7 : Result = "70"
                Case 8 : Result = "80"
                Case 9 : Result = "90"
                Case Else
            End Select
            Result = Result & GetDigit _
            (Right(TensText, 1))  ' Retrieve ones place.
        End If
        GetTens = Result
    End Function
    ' Converts a number from 1 to 9 into text. 
    Function GetDigit(ByVal Digit As String) As String
        Select Case Val(Digit)
            Case 1 : GetDigit = "1"
            Case 2 : GetDigit = "2"
            Case 3 : GetDigit = "3"
            Case 4 : GetDigit = "4"
            Case 5 : GetDigit = "5"
            Case 6 : GetDigit = "6"
            Case 7 : GetDigit = "7"
            Case 8 : GetDigit = "8"
            Case 9 : GetDigit = "9"
            Case Else : GetDigit = ""
        End Select
    End Function
End Module
