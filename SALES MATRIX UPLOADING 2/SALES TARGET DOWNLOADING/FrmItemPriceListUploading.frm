VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form FrmSalesTargetDownloading 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Sales Target Downloading"
   ClientHeight    =   2880
   ClientLeft      =   4185
   ClientTop       =   3990
   ClientWidth     =   7095
   ControlBox      =   0   'False
   BeginProperty Font 
      Name            =   "Segoe UI"
      Size            =   8.25
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2880
   ScaleWidth      =   7095
   StartUpPosition =   1  'CenterOwner
   Begin VB.ComboBox cboMonth 
      Height          =   315
      Left            =   960
      Style           =   2  'Dropdown List
      TabIndex        =   12
      Top             =   840
      Width           =   2175
   End
   Begin VB.ComboBox cboYear 
      Height          =   315
      Left            =   960
      Style           =   2  'Dropdown List
      TabIndex        =   11
      Top             =   1200
      Width           =   2175
   End
   Begin VB.ComboBox cmbDistrict 
      Height          =   315
      Left            =   4680
      TabIndex        =   10
      Top             =   1200
      Width           =   2175
   End
   Begin VB.ComboBox cmbItemDivision 
      Height          =   315
      Left            =   4680
      TabIndex        =   8
      Top             =   840
      Width           =   2175
   End
   Begin VB.PictureBox Picture1 
      BackColor       =   &H00DEC4B0&
      BorderStyle     =   0  'None
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   615
      Left            =   0
      ScaleHeight     =   615
      ScaleWidth      =   8175
      TabIndex        =   4
      Top             =   2280
      Width           =   8175
      Begin VB.Label lblClose 
         BackColor       =   &H80000009&
         BackStyle       =   0  'Transparent
         Caption         =   "Close"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   -1  'True
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FF0000&
         Height          =   255
         Left            =   6480
         TabIndex        =   6
         Top             =   240
         Width           =   615
      End
      Begin VB.Label lblUpload 
         BackColor       =   &H80000009&
         BackStyle       =   0  'Transparent
         Caption         =   "Download"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   -1  'True
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FF0000&
         Height          =   255
         Left            =   5400
         TabIndex        =   5
         Top             =   240
         Width           =   855
      End
   End
   Begin VB.Frame Frame1 
      BackColor       =   &H00FFFFFF&
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   615
      Left            =   120
      TabIndex        =   0
      Top             =   1560
      Width           =   6855
      Begin MSComctlLib.ProgressBar ProgressBar1 
         Height          =   255
         Left            =   120
         TabIndex        =   1
         Top             =   240
         Visible         =   0   'False
         Width           =   6615
         _ExtentX        =   11668
         _ExtentY        =   450
         _Version        =   393216
         BorderStyle     =   1
         Appearance      =   1
         MouseIcon       =   "FrmItemPriceListUploading.frx":0000
         Max             =   1000
         Scrolling       =   1
      End
   End
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   0
      Top             =   4680
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
      CancelError     =   -1  'True
   End
   Begin VB.TextBox txtMonth 
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   285
      Left            =   6960
      TabIndex        =   2
      Top             =   3360
      Visible         =   0   'False
      Width           =   615
   End
   Begin VB.Label Label4 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Month :"
      Height          =   255
      Left            =   120
      TabIndex        =   14
      Top             =   840
      Width           =   735
   End
   Begin VB.Label Label3 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Year :"
      Height          =   255
      Left            =   120
      TabIndex        =   13
      Top             =   1200
      Width           =   615
   End
   Begin VB.Label Label2 
      BackColor       =   &H00FFFFFF&
      Caption         =   "District:"
      Height          =   255
      Left            =   3480
      TabIndex        =   9
      Top             =   1200
      Width           =   615
   End
   Begin VB.Label Label1 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Item Division:"
      Height          =   255
      Left            =   3480
      TabIndex        =   7
      Top             =   840
      Width           =   1095
   End
   Begin VB.Label Label5 
      BackStyle       =   0  'Transparent
      Caption         =   "Sales Target Downloading"
      BeginProperty Font 
         Name            =   "Segoe UI"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   375
      Left            =   360
      TabIndex        =   3
      Top             =   120
      Width           =   3495
   End
   Begin VB.Image Image2 
      Height          =   765
      Left            =   0
      Picture         =   "FrmItemPriceListUploading.frx":0CDA
      Stretch         =   -1  'True
      Top             =   0
      Width           =   7125
   End
