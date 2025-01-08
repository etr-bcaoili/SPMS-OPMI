VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomctl.ocx"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form FrmBillingOrderDownloading 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   0  'None
   Caption         =   "Billing Order Downloading"
   ClientHeight    =   3135
   ClientLeft      =   6540
   ClientTop       =   5265
   ClientWidth     =   7245
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
   ScaleHeight     =   3135
   ScaleWidth      =   7245
   ShowInTaskbar   =   0   'False
   Begin VB.Frame Frame2 
      BackColor       =   &H00FFFFFF&
      Height          =   975
      Left            =   0
      TabIndex        =   7
      Top             =   840
      Width           =   7095
      Begin VB.ComboBox cmbmonth 
         Height          =   315
         Left            =   5760
         TabIndex        =   13
         Top             =   360
         Width           =   1215
      End
      Begin VB.ComboBox cmdYear 
         Height          =   315
         Left            =   3240
         TabIndex        =   12
         Top             =   360
         Width           =   1335
      End
      Begin VB.ComboBox cmbChannel 
         Height          =   315
         Left            =   1080
         TabIndex        =   8
         Top             =   360
         Width           =   1215
      End
      Begin VB.Label Label3 
         BackStyle       =   0  'Transparent
         Caption         =   "Month "
         Height          =   255
         Left            =   4920
         TabIndex        =   11
         Top             =   360
         Width           =   1095
      End
      Begin VB.Label Label2 
         BackStyle       =   0  'Transparent
         Caption         =   "Year "
         Height          =   255
         Left            =   2520
         TabIndex        =   10
         Top             =   360
         Width           =   1215
      End
      Begin VB.Label Label1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Channel :"
         Height          =   255
         Left            =   120
         TabIndex        =   9
         Top             =   360
         Width           =   975
      End
   End
   Begin VB.PictureBox Picture1 
      BackColor       =   &H00DEC4B0&
      BorderStyle     =   0  'None
      FillStyle       =   5  'Downward Diagonal
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
      ScaleWidth      =   7215
      TabIndex        =   4
      Top             =   2640
      Width           =   7215
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
         Top             =   120
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
         Top             =   120
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
      Left            =   0
      TabIndex        =   0
      Top             =   1920
      Width           =   7095
      Begin MSComctlLib.ProgressBar ProgressBar1 
         Height          =   255
         Left            =   120
         TabIndex        =   1
         Top             =   240
         Visible         =   0   'False
         Width           =   6855
         _ExtentX        =   12091
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
      Left            =   3960
      TabIndex        =   2
      Top             =   3480
      Visible         =   0   'False
      Width           =   615
   End
   Begin VB.Label Label4 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "X"
      BeginProperty Font 
         Name            =   "System"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   6840
      TabIndex        =   14
      Top             =   0
      Width           =   495
   End
   Begin VB.Label Label5 
      BackStyle       =   0  'Transparent
      Caption         =   "Billing Order  Downloading"
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
      Left            =   240
      TabIndex        =   3
      Top             =   240
      Width           =   3495
   End
   Begin VB.Image Image2 
      Height          =   765
      Left            =   0
      Picture         =   "FrmItemPriceListUploading.frx":0CDA
      Stretch         =   -1  'True
      Top             =   0
      Width           =   7245
   End
End
Attribute VB_Name = "FrmBillingOrderDownloading"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim rsCheckRawDataFile As New ADODB.Recordset
Dim rs As New ADODB.Recordset
Dim st As New ADODB.Recordset
Dim m_year As New ADODB.Recordset
Dim m_rsmonth As New ADODB.Recordset
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
If cmbChannel.Text = "" Then
MsgBox "Pls select the company Code", vbCritical, "Error Downloaded"
Exit Sub
End If
If cmdYear.Text = "" Then
MsgBox "Pls selected the year", vbCritical, "Error Downloaded"
Exit Sub
End If
If cmbmonth.Text = "" Then
MsgBox "Pls selected the month", vbCritical, "Error Downloaded"
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
Dim rsBillingOrder As New ADODB.Recordset
Dim rsChannel As New ADODB.Recordset
Dim rsYear As New ADODB.Recordset
Dim ln, n As Long
Dim rsVisitFrequency As New ADODB.Recordset
Dim attr As SECURITY_ATTRIBUTES  'security attributes structure
Dim rval As Long
Dim t, i, z As Integer
Dim k, cnt, r, str, str2, st, mt  As String
Dim repfile, rep1 As String
Dim rsRep As ADODB.Recordset
Dim Sheet1, xappl As Object
Dim X, Y

'Set  security attributes
attr.nLength = Len(attr)  'size of the structure
attr.lpSecurityDescriptor = 0  'normal level of security
attr.bInheritHandle = 1  'default setting
' Create directory.
If rsChannel.State = 1 Then rsChannel.Close
    rsChannel.Open "Select * from DistributorItems Where Comid = '" & cmbChannel.Text & "'", cnn, adOpenKeyset
    
 ln = 0
