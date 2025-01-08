VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form FrmZipCodeTerritoryAssignmentDownloading 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Zip Code Territory Assignment Downloading"
   ClientHeight    =   2205
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
   ScaleHeight     =   2205
   ScaleWidth      =   7095
   StartUpPosition =   1  'CenterOwner
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
      Top             =   1560
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
      Top             =   840
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
   Begin VB.Label Label5 
      BackStyle       =   0  'Transparent
      Caption         =   "Zip Code Territory Assignment Downloading"
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
Attribute VB_Name = "FrmZipCodeTerritoryAssignmentDownloading"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim rsCheckRawDataFile As New ADODB.Recordset
Dim rs As New ADODB.Recordset
Dim st As New ADODB.Recordset
Dim rsCompany As New ADODB.Recordset
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
Dim rsCustomer As New ADODB.Recordset
Dim rsZipCodeTerritoryMapping As New ADODB.Recordset

Dim ln, n As Long
Dim rsVisitFrequency As New ADODB.Recordset
Dim attr As SECURITY_ATTRIBUTES  'security attributes structure
Dim rval As Long
Dim t, i, z As Integer
Dim k, cnt, r, str, str2, st, mt  As String
Dim repfile, rep1 As String
Dim rsRep As ADODB.Recordset
Dim Sheet1, xappl As Object
Dim x, y, q, a

'Set  security attributes
attr.nLength = Len(attr)  'size of the structure
attr.lpSecurityDescriptor = 0  'normal level of security
attr.bInheritHandle = 1  'default setting
' Create directory.
If rsZipCodeTerritoryMapping.State = 1 Then rsZipCodeTerritoryMapping.Close
    rsZipCodeTerritoryMapping.Open "Select * from ZipCodeTerritoryMapping WHERE DLTFLG = '" & "0" & "' AND ISACTIVE = '" & "1" & "'", cnn, adOpenKeyset
    
 ln = 0
str = "ZIPCODE TERRITORY MAPPING"

        rval = CreateDirectory("C:\MY SPMS DOWNLOAD\", attr)
        rval = CreateDirectory("C:\MY SPMS DOWNLOAD\ZIPCODE TERRITORY MAPPING DOWNLOADS", attr)
        
        repfile = App.Path & "\Template\Zip Code Territory Assignment.xls"
        rep1 = App.Path & "\Template\Zip Code Territory Assignment.xls"
        r = App.Path & "\Template\Zip Code Territory Assignment.xls"
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
    
   For y = 1 To rsZipCodeTerritoryMapping.RecordCount
    ln = ln + 1
   Next y

    n = (ProgressBar1.Max / ln) * 0.99
    ProgressBar1.Value = 0
    
    
    For x = 2 To rsZipCodeTerritoryMapping.RecordCount + 1
       

         'Sheet1.Cells(x, 1) = rsZipCodeTerritoryMapping.Fields(0).Value
         Sheet1.Cells(x, 1) = rsZipCodeTerritoryMapping.Fields(2).Value
         Sheet1.Cells(x, 2) = "'" & rsZipCodeTerritoryMapping.Fields(3).Value
         Sheet1.Cells(x, 3) = "'" & rsZipCodeTerritoryMapping.Fields(4).Value
         Sheet1.Cells(x, 4) = "'" & rsZipCodeTerritoryMapping.Fields(5).Value
         Sheet1.Cells(x, 5) = "'" & rsZipCodeTerritoryMapping.Fields(6).Value
         Sheet1.Cells(x, 6) = "'" & rsZipCodeTerritoryMapping.Fields(7).Value
         Sheet1.Cells(x, 7) = "'" & rsZipCodeTerritoryMapping.Fields(8).Value
         Sheet1.Cells(x, 8) = "'" & rsZipCodeTerritoryMapping.Fields(9).Value
         Sheet1.Cells(x, 9) = "'" & rsZipCodeTerritoryMapping.Fields(10).Value
         Sheet1.Cells(x, 10) = rsZipCodeTerritoryMapping.Fields(11).Value
         Sheet1.Cells(x, 11) = rsZipCodeTerritoryMapping.Fields(12).Value
         
        
      
    rsZipCodeTerritoryMapping.MoveNext
    
    If ProgressBar1.Value + n < ProgressBar1.Max Then
        ProgressBar1.Value = ProgressBar1.Value + n
    Else
        ProgressBar1.Value = ProgressBar1.Max
    End If
    Next x
 
    xappl.ActiveWorkbook.SaveAs ("C:\MY SPMS DOWNLOAD\ZIPCODE TERRITORY MAPPING DOWNLOADS\" & str & ".xls")
    xappl.Visible = True
    xappl.ActiveWorkbook.Close
    xappl.Visible = False
    Set Sheet1 = Nothing
    Set xappl = Nothing

End Sub



Private Sub Label2_Click()

End Sub


Private Sub lblClose_Click()
Unload Me
End Sub

Private Sub lblUpload_Click()
cmdImport_Click
End Sub

Private Sub Form_Load()
SQLConnect

End Sub
