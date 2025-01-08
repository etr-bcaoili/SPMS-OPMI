VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomctl.ocx"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form FrmCustomerUplaoding 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Customer Uploading"
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
         MouseIcon       =   "FrmCustomerUploading.frx":0000
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
      Caption         =   "Customer Uploading"
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
      Picture         =   "FrmCustomerUploading.frx":0CDA
      Stretch         =   -1  'True
      Top             =   0
      Width           =   7125
   End
End
Attribute VB_Name = "FrmCustomerUplaoding"
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
       UpdateCustomerGeographicalMap
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
   Dim rsCustomer As New ADODB.Recordset
   If rsCustomer.State = 1 Then rsCustomer.Close
    rsCustomer.Open "Select * from Customer Where Comid = '" & Trim(objWorksheet.Cells(i, 1)) & "' And Customercd = '" & Trim(objWorksheet.Cells(i, 2)) & "' And CustomerDel = '" & "0" & "'", cnn, adOpenKeyset
   Dim cmdCustomerUploading As ADODB.Command
    Set cmdCustomerUploading = New ADODB.Command
   
        Dim cmdCustomerUploadingShipTo As ADODB.Command
        Set cmdCustomerUploadingShipTo = New ADODB.Command
   If rsCustomer.RecordCount > 0 Then
   
        
        cmdCustomerUploading.ActiveConnection = cnn
        cmdCustomerUploading.CommandType = adCmdStoredProc
        cmdCustomerUploading.CommandText = "uspCustomer"
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CustomerDEL", adBoolean, adParamInput, , 0)
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@Comid", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 1)))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CustomerCD", adVarChar, adParamInput, 20, Replace(Trim(objWorksheet.Cells(i, 2)), "'", ""))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CustomerNAME", adVarChar, adParamInput, 255, Replace(Trim(objWorksheet.Cells(i, 3)), "'", ""))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@DistribCD", adVarChar, adParamInput, 20, "")
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CADD1", adVarChar, adParamInput, 255, Replace(Trim(objWorksheet.Cells(i, 6)), "'", ""))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CADD2", adVarChar, adParamInput, 255, Replace(Trim(objWorksheet.Cells(i, 7)), "'", ""))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@Cmcont", adVarChar, adParamInput, 20, "")
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@Cmphon", adVarChar, adParamInput, 20, "")
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@Vat", adBoolean, adParamInput, , 0)
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CDACD", adVarChar, adParamInput, 20, Replace(Trim(objWorksheet.Cells(i, 4)), "'", ""))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@ZIPCD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 14)))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@REGCD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 8)))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@DISTCD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 10)))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@AREACD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 12)))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@TERRCD", adVarChar, adParamInput, 20, "")
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CMGRP", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 15)))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CMCLASS", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 17)))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@AREACOVRG", adVarChar, adParamInput, 20, "")
        If Trim(objWorksheet.Cells(i, 19)) = "No" Then
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@ACCNTSHRD", adBoolean, adParamInput, , 0)
        Else
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@ACCNTSHRD", adBoolean, adParamInput, , 1)
        End If
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CRTDDTE", adDate, adParamInput, , Date)
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CRTDBY", adVarChar, adParamInput, 50, "")
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@Action", adVarChar, adParamInput, 10, "UPDATE")
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@OLDCUSTCODE", adVarChar, adParamInput, 20, Replace(Trim(objWorksheet.Cells(i, 2)), "'", ""))
    
        
        cmdCustomerUploading.Execute
        
        
        cmdCustomerUploadingShipTo.ActiveConnection = cnn
        cmdCustomerUploadingShipTo.CommandType = adCmdStoredProc
        cmdCustomerUploadingShipTo.CommandText = "uspCustomerShipTo"
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CUSTOMERSHIPTODEL", adBoolean, adParamInput, , 0)
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CUSTOMERCD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 2)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CDACD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 4)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CDANAME", adVarChar, adParamInput, 255, Trim(objWorksheet.Cells(i, 5)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CDACADD1", adVarChar, adParamInput, 255, Trim(objWorksheet.Cells(i, 6)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CDACADD2", adVarChar, adParamInput, 255, Trim(objWorksheet.Cells(i, 7)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CDACONT", adVarChar, adParamInput, 255, "")
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CDAPHON", adVarChar, adParamInput, 20, "")
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@ZIPCD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 14)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@REGCD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 8)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@DISTCD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 10)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@AREACD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 12)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@TERRCD", adVarChar, adParamInput, 20, "")
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CMGRP", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 15)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CMCLASS", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 17)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@AREACOVRG", adVarChar, adParamInput, 20, "")
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@ACCNTSHRD", adVarChar, adParamInput, 20, "")
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CRTDDTE", adDate, adParamInput, , "1/1/1900")
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CRTDBY", adVarChar, adParamInput, 50, "")
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@ACTION", adVarChar, adParamInput, 10, "UPDATE")
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@COMID", adVarChar, adParamInput, 25, Trim(objWorksheet.Cells(i, 1)))
        
        cmdCustomerUploadingShipTo.Execute
        i = i + 1
        If ProgressBar1.Value + n < ProgressBar1.Max Then
        ProgressBar1.Value = ProgressBar1.Value + n
    Else
        ProgressBar1.Value = ProgressBar1.Max
    End If
    Else
   
        
        cmdCustomerUploading.ActiveConnection = cnn
        cmdCustomerUploading.CommandType = adCmdStoredProc
        cmdCustomerUploading.CommandText = "uspCustomer"
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CustomerDEL", adBoolean, adParamInput, , 0)
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@Comid", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 1)))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CustomerCD", adVarChar, adParamInput, 20, Replace(Trim(objWorksheet.Cells(i, 2)), "'", ""))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CustomerNAME", adVarChar, adParamInput, 255, Replace(Trim(objWorksheet.Cells(i, 3)), "'", ""))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@DistribCD", adVarChar, adParamInput, 20, "")
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CADD1", adVarChar, adParamInput, 255, Replace(Trim(objWorksheet.Cells(i, 6)), "'", ""))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CADD2", adVarChar, adParamInput, 255, Replace(Trim(objWorksheet.Cells(i, 7)), "'", ""))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@Cmcont", adVarChar, adParamInput, 20, "")
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@Cmphon", adVarChar, adParamInput, 20, "")
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@Vat", adBoolean, adParamInput, , 0)
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CDACD", adVarChar, adParamInput, 20, Replace(Trim(objWorksheet.Cells(i, 4)), "'", ""))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@ZIPCD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 14)))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@REGCD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 8)))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@DISTCD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 10)))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@AREACD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 12)))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@TERRCD", adVarChar, adParamInput, 20, "")
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CMGRP", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 15)))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CMCLASS", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 17)))
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@AREACOVRG", adVarChar, adParamInput, 20, "")
        If Trim(objWorksheet.Cells(i, 19)) = "No" Then
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@ACCNTSHRD", adBoolean, adParamInput, , 0)
        Else
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@ACCNTSHRD", adBoolean, adParamInput, , 1)
        End If
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CRTDDTE", adDate, adParamInput, , Date)
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@CRTDBY", adVarChar, adParamInput, 50, "")
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@Action", adVarChar, adParamInput, 10, "ADD")
        cmdCustomerUploading.Parameters.Append cmdCustomerUploading.CreateParameter("@OLDCUSTCODE", adVarChar, adParamInput, 20, "")
    
        
        cmdCustomerUploading.Execute
        
        
        cmdCustomerUploadingShipTo.ActiveConnection = cnn
        cmdCustomerUploadingShipTo.CommandType = adCmdStoredProc
        cmdCustomerUploadingShipTo.CommandText = "uspCustomerShipTo"
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CUSTOMERSHIPTODEL", adBoolean, adParamInput, , 0)
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CUSTOMERCD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 2)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CDACD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 4)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CDANAME", adVarChar, adParamInput, 255, Trim(objWorksheet.Cells(i, 5)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CDACADD1", adVarChar, adParamInput, 255, Trim(objWorksheet.Cells(i, 6)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CDACADD2", adVarChar, adParamInput, 255, Trim(objWorksheet.Cells(i, 7)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CDACONT", adVarChar, adParamInput, 255, "")
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CDAPHON", adVarChar, adParamInput, 20, "")
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@ZIPCD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 14)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@REGCD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 8)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@DISTCD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 10)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@AREACD", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 12)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@TERRCD", adVarChar, adParamInput, 20, "")
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CMGRP", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 15)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CMCLASS", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 17)))
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@AREACOVRG", adVarChar, adParamInput, 20, "")
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@ACCNTSHRD", adVarChar, adParamInput, 20, "")
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CRTDDTE", adDate, adParamInput, , "1/1/1900")
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@CRTDBY", adVarChar, adParamInput, 50, "")
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@ACTION", adVarChar, adParamInput, 10, "ADD")
        cmdCustomerUploadingShipTo.Parameters.Append cmdCustomerUploadingShipTo.CreateParameter("@COMID", adVarChar, adParamInput, 25, Trim(objWorksheet.Cells(i, 1)))
        
        cmdCustomerUploadingShipTo.Execute
        
        i = i + 1
        urec = urec + 1
   ' End If
   
    If ProgressBar1.Value + n < ProgressBar1.Max Then
        ProgressBar1.Value = ProgressBar1.Value + n
    Else
        ProgressBar1.Value = ProgressBar1.Max
    End If
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

'Update customer geographical map
Private Sub UpdateCustomerGeographicalMap()
    Dim Cmd As New ADODB.Command
    Cmd.ActiveConnection = cnn
    Cmd.CommandType = adCmdStoredProc
    Cmd.CommandText = "UspFixCustomerGeographicalMap"
    Cmd.Execute
End Sub