str = "BillingOrder"

        rval = CreateDirectory("C:\MY SPMS DOWNLOAD\", attr)
        rval = CreateDirectory("C:\MY SPMS DOWNLOAD\Billing Order", attr)
        rval = CreateDirectory("C:\MY SPMS DOWNLOAD\Billing Order Downloading\" & str, attr)
        repfile = App.Path & "\Template\BillingOrder.xls "
        rep1 = App.Path & "\Template\BillingOrder.xls"
       r = App.Path & "\Reports\BillingOrder.xls"
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
    
   For Y = 1 To rsChannel.RecordCount
    ln = ln + 1
   Next Y

n = (ProgressBar1.Max / ln) * 0.99
ProgressBar1.Value = 0
    If rsChannel.State = 1 Then rsChannel.Close
    rsChannel.Open "select * from Distributor where DISTCOMID = '" & cmbChannel.Text & "'", cnn, adOpenKeyset
    If rsYear.State = 1 Then rsYear.Close
    rsYear.Open "Se"
     If rsBillingOrder.State = 1 Then rsBillingOrder.Close
            rsBillingOrder.Open "Select * from BillingOrder ", cnn, adOpenKeyset
    For X = 2 To rsBillingOrder.RecordCount + 1
         
         Sheet1.Cells(X, 1) = cmbChannel.Text
         Sheet1.Cells(X, 2) = cmdYear.Text
         Sheet1.Cells(X, 3) = cmbmonth.Text
         Sheet1.Cells(X, 4) = rsBillingOrder.Fields(1).Value
         Sheet1.Cells(X, 5) = rsBillingOrder.Fields(2).Value
         Sheet1.Cells(X, 6) = rsBillingOrder.Fields(3).Value
         Sheet1.Cells(X, 7) = rsBillingOrder.Fields(4).Value
         Sheet1.Cells(X, 8) = rsBillingOrder.Fields(5).Value
         Sheet1.Cells(X, 9) = rsBillingOrder.Fields(6).Value
         Sheet1.Cells(X, 10) = rsBillingOrder.Fields(7).Value
         Sheet1.Cells(X, 11) = rsBillingOrder.Fields(8).Value
         Sheet1.Cells(X, 12) = rsBillingOrder.Fields(9).Value
         Sheet1.Cells(X, 13) = rsBillingOrder.Fields(10).Value
         Sheet1.Cells(X, 14) = rsBillingOrder.Fields(11).Value
         Sheet1.Cells(X, 15) = rsBillingOrder.Fields(12).Value
         Sheet1.Cells(X, 16) = rsBillingOrder.Fields(13).Value
         Sheet1.Cells(X, 17) = rsBillingOrder.Fields(14).Value
         Sheet1.Cells(X, 18) = rsBillingOrder.Fields(15).Value
         Sheet1.Cells(X, 19) = rsBillingOrder.Fields(16).Value
         Sheet1.Cells(X, 20) = rsBillingOrder.Fields(17).Value
         Sheet1.Cells(X, 21) = rsBillingOrder.Fields(18).Value
         Sheet1.Cells(X, 22) = rsBillingOrder.Fields(19).Value
         Sheet1.Cells(X, 23) = rsBillingOrder.Fields(20).Value
         Sheet1.Cells(X, 24) = rsBillingOrder.Fields(21).Value
         Sheet1.Cells(X, 25) = rsBillingOrder.Fields(22).Value
         Sheet1.Cells(X, 26) = rsBillingOrder.Fields(23).Value
         Sheet1.Cells(X, 27) = rsBillingOrder.Fields(24).Value
         Sheet1.Cells(X, 28) = rsBillingOrder.Fields(25).Value
         Sheet1.Cells(X, 29) = rsBillingOrder.Fields(27).Value
         Sheet1.Cells(X, 30) = rsBillingOrder.Fields(28).Value
         Sheet1.Cells(X, 31) = rsBillingOrder.Fields(29).Value
         Sheet1.Cells(X, 32) = rsBillingOrder.Fields(30).Value
         Sheet1.Cells(X, 33) = rsBillingOrder.Fields(31).Value
         Sheet1.Cells(X, 34) = rsBillingOrder.Fields(32).Value
         Sheet1.Cells(X, 35) = rsBillingOrder.Fields(33).Value
         Sheet1.Cells(X, 36) = rsBillingOrder.Fields(34).Value
         Sheet1.Cells(X, 37) = rsBillingOrder.Fields(35).Value
         Sheet1.Cells(X, 38) = rsBillingOrder.Fields(36).Value
         Sheet1.Cells(X, 39) = rsBillingOrder.Fields(37).Value
         Sheet1.Cells(X, 40) = rsBillingOrder.Fields(38).Value
         Sheet1.Cells(X, 41) = rsBillingOrder.Fields(39).Value
         Sheet1.Cells(X, 42) = rsBillingOrder.Fields(40).Value
         Sheet1.Cells(X, 43) = rsBillingOrder.Fields(41).Value
         Sheet1.Cells(X, 44) = rsBillingOrder.Fields(42).Value
         Sheet1.Cells(X, 45) = rsBillingOrder.Fields(43).Value
         Sheet1.Cells(X, 46) = rsBillingOrder.Fields(44).Value
         Sheet1.Cells(X, 47) = rsBillingOrder.Fields(45).Value
         Sheet1.Cells(X, 48) = rsBillingOrder.Fields(46).Value
         Sheet1.Cells(X, 49) = rsBillingOrder.Fields(47).Value
         
         
    rsBillingOrder.MoveNext
    If ProgressBar1.Value + n < ProgressBar1.Max Then
        ProgressBar1.Value = ProgressBar1.Value + n
    Else
        ProgressBar1.Value = ProgressBar1.Max
    End If
    Next X
 
    xappl.ActiveWorkbook.SaveAs ("C:\MY SPMS DOWNLOAD\Billing Order\" & str & ".xls")
    xappl.Visible = True
    xappl.ActiveWorkbook.Close
    xappl.Visible = False
    Set Sheet1 = Nothing
    Set xappl = Nothing

End Sub


Private Sub LoadYear()
Dim m_year As New ADODB.Recordset
Dim m
        If m_year.State = 1 Then m_year.Close
        m_year.Open "SELECT Distinct CAYR  FROM Calendar WHERE COMID = '" & cmbChannel.Text & "'", cnn, adOpenKeyset
       
        
            For m = 1 To m_year.RecordCount
                cmdYear.AddItem (m_year.Fields("CAYR").Value)
                m_year.MoveNext
            Next m
        
    End Sub
    Private Sub LoadMonth()
    Dim m_rsmonth As New ADODB.Recordset
    Dim m
        If m_rsmonth.State = 1 Then m_rsmonth.Close
        
         m_rsmonth.Open "SELECT * FROM Calendar WHERE COMID = '" & cmbChannel.Text & "' AND CAYR = '" & cmdYear.Text & "'", cnn, adOpenKeyset

        If m_rsmonth.RecordCount > 0 Then
            For m = 1 To m_rsmonth.RecordCount
                cmbmonth.AddItem (m_rsmonth.Fields("CAPN").Value)
                m_rsmonth.MoveNext
            Next
        End If

    End Sub

Private Sub cmbChannel_Change()

       ' Dim m_year As New ADODB.Recordset
        'Dim m
       ' If m_year.State = 1 Then m_year.Close
       ' m_year.Open "SELECT Distinct CAYR  FROM Calendar WHERE COMID = '" & cmbChannel.Text & "'", cnn, adOpenKeyset
      
        
           ' For m = 1 To m_year.RecordCount
              '  cmdYear.AddItem (m_year.Fields("CAYR").Value)
             '   m_year.MoveNext
          '  Next m
     
End Sub

Private Sub cmbChannel_Click()

  Dim m_year As New ADODB.Recordset
       Dim m
       If m_year.State = 1 Then m_year.Close
                m_year.Open "SELECT Distinct CAYR  FROM Calendar WHERE COMID = '" & cmbChannel.Text & "'", cnn, adOpenKeyset
                    For m = 1 To m_year.RecordCount
                cmdYear.AddItem (m_year.Fields("CAYR").Value)
            m_year.MoveNext
        Next m
End Sub

Private Sub cmdYear_Change()
        LoadMonth
End Sub

Private Sub cmdYear_Click()
        LoadMonth
End Sub

Private Sub Label4_Click()
Unload Me
End Sub

Private Sub lblClose_Click()
Unload Me
End Sub

Private Sub lblUpload_Click()
cmdImport_Click
End Sub

Private Sub Form_Load()
SQLConnect
 If m_year.State = 1 Then m_year.Close
    m_year.Open "SELECT *  FROM Calendar ", cnn, adOpenKeyset
    LoadYear
   If m_rsmonth.State = 1 Then m_rsmonth.Close
         m_rsmonth.Open "SELECT * FROM Calendar ", cnn, adOpenKeyset
         LoadMonth
papulartion

End Sub

Private Sub papulartion()
Dim rsChannel As New ADODB.Recordset
Dim X

If rsChannel.State = 1 Then rsChannel.Close
    rsChannel.Open "Select Distcomid From Distributor where dltflg = 0", cnn, adOpenKeyset
cmbChannel.AddItem "All"
For X = 1 To rsChannel.RecordCount
    cmbChannel.AddItem rsChannel.Fields(0).Value
rsChannel.MoveNext
Next X
LoadYear
End Sub