End
Attribute VB_Name = "FrmSalesTargetDownloading"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim rsCheckRawDataFile As New ADODB.Recordset
Dim rs As New ADODB.Recordset
Dim st As New ADODB.Recordset
Dim rsCompany As New ADODB.Recordset
Dim rsItemDiv As New ADODB.Recordset
Dim rsDistrict As New ADODB.Recordset
Dim x, y, m
Dim repfile As String
Dim urec As Long
Dim objExcel As Excel.Application
Dim objWorkbook As Excel.Workbook
Dim objWorksheet As Excel.Worksheet
Option Explicit
Private Type SECURITY_ATTRIBUTES
  nLength As Long
  lpSecurityDescriptor As Long
  bInheritHandle As Boolean
End Type
Private Declare Function CreateDirectory Lib "kernel32.dll" Alias "CreateDirectoryA" (ByVal lpPathName As String, lpSecurityAttributes As SECURITY_ATTRIBUTES) As Long


Dim rsmonth As New ADODB.Recordset
Dim rsyear As New ADODB.Recordset
Dim query As String




Public Function CheckField(strText As String)
    If Len(Trim(strText)) Then
        CheckField = Replace(strText, "'", "")
    Else
        CheckField = "None Found!"
    End If
End Function


Private Sub cmclose_Click()
Unload Me
End Sub

Private Sub cmdclose_Click()
Unload Me
End Sub

Private Sub cmdexit1_Click()
Unload Me
End Sub



Private Sub cmdImport_Click()
   
If cboMonth.Text = "" Or cboYear.Text = "" Then
MsgBox ("Month and Year is required.")
Exit Sub

End If



ProgressBar1.Visible = True
    ImportData

       MsgBox "Downloading Data complete! "
       Unload Me
  
End Sub
Private Sub StartExcel()
On Error GoTo err:
Set objExcel = GetObject(, "Excel.Application") ' Create Excel Object.
Exit Sub
err:
Set objExcel = CreateObject("Excel.Application") 'Create Excel Object.

End Sub

Private Sub ImportData()

Dim rsRawdata As New ADODB.Recordset
Dim rsSalesTarget As New ADODB.Recordset
Dim rsItem As New ADODB.Recordset
Dim rsCalendar As New ADODB.Recordset
Dim ln, n As Long
Dim rsVisitFrequency As New ADODB.Recordset
Dim attr As SECURITY_ATTRIBUTES  'security attributes structure
Dim rval As Long
Dim t, i, z As Integer
Dim k, cnt, r, str, str2, st, mt  As String
Dim repfile, rep1 As String
Dim rsRep As ADODB.Recordset
Dim Sheet1, xappl As Object
Dim x, y

'Set  security attributes
attr.nLength = Len(attr)  'size of the structure
attr.lpSecurityDescriptor = 0  'normal level of security
attr.bInheritHandle = 1  'default setting
' Create directory.


 ln = 0
