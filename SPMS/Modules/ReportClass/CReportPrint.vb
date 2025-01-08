
Imports Microsoft.Office.Interop


Public Class CReportPrint
    Private _Records As New DataTable
    Private _ReportName As String = String.Empty
    Private _HeaderStartRows As Integer = -1
    Private _SheetName As String = String.Empty
    Private _Details As String = String.Empty



    'EXCEL OBJECT SET-UP----------------------------------------------------------
    'Private objExcelApp As Excel.Application = Nothing    ' create a excel application object
    Private objExcelApp As Excel.Application = New Excel.Application     ' create a excel application object
    Private objBooks As Excel.Workbooks = Nothing                    ' create a excel workbooks object
    Private objBook As Excel.Workbook = Nothing                        ' create a workbook object
    Private objSheets As Excel.Sheets = Nothing                     ' create a excel sheets object
    Private objSheet As Excel.Worksheet = Nothing                      ' create a excel sheet object 
    Private objRange As Excel.Range = Nothing                           ' create a excel range object

    '----------------------------------------------------------------------------

    Public Property DataRecords() As DataTable
        Get
            Return _Records
        End Get
        Set(ByVal value As DataTable)
            _Records = value
        End Set
    End Property

    Public Property ReportName() As String
        Get
            Return _ReportName
        End Get
        Set(ByVal value As String)
            _ReportName = value
        End Set
    End Property

    Public Property SheetName() As String
        Get
            Return _SheetName
        End Get
        Set(ByVal value As String)
            _SheetName = value
        End Set
    End Property

    Public Sub OpenExcel()
        objExcelApp = New Excel.Application                            ' create a excel application object
        objBooks = objExcelApp.Workbooks                                ' create a excel workbooks object
        objBook = CType(objExcelApp.Workbooks.Add(), Excel.Workbook)    ' create a workbook object
        objSheets = objBook.Worksheets                                  ' create a excel sheets object
        objSheet = CType(objBooks(1).Sheets.Item(1), Excel.Worksheet)   ' create a excel sheet object 
        objRange = Nothing                                              ' create a excel range object

    End Sub

    Public Sub CloseExcel()
        On Error Resume Next
        objRange.AutoFit()
        objExcelApp.Visible = True      'Make Excel Application Visible
        'objExcelApp.Quit()              'Quit Excel Application
    End Sub

    Public Sub PrintText(ByVal TextString As String, ByVal RowX As Integer, ByVal ColY As Integer, Optional ByVal FontName As String = "Corier New", Optional ByVal FontSize As Integer = 8, Optional ByVal FontStyle As System.Drawing.FontStyle = FontStyle.Regular, Optional ByVal FontColor As CEnumeration.ColorIndex = CEnumeration.ColorIndex.Black, Optional ByVal Alignment As Excel.XlHAlign = Excel.XlHAlign.xlHAlignLeft)
        On Error Resume Next
        objSheet.Range(objSheet.Cells(RowX, ColY), objSheet.Cells(RowX, ColY)).NumberFormat = ""
        objSheet.Range(objSheet.Cells(RowX, ColY), objSheet.Cells(RowX, ColY)).Font.ColorIndex = FontColor
        objSheet.Range(objSheet.Cells(RowX, ColY), objSheet.Cells(RowX, ColY)).Font.Bold = FontStyle
        objSheet.Range(objSheet.Cells(RowX, ColY), objSheet.Cells(RowX, ColY)).Font.Size = FontSize
        objSheet.Range(objSheet.Cells(RowX, ColY), objSheet.Cells(RowX, ColY)).Font.Name = FontName
        objSheet.Cells(RowX, ColY) = TextString


        'objSheet.Range(objSheet.Cells(RowX, ColY), objSheet.Cells(RowX, ColY)).Width = Excel.XlColumnDataType
    End Sub

    Public Sub CellCustomFormat(ByVal TextString As String, ByVal RowX As Integer, ByVal ColY As Integer, Optional ByVal FontName As String = "Corier New", Optional ByVal FontSize As Integer = 8, Optional ByVal FontStyle As System.Drawing.FontStyle = FontStyle.Regular, Optional ByVal FontColor As CEnumeration.ColorIndex = CEnumeration.ColorIndex.Black, Optional ByVal Alignment As Excel.XlHAlign = Excel.XlHAlign.xlHAlignLeft)
        'objSheet.Range(objSheet.Cells(RowX, ColY), objSheet.Cells(RowX, ColY)).
    End Sub

    'Public Function TextStyle(ByVal TextString As String,Optional ByVal Style As System.Drawing.FontStyle =) As String
    '    Dim fontStyle As System.Drawing.FontStyle = Style
    '    Return TextString
    '    fontStyle = Drawing.FontStyle.Regular
    'End Function

    Public Sub MergeCell(ByVal StartX As Integer, ByVal StartY As Integer, ByVal EndX As Integer, ByVal EndY As Integer)
        On Error Resume Next
        objSheet.Range(objSheet.Cells(StartX, StartY), objSheet.Cells(EndX, EndY)).Merge()
    End Sub

    Public Sub _PrintHeader(Optional ByVal Title As String = "Report Title")
        On Error Resume Next
        objSheet.Range(objSheet.Cells(1, 1), objSheet.Cells(1, 2)).Font.Color = Color.DarkBlue
        objSheet.Range(objSheet.Cells(1, 1), objSheet.Cells(1, 2)).Font.Name = "Tahoma"
        objSheet.Cells.Font.Bold = True
        objSheet.Range(objSheet.Cells(1, 1), objSheet.Cells(1, 2)).Merge()
        objSheet.Cells(1, 1) = Title
    End Sub

    Public Sub HeaderArea(ByVal StartX As Integer, ByVal StartY As Integer, ByVal EndX As Integer, ByVal EndY As Integer)
        On Error Resume Next
        objSheet.Range(objSheet.Cells(StartX, StartY), objSheet.Cells(EndX, EndY)).Borders.Color = RGB(230, 230, 250)
    End Sub

    Public Sub DetailsArea(ByVal StartX As Integer, ByVal StartY As Integer, ByVal EndX As Integer, ByVal EndY As Integer)
        On Error Resume Next
        objSheet.Range(objSheet.Cells(StartX, StartY), objSheet.Cells(EndX, EndY)).Borders.Color = RGB(0, 0, 0)
    End Sub

    Public Sub BackColor(ByVal StartX As Integer, ByVal StartY As Integer, ByVal EndX As Integer, ByVal EndY As Integer, Optional ByVal CellColor As CEnumeration.ColorIndex = CEnumeration.ColorIndex.White)
        On Error Resume Next
        objSheet.Range(objSheet.Cells(StartX, StartY), objSheet.Cells(EndX, EndY)).Cells.Interior.ColorIndex = CellColor
    End Sub

    Public Sub WrapCell(ByVal RowX As Integer, ByVal ColY As Integer)
        On Error Resume Next
        objSheet.Range(objSheet.Cells(RowX, ColY), objSheet.Cells(RowX, ColY)).WrapText = True
    End Sub

    Public Sub ShrinkToFit(ByVal StartX As Integer, ByVal StartY As Integer, ByVal EndX As Integer, ByVal EndY As Integer)
        On Error Resume Next
        objSheet.Range(objSheet.Cells(StartX, StartY), objSheet.Cells(EndX, EndY)).ShrinkToFit = True
    End Sub

End Class

Public Interface ExcelPrint
    Sub PrintHeader(ByVal StartRowX As Integer, ByVal StartColY As Integer, ByVal AreaL As Integer)
    Sub PrintDetails(ByVal StartRowX As Integer, ByVal StartColY As Integer, ByVal AreaH As Integer, ByVal AreaL As Integer, ByVal DetailCount As Integer)
    Sub PrintFooter(ByVal StartRowX As Integer, ByVal StartColY As Integer)
End Interface

