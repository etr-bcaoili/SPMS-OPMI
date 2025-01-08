VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomctl.ocx"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Begin VB.Form FrmCustomerMappingDownloading 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Customer Mapping Downloading"
   ClientHeight    =   3210
   ClientLeft      =   4185
   ClientTop       =   3990
   ClientWidth     =   7020
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
   ScaleHeight     =   3210
   ScaleWidth      =   7020
   StartUpPosition =   1  'CenterOwner
   Begin MSComCtl2.DTPicker dtFrom 
      Height          =   330
      Left            =   4920
      TabIndex        =   9
      Top             =   960
      Width           =   1695
      _ExtentX        =   2990
      _ExtentY        =   582
      _Version        =   393216
      Format          =   20316161
      CurrentDate     =   40471
   End
   Begin VB.ComboBox cboChannel 
      Height          =   315
      Left            =   1080
      TabIndex        =   7
      Top             =   960
      Width           =   1815
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
      Top             =   2520
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
      Top             =   1800
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
   Begin MSComCtl2.DTPicker dtTo 
      Height          =   330
      Left            =   4920
      TabIndex        =   10
      Top             =   1320
      Width           =   1695
      _ExtentX        =   2990
      _ExtentY        =   582
      _Version        =   393216
      Format          =   20316161
      CurrentDate     =   40471
   End
   Begin VB.Label Label3 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Effectivity End Date :"
      Height          =   255
      Left            =   3120
      TabIndex        =   12
      Top             =   1320
      Width           =   1935
   End
   Begin VB.Label Label2 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Effectivity Start Date :"
      Height          =   255
      Left            =   3120
      TabIndex        =   11
      Top             =   1020
      Width           =   1935
   End
   Begin VB.Label Label1 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Channel :"
      Height          =   255
      Left            =   240
      TabIndex        =   8
      Top             =   960
      Width           =   855
   End
   Begin VB.Label Label5 
      BackStyle       =   0  'Transparent
      Caption         =   "Customer Mapping Downloading"
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
Attribute VB_Name = "FrmCustomerMappingDownloading"
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
Dim m As Integer

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
Dim rsCustomerGroup As New ADODB.Recordset
Dim rsCustomerMapping As New ADODB.Recordset
Dim rsRegion As New ADODB.Recordset
Dim rsDistrict As New ADODB.Recordset
Dim rsArea As New ADODB.Recordset
Dim rsAreaCoverage As New ADODB.Recordset

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
If rsCustomerMapping.State = 1 Then rsCustomerMapping.Close
    If cboChannel.Text <> "" Then
    rsCustomerMapping.Open "Select * from CustomerMapping WHERE DLTFLG = '" & "0" & "' AND ISACTIVE = '" & "1" & "'  AND EffectivityStartDate = '" & Format(dtFrom.Value, "MM/dd/yyyy") & "' AND EffectivityEndDate = '" & Format(dtTo.Value, "MM/dd/yyyy") & "' AND ComID = '" & cboChannel.Text & "'  ", cnn, adOpenKeyset
    Else
    rsCustomerMapping.Open "Select * from CustomerMapping WHERE DLTFLG = '" & "0" & "' AND ISACTIVE = '" & "1" & "'  AND EffectivityStartDate = '" & Format(dtFrom.Value, "MM/dd/yyyy") & "' AND EffectivityEndDate = '" & Format(dtTo.Value, "MM/dd/yyyy") & "' ", cnn, adOpenKeyset
    End If
    
    
 ln = 0
