VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form FrmItemPriceListUplaoding 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Price List Uploading"
   ClientHeight    =   3495
   ClientLeft      =   4185
   ClientTop       =   3990
   ClientWidth     =   7035
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
   ScaleHeight     =   3495
   ScaleWidth      =   7035
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
      Left            =   -120
      ScaleHeight     =   615
      ScaleWidth      =   8175
      TabIndex        =   7
      Top             =   2880
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
         TabIndex        =   9
         Top             =   240
         Width           =   615
      End
      Begin VB.Label lblUpload 
         BackColor       =   &H80000009&
         BackStyle       =   0  'Transparent
         Caption         =   "Upload"
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
         Left            =   5760
         TabIndex        =   8
         Top             =   240
         Width           =   735
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
      Height          =   1935
      Left            =   120
      TabIndex        =   0
      Top             =   840
      Width           =   6855
      Begin VB.TextBox txtfile 
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   315
         Left            =   1080
         Locked          =   -1  'True
         TabIndex        =   1
         Top             =   840
         Width           =   5565
      End
      Begin MSComctlLib.ProgressBar ProgressBar1 
         Height          =   255
         Left            =   120
         TabIndex        =   2
         Top             =   1440
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
      Begin VB.Label Label2 
         BackStyle       =   0  'Transparent
         Caption         =   "Please select file to be uploaded"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FF0000&
         Height          =   255
         Left            =   120
         TabIndex        =   4
         Top             =   360
         Width           =   3615
      End
      Begin VB.Label lblBrowseFile 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "File:"
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
         Height          =   210
         Left            =   120
         TabIndex        =   3
         Top             =   960
         Width           =   330
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
      Left            =   6480
      TabIndex        =   5
      Top             =   1800
      Visible         =   0   'False
      Width           =   615
   End
   Begin VB.Label Label5 
      BackStyle       =   0  'Transparent
      Caption         =   "Price List Uploading"
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
      TabIndex        =   6
      Top             =   120
      Width           =   2295
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
Attribute VB_Name = "FrmItemPriceListUplaoding"
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

Private Sub cmdfile_Click()
    CommonDialog1.CancelError = True
    On Error Resume Next
    CommonDialog1.Filter = "Excel files(*.xls)|*.xls"
    CommonDialog1.ShowOpen
    txtfile.Text = CommonDialog1.FileName
   
End Sub

Private Sub cmdImport_Click()
'-----------------------------------------------------------
'FOR MDI
    
 If txtfile = "" Then
 
    MsgBox "No file to be uploaded", vbInformation, "Please select file"
    Exit Sub
 End If
    repfile = txtfile.Text
    urec = 0
    

ProgressBar1.Visible = True
    ImportData
    If urec = 0 Then
        MsgBox "File not found!", vbCritical
   Else

       MsgBox "Importing Data complete! "
       Unload Me
  End If
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
Dim rsDistributorItemPrice As New ADODB.Recordset

Dim strdata As String
Dim ln, i As Long

 repfile = txtfile.Text

    StartExcel
    
    objExcel.Visible = False

    Set objWorkbook = objExcel.Workbooks.Open(repfile)
    Set objWorksheet = objWorkbook.ActiveSheet

'On Error Resume Next

    ln = 0
    i = 2

    Do While objWorksheet.Cells(i, 1) <> ""  ' Loop until end of file.
        
        dte = Format(Trim(objWorksheet.Cells(i, 2)), "yyyymmdd")
       
            ln = ln + 1
    
       i = i + 1
    Loop
    
    If ln <= 0 Then
        urec = 0
        
        Exit Sub
     Else
        urec = 1
    End If
    
n = (ProgressBar1.Max / ln) * 0.99
ProgressBar1.Value = 0

'On Error Resume Next

i = 2
    Do While objWorksheet.Cells(i, 1) <> ""
   ' If co = "MD" And prn = "650" Then
         
