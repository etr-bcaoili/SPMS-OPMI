VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form FrmCustomerDownloading 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Customer Downloading"
   ClientHeight    =   2565
   ClientLeft      =   4185
   ClientTop       =   3990
   ClientWidth     =   5460
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
   ScaleHeight     =   2565
   ScaleWidth      =   5460
   StartUpPosition =   1  'CenterOwner
   Begin VB.ComboBox cmbChannel 
      Height          =   315
      Left            =   1560
      TabIndex        =   8
      Top             =   840
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
      Top             =   1920
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
         Left            =   4560
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
         Left            =   3600
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
      Left            =   120
      TabIndex        =   0
      Top             =   1200
      Width           =   5175
      Begin MSComctlLib.ProgressBar ProgressBar1 
         Height          =   255
         Left            =   120
         TabIndex        =   1
         Top             =   240
         Visible         =   0   'False
         Width           =   4935
         _ExtentX        =   8705
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
   Begin VB.Label Label1 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Channel Code :"
      Height          =   255
      Left            =   240
      TabIndex        =   7
      Top             =   840
      Width           =   1215
   End
   Begin VB.Label Label5 
      BackStyle       =   0  'Transparent
      Caption         =   "Customer Downloading"
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
Attribute VB_Name = "FrmCustomerDownloading"
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
Dim rsCustomerShipTo As New ADODB.Recordset
Dim rsRegion As New ADODB.Recordset
Dim rsProvince As New ADODB.Recordset
Dim rsMunicipality As New ADODB.Recordset
Dim rsCustomerGroup As New ADODB.Recordset
Dim rsCustomerClass As New ADODB.Recordset
Dim ln, n As Long
Dim rsVisitFrequency As New ADODB.Recordset
Dim attr As SECURITY_ATTRIBUTES  'security attributes structure
Dim rval As Long
Dim t, i, z As Integer
Dim k, cnt, r, str, str2, st, mt, AccountShared As String
Dim repfile, rep1 As String
Dim rsRep As ADODB.Recordset
Dim Sheet1, xappl As Object
Dim x, y, q, a

'Set  security attributes
attr.nLength = Len(attr)  'size of the structure
attr.lpSecurityDescriptor = 0  'normal level of security
attr.bInheritHandle = 1  'default setting
' Create directory.

If cmbChannel.Text = "All" Then
If rsCustomer.State = 1 Then rsCustomer.Close
    rsCustomer.Open "Select * from Customer Where CustomerDel = '" & "0" & "' AND DISTRIBCD = '" & "" & "'", cnn, adOpenKeyset
    Else
    If rsCustomer.State = 1 Then rsCustomer.Close
    rsCustomer.Open "Select * from Customer Where Comid = '" & cmbChannel.Text & "' AND CustomerDel = '" & "0" & "' AND DISTRIBCD = '" & "" & "'", cnn, adOpenKeyset
    End If
 ln = 0