str = "CUSTOMER MAPPING"

        rval = CreateDirectory("C:\MY SPMS DOWNLOAD\", attr)
        rval = CreateDirectory("C:\MY SPMS DOWNLOAD\CUSTOMER MAPPING DOWNLOADS", attr)
        
        repfile = App.Path & "\Template\CustomerMapping.xls"
        rep1 = App.Path & "\Template\CustomerMapping.xls"
        r = App.Path & "\Template\CustomerMapping.xls"
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
    
   For y = 1 To rsCustomerMapping.RecordCount
    ln = ln + 1
   Next y

    n = (ProgressBar1.Max / ln) * 0.99
    ProgressBar1.Value = 0
    
    
    For x = 2 To rsCustomerMapping.RecordCount + 1
       

         'Sheet1.Cells(x, 1) = rsCustomerMapping.Fields(0).Value
         Sheet1.Cells(x, 1) = rsCustomerMapping.Fields(9).Value
         Sheet1.Cells(x, 2) = "'" & rsCustomerMapping.Fields(1).Value
         
         If rsCustomerGroup.State Then rsCustomerGroup.Close
            rsCustomerGroup.Open "Select CustomerGroupName From CustomerGroup Where CustomerGroupCd = '" & rsCustomerMapping.Fields(1).Value & "' AND DLTFLG = '" & "0" & "'", cnn, adOpenKeyset
         
         Sheet1.Cells(x, 3) = rsCustomerGroup.Fields(0).Value
         Sheet1.Cells(x, 4) = "'" & rsCustomerMapping.Fields(2).Value
         
         If rsRegion.State = 1 Then rsRegion.Close
            rsRegion.Open "Select RegName From Region Where Regcd = '" & rsCustomerMapping.Fields(2).Value & "' AND DLTFLG = '" & "0" & "'", cnn, adOpenKeyset
            
         Sheet1.Cells(x, 5) = rsRegion.Fields(0).Value
         Sheet1.Cells(x, 6) = "'" & rsCustomerMapping.Fields(3).Value
         
         If rsDistrict.State = 1 Then rsDistrict.Close
            rsDistrict.Open "Select DISTRCTNAME From District Where DistrctCd = '" & rsCustomerMapping.Fields(3).Value & "' And DLTFLG = '" & "0" & "'", cnn, adOpenKeyset
         
         Sheet1.Cells(x, 7) = rsDistrict.Fields(0).Value
         Sheet1.Cells(x, 8) = "'" & rsCustomerMapping.Fields(4).Value
         
         If rsArea.State = 1 Then rsArea.Close
            rsArea.Open "Select AreaName From Area Where AreaCd = '" & rsCustomerMapping.Fields(4).Value & "' AND DLTFLG = '" & "0" & "'", cnn, adOpenKeyset
         Sheet1.Cells(x, 9) = rsArea.Fields(0).Value
         Sheet1.Cells(x, 10) = "'" & rsCustomerMapping.Fields(5).Value
         Sheet1.Cells(x, 11) = "'" & rsCustomerMapping.Fields(6).Value
         
         If rsCustomer.State = 1 Then rsCustomer.Close
            rsCustomer.Open "Select * from Customer where CustomerCd = '" & rsCustomerMapping.Fields(6).Value & "' AND COMID = '" & rsCustomerMapping.Fields(9).Value & "' AND CUSTOMERDEL = '" & "0" & "'", cnn, adOpenKeyset
         Sheet1.Cells(x, 12) = rsCustomer.Fields(4).Value
         Sheet1.Cells(x, 13) = rsCustomer.Fields(6).Value
         
         Sheet1.Cells(x, 14) = rsCustomerMapping.Fields(7).Value
         If rsAreaCoverage.State = 1 Then rsAreaCoverage.Close
            rsAreaCoverage.Open "Select STACOVNAME From StAreaCoverage Where STACOVCD = '" & rsCustomerMapping.Fields(7).Value & "' AND DLTFLG = '" & "0" & "'", cnn, adOpenKeyset
         Sheet1.Cells(x, 15) = rsAreaCoverage.Fields(0).Value
         Sheet1.Cells(x, 16) = "'" & rsCustomerMapping.Fields(10).Value
         Sheet1.Cells(x, 17) = rsCustomerMapping.Fields(11).Value
         Sheet1.Cells(x, 18) = rsCustomerMapping.Fields(12).Value
         Sheet1.Cells(x, 19) = rsCustomerMapping.Fields(13).Value
         
         
    rsCustomerMapping.MoveNext
    
    If ProgressBar1.Value + n < ProgressBar1.Max Then
        ProgressBar1.Value = ProgressBar1.Value + n
    Else
        ProgressBar1.Value = ProgressBar1.Max
    End If
    Next x
 
    xappl.ActiveWorkbook.SaveAs ("C:\MY SPMS DOWNLOAD\CUSTOMER MAPPING DOWNLOADS\" & str & ".xls")
    xappl.Visible = True
    xappl.ActiveWorkbook.Close
    xappl.Visible = False
    Set Sheet1 = Nothing
    Set xappl = Nothing

End Sub



Private Sub lblClose_Click()
Unload Me
End Sub

Private Sub lblUpload_Click()
cmdImport_Click
End Sub

Private Sub Form_Load()
SQLConnect

If rsCompany.State = 1 Then rsCompany.Close
rsCompany.Open "SELECT Distinct DISTCOMID From Distributor Where DLTFLG = 0 ", cnn, adOpenKeyset

If rsCompany.RecordCount > 0 Then

cboChannel.Clear
For m = 0 To rsCompany.RecordCount - 1
cboChannel.AddItem rsCompany.Fields("DISTCOMID").Value
rsCompany.MoveNext
Next m

End If

End Sub
