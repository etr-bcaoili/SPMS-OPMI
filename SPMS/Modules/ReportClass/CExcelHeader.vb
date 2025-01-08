Imports Microsoft.Office.Interop
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Drawing

Public Class CExcelHeader
    Private _ExApp As Excel.Application
    Private _ExcelSheet As Excel.Worksheet
    Private _ExcelWorkBook As Excel.Workbook

    Private _ReportTitle As String = "Report Title"
    Private _RunDate As DateTime = Now.Date
    Private _MonthFrom As String = ""
    Private _MonthTo As String = ""
    Private _YearFrom As String = ""
    Private _YearTo As String = ""
    Private _CoverageCaption As String = "For the Period :"
    Private _CompanyName As String = ConnectionModule.GetDefaultCompany
    Private _ReportTitle2 As String = ""

    Public Enum ColorIndex
        Black = 1
        White = 2
        Red = 3
        BrightGreen = 4
        Blue = 5
        Yellow = 6
        Pink = 7
        Turqoise = 8
        DarkRed = 9
        Gree = 10
        DarkBlue = 11
        DarkYellow = 12
        Violet = 13
        Teal = 14
        Gray25 = 15
        Gray50 = 16
        Periwinkle = 17
        No18 = 18
        Ivory = 19
        No20 = 20
        No21 = 21
        Coral = 22
        OceanBlue = 23
        IceBlue = 24
        No25 = 25
        No26 = 26
        No27 = 27
        No28 = 28
        No29 = 29
        No30 = 30
        No31 = 31
        No32 = 32
        SkyBlue = 33
        LightTurqoise = 34
        LightGreen = 35
        LightYellow = 36
        PaleBlue = 37
        Rose = 38
        Lavendar = 39
        Tan = 40
        LightBlue = 41
        Aqua = 42
        Lime = 43
        Gold = 44
        LightOrange = 45
        Orange = 46
        BlueGray = 47
        Gray40 = 48
        DarkTeal = 49
        SeaGreen = 50
        DarkGreen = 51
        OliveGreen = 52
        Brown = 53
        Plum = 54
        Indigo = 55
        Gray80 = 56
    End Enum

    Public Property ExcelApp() As Excel.Application
        Get
            Return _ExApp
        End Get
        Set(ByVal value As Excel.Application)
            _ExApp = value
        End Set
    End Property


    Public Property Ex_Sheet() As Excel.Worksheet
        Get
            Return _ExcelSheet
        End Get
        Set(ByVal value As Excel.Worksheet)
            _ExcelSheet = value
        End Set
    End Property

    Public Property Ex_WorkBook() As Excel.Workbook
        Get
            Return _ExcelWorkBook
        End Get
        Set(ByVal value As Excel.Workbook)
            _ExcelWorkBook = value
        End Set
    End Property


    Public Property Report_Title2() As String
        Get
            Return _ReportTitle2
        End Get
        Set(ByVal value As String)
            _ReportTitle2 = value
        End Set
    End Property

    Public Property Month_From() As String
        Get
            Return _MonthFrom
        End Get
        Set(ByVal value As String)
            _MonthFrom = value
        End Set
    End Property

    Public Property Month_To() As String
        Get
            Return _MonthTo
        End Get
        Set(ByVal value As String)
            _MonthTo = value
        End Set
    End Property

    Public Property Year_From() As String
        Get
            Return _YearFrom
        End Get
        Set(ByVal value As String)
            _YearFrom = value
        End Set
    End Property

    Public Property Year_To() As String
        Get
            Return _YearTo
        End Get
        Set(ByVal value As String)
            _YearTo = value
        End Set
    End Property

    Public Property CoverageCaption() As String
        Get
            Return _CoverageCaption
        End Get
        Set(ByVal value As String)
            _CoverageCaption = value
        End Set
    End Property

    Public Sub TextStyleGroup(ByVal Cell1_Object As Object, _
                        ByVal Cell2_Object As Object, Optional ByVal Bold As Boolean = False, _
                        Optional ByVal FontStyle As String = "Arial", Optional ByVal FontSize As Integer = 11)
        On Error Resume Next
        TextStyle(Cell1_Object, Cell2_Object, FontStyle)
        TextSize(Cell1_Object, Cell2_Object, FontSize)
        BoldText(Cell1_Object, Cell2_Object, Bold)
        CellAutoFit(Cell1_Object, Cell2_Object)

    End Sub

    Public Sub ColumnHeaderStyle(ByVal Cell1_Object As Object, ByVal Cell2_Object As Object)
        TextStyleGroup(Cell1_Object, Cell2_Object, True)
        CellColor(Cell1_Object, Cell2_Object, CExcelHeader.ColorIndex.SkyBlue)
        FontColor(Cell1_Object, Cell2_Object, Color.DarkBlue)
        BoldText(Cell1_Object, Cell2_Object, True)
    End Sub

    Public Sub DetailsStyle(ByVal Cell1_Object As Object, ByVal Cell2_Object As Object)
        CellColor(Cell1_Object, Cell2_Object, CExcelHeader.ColorIndex.White)
        FontColor(Cell1_Object, Cell2_Object, Color.Black)
        BoldText(Cell1_Object, Cell2_Object, True)
        TextStyleGroup(Cell1_Object, Cell2_Object, True, , 10)
        BorderWieght(Cell1_Object, Cell2_Object, 1)
    End Sub

    Public Sub TextStyle(ByVal Cell1_Object As Object, ByVal Cell2_Object As Object, Optional ByVal FontStyle As String = "Arial")
        _ExcelSheet.Range(Cell1_Object, Cell2_Object).Font.FontStyle = FontStyle
    End Sub

    Public Sub TextSize(ByVal Cell1_Object As Object, ByVal Cell2_Object As Object, Optional ByVal FontSize As Integer = 11)
        _ExcelSheet.Range(Cell1_Object, Cell2_Object).Font.Size = FontSize
    End Sub

    Public Sub BoldText(ByVal Cell1_Object As Object, ByVal Cell2_Object As Object, Optional ByVal Bold As Boolean = False)
        _ExcelSheet.Range(Cell1_Object, Cell2_Object).Font.Bold = Bold
    End Sub

    Public Sub CellAutoFit(ByVal Cell1_Object As Object, ByVal Cell2_Object As Object)
        _ExcelSheet.Range(Cell1_Object, Cell2_Object).EntireColumn.AutoFit()
    End Sub

    Public Sub BorderWieght(ByVal Cell1_Object As Object, ByVal Cell2_Object As Object, Optional ByVal BorderWeight As Integer = 0)
        _ExcelSheet.Range(Cell1_Object, Cell2_Object).Borders.Weight = BorderWeight
    End Sub

    Public Sub WriteText(ByVal Messages As String, ByVal CellRow As Integer, ByVal CellColumn As Integer)
        _ExcelSheet.Cells(CellRow, CellColumn) = Messages
        '_ExcelSheet.
    End Sub

    Public Sub MergeCell(ByVal Cell1_Object As Object, ByVal Cell2_Object As Object)
        _ExcelSheet.Range(Cell1_Object, Cell2_Object).Merge()
    End Sub

    Public Sub InsertCellRow(ByVal Cell1_Object As Object, ByVal Cell2_Object As Object)
        _ExcelSheet.Range(Cell1_Object, Cell2_Object).EntireRow.Insert()
    End Sub

    Public Sub CellColor(ByVal Cell1_Object As Object, ByVal Cell2_Object As Object, Optional ByVal CellColor As ColorIndex = ColorIndex.White)
        _ExcelSheet.Range(Cell1_Object, Cell2_Object).Cells.Interior.ColorIndex = CellColor
    End Sub

    Public Sub FontColor(ByVal Cell1_Object As Object, ByVal Cell2_Object As Object, ByVal FontColor As System.Drawing.Color)
        _ExcelSheet.Range(Cell1_Object, Cell2_Object).Font.Color = ColorTranslator.ToOle(FontColor)
    End Sub

    Public Sub WriteFormula(ByVal Cell1_Object As Object, ByVal Cell2_Object As Object, Optional ByVal StringFormula As String = "")
        _ExcelSheet.Range(Cell1_Object, Cell2_Object).Formula = StringFormula
    End Sub

    Public Sub Print_Header()

        InsertCellRow(_ExcelSheet.Cells(1, 1), _ExcelSheet.Cells(6, 1))
        MergeCell(_ExcelSheet.Cells(1, 1), _ExcelSheet.Cells(1, _ExcelSheet.Columns.Count))
        MergeCell(_ExcelSheet.Cells(2, 1), _ExcelSheet.Cells(2, _ExcelSheet.Columns.Count))

        CellColor(_ExcelSheet.Cells(1, 1), _ExcelSheet.Cells(1, 1), ColorIndex.White)
        TextStyleGroup(_ExcelSheet.Cells(1, 1), _ExcelSheet.Cells(1, 7), True, , 16)
        FontColor(_ExcelSheet.Cells(1, 1), _ExcelSheet.Cells(1, 7), Color.Black)
        WriteText(_CompanyName, 1, 1)

        CellColor(_ExcelSheet.Cells(3, 1), _ExcelSheet.Cells(3, 7), ColorIndex.White)
        TextStyleGroup(_ExcelSheet.Cells(3, 1), _ExcelSheet.Cells(3, 7), , , 14)
        FontColor(_ExcelSheet.Cells(3, 1), _ExcelSheet.Cells(3, 7), Color.DarkBlue)
        MergeCell(_ExcelSheet.Cells(3, 1), _ExcelSheet.Cells(3, _ExcelSheet.Columns.Count))
        _ReportTitle = _ExcelSheet.Name & "  ||  " & _ReportTitle2
        WriteText(_ReportTitle, 3, 1)

        TextStyleGroup(_ExcelSheet.Cells(4, 1), _ExcelSheet.Cells(4, 7))
        MergeCell(_ExcelSheet.Cells(4, 1), _ExcelSheet.Cells(4, _ExcelSheet.Columns.Count))
        WriteText(_CoverageCaption & _MonthFrom & " " & _YearFrom & " - To :" & _MonthTo & " " & _YearTo, 4, 1)

        TextStyleGroup(_ExcelSheet.Cells(5, 1), _ExcelSheet.Cells(5, 7))
        MergeCell(_ExcelSheet.Cells(5, 1), _ExcelSheet.Cells(5, _ExcelSheet.Columns.Count))
        WriteText("Run Date : " & _RunDate, 5, 1)

        MergeCell(_ExcelSheet.Cells(6, 1), _ExcelSheet.Cells(6, _ExcelSheet.Columns.Count))
    End Sub

    'Public Sub Print_Header(ByVal _ExcelSheet As Excel.Worksheet, ByVal _ExcelWorkBook As Excel.Workbook, Optional ByVal SheetNo As String = "Sheet1")
    '    _ExcelSheet.Range(_ExcelSheet.Cells(1, 1), _ExcelSheet.Cells(7, 1)).EntireRow.Insert()

    '    _ExcelSheet.Range(_ExcelSheet.Cells(1, 1), _ExcelSheet.Cells(1, 4)).Merge()
    '    _ExcelSheet.Range(_ExcelSheet.Cells(1, 1), _ExcelSheet.Cells(1, 1)).Font.Bold = True

    '    _ExcelSheet.Cells(1, 1) = _CompanyName

    '    _ExcelSheet.Cells(3, 1) = "Run Date : " & _RunDate
    '    _ExcelSheet.Cells(4, 1) = _ReportTitle
    '    _ExcelSheet.Cells(5, 1) = "From : " & _MonthFrom & "-" & _YearFrom
    '    _ExcelSheet.Cells(6, 1) = "To : " & _MonthTo & "-" & _YearTo
    'End Sub