If rsDistributorItemPrice.State = 1 Then rsDistributorItemPrice.Close
    rsDistributorItemPrice.Open "Select * from DistributorItems Where Comid = '" & Trim(objWorksheet.Cells(i, 1)) & "' And Itemcd = '" & Trim(objWorksheet.Cells(i, 2)) & "'And DistItemcd = '" & Trim(objWorksheet.Cells(i, 3)) & "' " & _
        "AND convert(varchar(25), effectivitystartdate, 101) = cast('" & objWorksheet.Cells(i, 6) & "' as datetime ) " & _
        "AND convert(varchar(25), effectivityenddate, 101) = cast('" & objWorksheet.Cells(i, 7) & "' as datetime )", cnn, adOpenKeyset
         
  If rsDistributorItemPrice.RecordCount <> 0 Then
        
        cnn.Execute "Update DistributorItems Set CompanyPrice = '" & Trim(objWorksheet.Cells(i, 8)) & "' , DISTITEMPRICE = '" & Trim(objWorksheet.Cells(i, 5)) & "' Where Comid = '" & Trim(objWorksheet.Cells(i, 1)) & "' And Itemcd = '" & Trim(objWorksheet.Cells(i, 2)) & "' And DistItemcd = '" & Trim(objWorksheet.Cells(i, 3)) & "'" & _
        "AND convert(varchar(25), effectivitystartdate, 101) = cast('" & objWorksheet.Cells(i, 6) & "' as datetime ) " & _
        "AND convert(varchar(25), effectivityenddate, 101) = cast('" & objWorksheet.Cells(i, 7) & "' as datetime ) AND ISACTIVE = '" & "1" & "' "
        
  Else
    
    Dim cmdCustomerUploading As ADODB.Command
    Set cmdCustomerUploading = New ADODB.Command
        
        cmdCustomerUploading.ActiveConnection = cnn
        cmdCustomerUploading.CommandType = adCmdStoredProc
        cmdCustomerUploading.CommandText = "uspDistributorItems"
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@Action", adVarChar, adParamInput, 100, "SAVE")
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@Comid", adVarChar, adParamInput, 25, Trim(objWorksheet.Cells(i, 1)))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@Itemcd", adVarChar, adParamInput, 25, Trim(objWorksheet.Cells(i, 2)))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@DistItemcd", adVarChar, adParamInput, 25, Trim(objWorksheet.Cells(i, 3)))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@ItemName", adVarChar, adParamInput, 255, Trim(objWorksheet.Cells(i, 4)))
        
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@DistItemPrice", adNumeric, adParamInput, , Trim(objWorksheet.Cells(i, 5)))
        cmdCustomerUploading.Parameters("@DistItemPrice").Precision = 19
       cmdCustomerUploading.Parameters("@DistItemPrice").NumericScale = 4
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CompanyPrice", adNumeric, adParamInput, , Trim(objWorksheet.Cells(i, 5)))
        cmdCustomerUploading.Parameters("@CompanyPrice").Precision = 19
       cmdCustomerUploading.Parameters("@CompanyPrice").NumericScale = 6
          
       ' cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@OldDistItemcd", adVarChar, adParamInput, 25, "")
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@EffectivityStartDate", adDate, adParamInput, 20, Trim(objWorksheet.Cells(i, 6)))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@EffectivityEndDate", adDate, adParamInput, 20, Trim(objWorksheet.Cells(i, 7)))

               
        
        cmdCustomerUploading.Execute
        
    End If
        i = i + 1
        urec = urec + 1
   ' End If
   
    
    If ProgressBar1.Value + n < ProgressBar1.Max Then
        ProgressBar1.Value = ProgressBar1.Value + n
    Else
        ProgressBar1.Value = ProgressBar1.Max
    End If
   
Loop

 objExcel.Workbooks.Close

Close #inthandle
inthandle = FreeFile
End Sub



Private Sub lblBrowseFile_Click()
cmdfile_Click
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