str = "SALES TARGET"

        rval = CreateDirectory("C:\MY SPMS DOWNLOAD\", attr)
        rval = CreateDirectory("C:\MY SPMS DOWNLOAD\SALES TARGET DOWNLOADS", attr)
        
        repfile = App.Path & "\Template\SalesTarget.xls"
        rep1 = App.Path & "\Template\SalesTarget.xls"
        r = App.Path & "\Template\SalesTarget.xls"
    On Error Resume Next
    Set xappl = GetObject(, "excel.application")
    If err.Number = 0 Then
        Set xappl = GetObject(rep1)
        xappl.Parent.Windows(r).Close
    End If
    err.Clear
    Set xappl = Nothing
    FileCopy repfile, rep1
    
    Set xappl = CreateObject("Excel.application")
    Set Sheet1 = xappl.Workbooks.Open(rep1).Sheets(1)

If rsSalesTarget.State = 1 Then rsSalesTarget.Close
    'rsSalesTarget.Open "Select * from TerritoryItemTarget Where IsActive = '" & "1" & "' And DLTFLG = '" & "0" & "'", cnn, adOpenKeyset
    
    
    query = "SELECT * FROM TerritoryItemTarget A " & _
                            "   INNER JOIN Item B   ON B.ItemCD = A.ItemCD  " & _
                            "   INNER JOIN SalesMatrix D    " & _
                            "           ON  D.STTERRCD = A.STTERRCD  " & _
                            "           AND YEAR(D.EffectivityStartDate) = '" & cboYear.Text & "' AND YEAR(D.EffectivityEndDate) = '" & cboYear.Text & "'  AND MONTH(D.EffectivityStartDate) = '" & cboMonth.Text & "'    AND MONTH(D.EffectivityENDDate) = '" & cboMonth.Text & "'    AND D.DLTFLG =0 WHERE A.MONTH = '" & cboMonth.Text & "'     AND A.Year = '" & cboYear.Text & "' ANd A.DLTFLG = 0 AND A.IsActive = 1"
    
    
    If cmbDistrict.Text <> "" Then
        query = query & " AND D.STDISTRCTCD = '" & cmbDistrict.Text & "' "
    End If
    
    If cmbItemDivision.Text <> "" Then
    query = query & " AND B.ItemDivCD = '" & cmbItemDivision.Text & "' "
    End If
       
            query = query & " Order By A.Stterrcd, A.ItemCD "
    
        rsSalesTarget.Open query, cnn, adOpenStatic
' If cmbDistrict.Text <> "" Then
'    rsSalesTarget.Open "SELECT * FROM TerritoryItemTarget A " & _
'                            "   INNER JOIN Item B   ON B.ItemCD = A.ItemCD  " & _
'                            "   INNER JOIN SalesMatrix D    " & _
'                            "           ON  D.STTERRCD = A.STTERRCD  " & _
'                            "           AND YEAR(D.EffectivityStartDate) = '" & cboYear.Text & "' AND YEAR(D.EffectivityEndDate) = '" & cboYear.Text & "'  AND MONTH(D.EffectivityStartDate) = '" & cboMonth.Text & "'    AND MONTH(D.EffectivityENDDate) = '" & cboMonth.Text & "'  AND D.STDISTRCTCD = '" & cmbDistrict.Text & "'  AND D.DLTFLG =0 WHERE A.MONTH = '" & cboMonth.Text & "'     AND A.Year = '" & cboYear.Text & "' ANd A.DLTFLG = 0 AND A.IsActive = 1 Order By A.Stterrcd, A.ItemCD ", cnn, adOpenKeyset
'Else
'      rsSalesTarget.Open "SELECT * FROM TerritoryItemTarget A " & _
'                            "   INNER JOIN Item B   ON B.ItemCD = A.ItemCD  " & _
'                            "   INNER JOIN SalesMatrix D    " & _
'                            "           ON  D.STTERRCD = A.STTERRCD  " & _
'                            "           AND YEAR(D.EffectivityStartDate) = '" & cboYear.Text & "' AND YEAR(D.EffectivityEndDate) = '" & cboYear.Text & "'  AND MONTH(D.EffectivityStartDate) = '" & cboMonth.Text & "'    AND MONTH(D.EffectivityENDDate) = '" & cboMonth.Text & "'    AND D.DLTFLG =0 WHERE A.MONTH = '" & cboMonth.Text & "'     AND A.Year = '" & cboYear.Text & "' ANd A.DLTFLG = 0 AND A.IsActive = 1 Order By A.Stterrcd, A.ItemCD ", cnn, adOpenKeyset
'End If
                            
    
 If rsSalesTarget.RecordCount = 0 Then
    MsgBox "No Record Found", vbInformation
    End
End If
   
   For y = 1 To rsSalesTarget.RecordCount
    ln = ln + 1
   Next y

n = (ProgressBar1.Max / ln) * 0.99
ProgressBar1.Value = 0
    
    For x = 2 To rsSalesTarget.RecordCount + 1
        
         Sheet1.Cells(x, 1) = rsSalesTarget.Fields(2).Value
         Sheet1.Cells(x, 2) = rsSalesTarget.Fields(3).Value
         Sheet1.Cells(x, 3) = rsSalesTarget.Fields(6).Value
         If rsItem.State = 1 Then rsItem.Close
            rsItem.Open "Select * from Item where Itemcd = '" & rsSalesTarget.Fields(6).Value & "' And Itemdel = '" & "0" & "'", cnn, adOpenKeyset
         Sheet1.Cells(x, 4) = rsItem.Fields(5).Value
         Sheet1.Cells(x, 5) = rsSalesTarget.Fields(5).Value
         
         If rsCalendar.State = 1 Then rsCalendar.Close
            rsCalendar.Open "Select * from Calendar where CAPN = '" & rsSalesTarget.Fields(5).Value & "' AND IsActive = '" & "1" & "'", cnn, adOpenKeyset
         Sheet1.Cells(x, 6) = rsCalendar.Fields(5).Value
         Sheet1.Cells(x, 7) = rsSalesTarget.Fields(7).Value
         Sheet1.Cells(x, 8) = rsSalesTarget.Fields(9).Value
         
    rsSalesTarget.MoveNext
    If ProgressBar1.Value + n < ProgressBar1.Max Then
        ProgressBar1.Value = ProgressBar1.Value + n
    Else
        ProgressBar1.Value = ProgressBar1.Max
    End If
    Next x
 
    xappl.ActiveWorkbook.SaveAs ("C:\MY SPMS DOWNLOAD\SALES TARGET DOWNLOADS\" & str & ".xls")
    xappl.Visible = True
    xappl.ActiveWorkbook.Close
    xappl.Visible = False
    Set Sheet1 = Nothing
    Set xappl = Nothing

End Sub


Private Sub cmbItemDivision_Click()
cmbDistrict.Clear
If rsDistrict.State = 1 Then rsDistrict.Close
    rsDistrict.Open "Select DISTINCT(STDISTRCTCD) from SalesMatrix where STITMDIVCD = '" & cmbItemDivision.Text & "'", cnn, adOpenKeyset
For y = 1 To rsDistrict.RecordCount
    cmbDistrict.AddItem rsDistrict.Fields(0).Value
rsDistrict.MoveNext
Next y

End Sub

Private Sub lblClose_Click()
Unload Me
End Sub

Private Sub lblUpload_Click()
cmdImport_Click
End Sub

Private Sub Form_Load()
SQLConnect

If rsItemDiv.State = 1 Then rsItemDiv.Close
    rsItemDiv.Open "Select Distinct(ITMDIVCD) From ItemDivision Where DLTFLG = '" & "0" & "'", cnn, adOpenKeyset
cmbItemDivision.AddItem "All"
For x = 1 To rsItemDiv.RecordCount
    cmbItemDivision.AddItem rsItemDiv.Fields(0).Value
    rsItemDiv.MoveNext
Next x


If rsmonth.State = 1 Then rsmonth.Close

rsmonth.Open "SELECT Distinct Month From TerritoryItemTarget Where DLTFLG = 0 Order By Month", cnn, adOpenKeyset
cboMonth.Clear

For m = 0 To rsmonth.RecordCount - 1
cboMonth.AddItem rsmonth.Fields("Month").Value
rsmonth.MoveNext
Next m


If rsyear.State = 1 Then rsyear.Close
rsyear.Open "SELECT Distinct Year From TerritoryItemTarget WHERE DLTFLG = 0 Order by Year", cnn, adOpenKeyset

cboYear.Clear
For m = 0 To rsyear.RecordCount - 1
cboYear.AddItem rsyear.Fields("Year")
rsyear.MoveNext
Next m

End Sub