End Class

Public Class ExcelColumns
    Private _Column As Integer = -1

    Public Property ColumnString() As String
        Get
            Return _Column
        End Get
        Set(ByVal value As String)
            _Column = value
        End Set
    End Property

    Public Function ColumnToString(ByVal ColumnInt As Integer) As String
        Dim coL As String = ""
        While ColumnInt > 26
            coL = coL & "A"
            ColumnInt = ColumnInt - 26
        End While

        Select Case ColumnInt
            Case 1
                Return "A"
            Case 2
                Return "B"
            Case 3
                Return "C"
            Case 4
                Return "D"
            Case 5
                Return "E"
            Case 6
                Return "F"
            Case 7
                Return "G"
            Case 8
                Return "H"
            Case 9
                Return "I"
            Case 10
                Return "J"
            Case 11
                Return "K"
            Case 12
                Return "L"
            Case 13
                Return "M"
            Case 14
                Return "N"
            Case 15
                Return "O"
            Case 16
                Return "P"
            Case 17
                Return "Q"
            Case 18
                Return "R"
            Case 19
                Return "S"
            Case 20
                Return "T"
            Case 21
                Return "U"
            Case 22
                Return "V"
            Case 23
                Return "W"
            Case 24
                Return "X"
            Case 25
                Return "Y"
            Case 26
                Return "Z"
        End Select

    End Function
End Class