VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form FrmSalesTargetUplaoding 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Sales Target Uploading"
   ClientHeight    =   3450
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
   ScaleHeight     =   3450
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
         MouseIcon       =   "FrmSalesTargetUploading.frx":0000
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
      Caption         =   "Sales Target Uploading"
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
      Width           =   3135
   End
   Begin VB.Image Image2 
      Height          =   765
      Left            =   0
      Picture         =   "FrmSalesTargetUploading.frx":0CDA
      Stretch         =   -1  'True
      Top             =   0
      Width           =   7125
   End
End
Attribute VB_Name = "FrmSalesTargetUplaoding"
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
Dim rsSalesMatrix As New ADODB.Recordset
Dim rsItem As New ADODB.Recordset
Dim rsRawdata As New ADODB.Recordset

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
    
    
cnn.Execute "Delete From territoryitemtarget WHERE  MONTH = '" & Trim(objWorksheet.Cells(2, 5)) & "' AND YEAR = '" & Trim(objWorksheet.Cells(2, 4)) & "'"
n = (ProgressBar1.Max / ln) * 0.99
ProgressBar1.Value = 0

'On Error Resume Next

i = 2
    Do While objWorksheet.Cells(i, 1) <> ""
   ' If co = "MD" And prn = "650" Then
         
     
        
'        If rsSalesMatrix.State = 1 Then rsSalesMatrix.Close
'        rsSalesMatrix.Open " Select STTERRCD,STITMDIVCD " & _
'                            " from SalesMatrix " & _
'                            " Where MONTH(EffectivityStartDate) = '" & Replace(Trim(objWorksheet.Cells(i, 6)), "'", "") & "' " & _
'                            " AND MONTH(EffectivityEndDate) = '" & Replace(Trim(objWorksheet.Cells(i, 6)), "'", "") & "' " & _
'                            " AND YEAR(EffectivityStartDate) = '" & Replace(Trim(objWorksheet.Cells(i, 5)), "'", "") & "' " & _
'                            " AND YEAR(EffectivityEndDate) = '" & Replace(Trim(objWorksheet.Cells(i, 5)), "'", "") & "' " & _
'                            " AND DLTFLG = 0 " & _
'                            " AND STTERRCD = '" & Replace(Trim(objWorksheet.Cells(i, 2)), "'", "") & "'", cnn, adOpenKeyset
'
'        If rsSalesMatrix.RecordCount <> 0 Then
'
'        For x = 1 To rsSalesMatrix.RecordCount
        
        If rsItem.State = 1 Then rsItem.Close
            rsItem.Open "Select * from Item Where Itemcd = '" & Replace(Trim(objWorksheet.Cells(i, 3)), "'", "") & "' ", cnn, adOpenKeyset
        If rsItem.RecordCount <> 0 Then
        
        Dim cmdSalesTargetUploading As ADODB.Command
        Set cmdSalesTargetUploading = New ADODB.Command
      
        cmdSalesTargetUploading.ActiveConnection = cnn
        cmdSalesTargetUploading.CommandType = adCmdStoredProc
        cmdSalesTargetUploading.CommandText = "uspTerritoryItemTarget"
        cmdSalesTargetUploading.Parameters.Append cmdSalesTargetUploading.CreateParameter("@Action", adVarChar, adParamInput, 100, "SAVE")
        cmdSalesTargetUploading.Parameters.Append cmdSalesTargetUploading.CreateParameter("@TerritoryItemTargetID", adInteger, adParamInput, , -1)
        cmdSalesTargetUploading.Parameters.Append cmdSalesTargetUploading.CreateParameter("@ComID", adVarChar, adParamInput, 25, Trim(objWorksheet.Cells(i, 1)))
        cmdSalesTargetUploading.Parameters.Append cmdSalesTargetUploading.CreateParameter("@STTERRCD", adVarChar, adParamInput, 25, Trim(objWorksheet.Cells(i, 2)))
        cmdSalesTargetUploading.Parameters.Append cmdSalesTargetUploading.CreateParameter("@YEAR", adInteger, adParamInput, , Replace(Trim(objWorksheet.Cells(i, 5)), "'", ""))
        cmdSalesTargetUploading.Parameters.Append cmdSalesTargetUploading.CreateParameter("@MONTH", adVarChar, adParamInput, 2, Replace(Trim(objWorksheet.Cells(i, 6)), "'", ""))
        cmdSalesTargetUploading.Parameters.Append cmdSalesTargetUploading.CreateParameter("@ITEMCD", adVarChar, adParamInput, 25, Replace(Trim(objWorksheet.Cells(i, 3)), "'", ""))
        cmdSalesTargetUploading.Parameters.Append cmdSalesTargetUploading.CreateParameter("@Quantity", adNumeric, adParamInput, , Trim(objWorksheet.Cells(i, 8)))
        cmdSalesTargetUploading.Parameters("@Quantity").Precision = 11
        cmdSalesTargetUploading.Parameters("@Quantity").NumericScale = 6
        cmdSalesTargetUploading.Parameters.Append cmdSalesTargetUploading.CreateParameter("@Amount", adDouble, adParamInput, , Trim(objWorksheet.Cells(i, 10)))
        cmdSalesTargetUploading.Parameters.Append cmdSalesTargetUploading.CreateParameter("@SalesTarget", adDouble, adParamInput, , Trim(objWorksheet.Cells(i, 11)))
        
        
        cmdSalesTargetUploading.Execute
        End If
'        rsSalesMatrix.MoveNext
        
'        Next x
'
'        End If
        
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