'str = "CUSTOMER - " & cmbChannel.Text & " AS OF : " & Format(Now, "MM/dd/yyyy")
str = "CUSTOMER"
        rval = CreateDirectory("C:\MY SPMS DOWNLOAD\", attr)
        rval = CreateDirectory("C:\MY SPMS DOWNLOAD\CUSTOMER DOWNLOADS", attr)
        
        repfile = App.Path & "\Template\Customer.xls"
        rep1 = App.Path & "\Template\Customer.xls"
        r = App.Path & "\Temaplate\Customer.xls"
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
    
   For y = 1 To rsCustomer.RecordCount
    ln = ln + 1
   Next y

n = (ProgressBar1.Max / ln) * 0.99
ProgressBar1.Value = 0
    a = 1
    For x = 1 To rsCustomer.RecordCount
       
        If rsCustomerShipTo.State = 1 Then rsCustomerShipTo.Close
            rsCustomerShipTo.Open "Select * from CustomerShipTo where Comid = '" & rsCustomer.Fields(2).Value & "' " & _
                "AND CUSTOMERCD = '" & rsCustomer.Fields(3).Value & "'", cnn, adOpenKeyset
        If rsCustomerShipTo.RecordCount <> 0 Then
        q = 0
        For q = 1 To rsCustomerShipTo.RecordCount
          a = a + 1
         Sheet1.Cells(a, 1) = rsCustomer.Fields(2).Value
         Sheet1.Cells(a, 2) = "'" & rsCustomer.Fields(3).Value
         Sheet1.Cells(a, 3) = rsCustomer.Fields(4).Value
         Sheet1.Cells(a, 4) = "'" & rsCustomerShipTo.Fields(3).Value
         Sheet1.Cells(a, 5) = rsCustomerShipTo.Fields(4).Value
         Sheet1.Cells(a, 6) = rsCustomer.Fields(6).Value
         Sheet1.Cells(a, 7) = rsCustomer.Fields(7).Value
         Sheet1.Cells(a, 8) = rsCustomer.Fields(13).Value
         If rsRegion.State = 1 Then rsRegion.Close
            rsRegion.Open "select Regname from Region where Regcd = '" & rsCustomer.Fields(13).Value & "' And DLTFLG = '" & "0" & "'", cnn, adOpenKeyset
            
         Sheet1.Cells(a, 9) = rsRegion.Fields(0).Value
         Sheet1.Cells(a, 10) = rsCustomer.Fields(14).Value
         If rsProvince.State = 1 Then rsProvince.Close
                rsProvince.Open "Select DistrctName From District Where DistrctCd = '" & rsCustomer.Fields(14).Value & "' And DLTFLG = '" & "0" & "'", cnn, adOpenKeyset
         
         Sheet1.Cells(a, 11) = rsProvince.Fields(0).Value
         Sheet1.Cells(a, 12) = "'" & rsCustomer.Fields(15).Value
         If rsMunicipality.State = 1 Then rsMunicipality.Close
            rsMunicipality.Open "select AreaName From Area Where AreaCd = '" & rsCustomer.Fields(15).Value & "' And DLTFLG = '" & "0" & "'", cnn, adOpenKeyset
         Sheet1.Cells(a, 13) = rsMunicipality.Fields(0).Value
         
         Sheet1.Cells(a, 14) = rsCustomer.Fields(12).Value
         Sheet1.Cells(a, 15) = rsCustomer.Fields(17).Value
         If rsCustomerGroup.State = 1 Then rsCustomerGroup.Close
            rsCustomerGroup.Open "Select * from CustomerGroup Where CustomerGroupcd = '" & rsCustomer.Fields(17).Value & "' AND DLTFLG = '" & "0" & "'", cnn, adOpenKeyset
         Sheet1.Cells(a, 16) = rsCustomerGroup.Fields(3).Value
         Sheet1.Cells(a, 17) = rsCustomer.Fields(18).Value
         If rsCustomerClass.State = 1 Then rsCustomerClass.Close
            rsCustomerClass.Open "Select * From CustomerClass Where CustomerClasscd = '" & rsCustomer.Fields(18).Value & "' AND DLTFLG = '" & "0" & "'", cnn, adOpenKeyset
         Sheet1.Cells(a, 18) = rsCustomerClass.Fields(4).Value
         If rsCustomer.Fields("ACCNTSHRD").Value = 0 Then
         Sheet1.Cells(a, 19) = "No"
         Else
         Sheet1.Cells(a, 19) = "Yes"
         End If
         rsCustomerShipTo.MoveNext
    If ProgressBar1.Value + n < ProgressBar1.Max Then
        ProgressBar1.Value = ProgressBar1.Value + n
    Else
        ProgressBar1.Value = ProgressBar1.Max
    End If
         Next q
         End If
    rsCustomer.MoveNext
 
    Next x
 
    xappl.ActiveWorkbook.SaveAs ("C:\MY SPMS DOWNLOAD\CUSTOMER DOWNLOADS\" & str & ".xls")
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
Dim rsDistributor As New ADODB.Recordset
Dim x
If rsDistributor.State = 1 Then rsDistributor.Close
    rsDistributor.Open "select Distinct(DistComid) From Distributor Where DLTFLG = '" & "0" & "'", cnn, adOpenKeyset
cmbChannel.AddItem "All"
If rsDistributor.RecordCount <> 0 Then

  For x = 1 To rsDistributor.RecordCount
        cmbChannel.AddItem rsDistributor.Fields(0).Value
        rsDistributor.MoveNext
        
  Next x
End If
    

End Sub
