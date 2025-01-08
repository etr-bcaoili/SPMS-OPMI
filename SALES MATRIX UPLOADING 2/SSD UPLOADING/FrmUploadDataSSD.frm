VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form FrmUploadDataSouthStar 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "South Star"
   ClientHeight    =   4635
   ClientLeft      =   4185
   ClientTop       =   3990
   ClientWidth     =   6285
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4635
   ScaleWidth      =   6285
   StartUpPosition =   1  'CenterOwner
   Begin VB.CheckBox chkDeleteBillingOrder 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Clear before upload"
      Height          =   255
      Left            =   1200
      TabIndex        =   7
      Top             =   2400
      Width           =   1815
   End
   Begin VB.PictureBox Picture1 
      BackColor       =   &H00DEC4B0&
      BorderStyle     =   0  'None
      Height          =   735
      Left            =   0
      ScaleHeight     =   735
      ScaleWidth      =   6375
      TabIndex        =   4
      Top             =   3960
      Width           =   6375
      Begin VB.Label lblUpload 
         BackColor       =   &H80000009&
         BackStyle       =   0  'Transparent
         Caption         =   "Upload"
         BeginProperty Font 
            Name            =   "Tahoma"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   -1  'True
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FF0000&
         Height          =   255
         Left            =   4800
         TabIndex        =   6
         Top             =   240
         Width           =   735
      End
      Begin VB.Label lblClose 
         BackColor       =   &H80000009&
         BackStyle       =   0  'Transparent
         Caption         =   "Close"
         BeginProperty Font 
            Name            =   "Tahoma"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   -1  'True
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FF0000&
         Height          =   255
         Left            =   5520
         TabIndex        =   5
         Top             =   240
         Width           =   615
      End
   End
   Begin VB.TextBox txtfile 
      Appearance      =   0  'Flat
      Height          =   315
      Left            =   1200
      Locked          =   -1  'True
      TabIndex        =   1
      Top             =   2040
      Width           =   4005
   End
   Begin MSComctlLib.ProgressBar ProgressBar1 
      Height          =   255
      Left            =   0
      TabIndex        =   0
      Top             =   3720
      Visible         =   0   'False
      Width           =   6255
      _ExtentX        =   11033
      _ExtentY        =   450
      _Version        =   393216
      BorderStyle     =   1
      Appearance      =   1
      MouseIcon       =   "FrmUploadDataSSD.frx":0000
      Max             =   1000
      Scrolling       =   1
   End
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   0
      Top             =   4440
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
      CancelError     =   -1  'True
   End
   Begin VB.Label Label1 
      BackStyle       =   0  'Transparent
      Caption         =   "Raw Data Uploading"
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
      Width           =   2295
   End
   Begin VB.Image Image1 
      Height          =   1005
      Left            =   0
      Picture         =   "FrmUploadDataSSD.frx":0CDA
      Stretch         =   -1  'True
      Top             =   -120
      Width           =   6285
   End
   Begin VB.Label lblBrowseFile 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "File:"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   -1  'True
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FF0000&
      Height          =   240
      Left            =   720
      TabIndex        =   2
      Top             =   2040
      Width           =   375
   End
End
Attribute VB_Name = "FrmUploadDataSouthStar"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim rsCheckRawDataFile As New ADODB.Recordset
Dim rs As New ADODB.Recordset
Dim st As New ADODB.Recordset
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
    SQLConnect
If chkDeleteBillingOrder.Value = 1 Then
    
    Dim cmdDeleteRawData As ADODB.Command
    Set cmdDeleteRawData = New ADODB.Command
        
        cmdDeleteRawData.ActiveConnection = cnn
        cmdDeleteRawData.CommandType = adCmdStoredProc
        cmdDeleteRawData.CommandText = "uspDeleteRawData"
        cmdDeleteRawData.Parameters.Append cmdDeleteRawData.CreateParameter("@CompanyCode", adVarChar, adParamInput, 10, "SSD")
    cmdDeleteRawData.Execute
    
    
    Dim cmdDeleteBillingOrder As ADODB.Command
    Set cmdDeleteBillingOrder = New ADODB.Command
        
        cmdDeleteBillingOrder.ActiveConnection = cnn
        cmdDeleteBillingOrder.CommandType = adCmdStoredProc
        cmdDeleteBillingOrder.CommandText = "uspX32DeleteBillingOrderData"
        cmdDeleteBillingOrder.Parameters.Append cmdDeleteBillingOrder.CreateParameter("@CompanyCode", adVarChar, adParamInput, 10, "SSD")
    cmdDeleteBillingOrder.Execute
    
 Else
    
    If rsCheckRawDataFile.State = 1 Then rsCheckRawDataFile.Close
    rsCheckRawDataFile.Open "Select * from UploadedRawData Where CheckFileName = '" & Right(txtfile, 12) & "' AND CompanyCode = '" & "SSD" & "'", cnn, adOpenKeyset

    If rsCheckRawDataFile.RecordCount <> 0 Then
        MsgBox "Uploading cannot be completed, raw data already exist!", vbInformation
        Exit Sub
    End If
 
 End If

ProgressBar1.Visible = True
    ImportData
    cnn.Execute "Insert Into UploadedRawData(CompanyCode,CheckFileName) " & _
        " Values('" & "SSD" & "','" & Right(txtfile, 12) & "')"
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

Dim strdata As String
Dim ln, i As Long

 repfile = txtfile.Text

    StartExcel
    
    objExcel.Visible = False

    Set objWorkbook = objExcel.Workbooks.Open(repfile)
    Set objWorksheet = objWorkbook.ActiveSheet

On Error Resume Next

    ln = 0
    i = 2
If objWorksheet.Cells(i, 1) <> "SSD" Then
    MsgBox "Please check your rawdata and Company Code", vbInformation, "Invalid"
    objExcel.Workbooks.Close
    Exit Sub
End If
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
         
    Dim cmdRawData As ADODB.Command
    Set cmdRawData = New ADODB.Command
        
         cmdRawData.ActiveConnection = cnn
        cmdRawData.CommandType = adCmdStoredProc
        cmdRawData.CommandText = "uspRawData"
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Action", adVarChar, adParamInput, 10, "Save")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@RawDataID", adInteger, adParamInput, , -1)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CompanyCode", adVarChar, adParamInput, 10, "SSD")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@BranchCode", adVarChar, adParamInput, 10, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@BranchName", adVarChar, adParamInput, 255, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerNumber", adVarChar, adParamInput, 10, Trim(objWorksheet.Cells(i, 6)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerName", adVarChar, adParamInput, 255, Trim(objWorksheet.Cells(i, 14)))
        
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerAddress1", adVarChar, adParamInput, 255, "")
        
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerAddress2", adVarChar, adParamInput, 255, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@TransactionDate", adVarChar, adParamInput, 8, Format(Trim(objWorksheet.Cells(i, 3)), "yyyymmdd"))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@InvoiceNumber", adVarChar, adParamInput, 10, Trim(objWorksheet.Cells(i, 4)))
        
        If Trim(objWorksheet.Cells(i, 7)) < 0 Then
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@TransactionType", adVarChar, adParamInput, 2, "CR")
        Else
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@TransactionType", adVarChar, adParamInput, 2, "IV")
        End If
     
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ItemNumber", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 13)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ItemDescription", adVarChar, adParamInput, 255, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@WarehouseNumber", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Class", adVarChar, adParamInput, 3, "")
        If Trim(objWorksheet.Cells(i, 7)) <> "" Then
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@QuantitySold", adInteger, adParamInput, , Trim(objWorksheet.Cells(i, 7)))
        Else
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@QuantitySold", adInteger, adParamInput, , 0)
        End If
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@QuantityFree", adInteger, adParamInput, , 0)
        
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@GrossAmount", adDouble, adParamInput, , Trim(objWorksheet.Cells(i, 10)))
        'cmdRawData.Parameters.Append cmdRawData.CreateParameter("@LineDiscount", adDouble, adParamInput, , CDbl(Mid(varx, 206, 7)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@LineDiscount", adDouble, adParamInput, , 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ProductDiscount", adDouble, adParamInput, , 0)
        
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@VatCode", adVarChar, adParamInput, 1, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Route", adVarChar, adParamInput, 6, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Taxes", adDouble, adParamInput, , 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Freight", adDouble, adParamInput, , 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Additional", adDouble, adParamInput, , 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@NetAmount", adDouble, adParamInput, , Trim(objWorksheet.Cells(i, 9)))
        If Trim(objWorksheet.Cells(i, 8)) <> "" Then
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@UnitPrice", adDouble, adParamInput, , Trim(objWorksheet.Cells(i, 8)))
        Else
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@UnitPrice", adDouble, adParamInput, , "")
        End If
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@InvoiceReferenceNumber", adInteger, adParamInput, , -1)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CMCode", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SONumber", adInteger, adParamInput, , -1)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SODate", adVarChar, adParamInput, 30, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SOTerms", adVarChar, adParamInput, 6, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ExpiryDate", adVarChar, adParamInput, 30, "")
        
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@LotNumber", adVarChar, adParamInput, 15, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SalesmanNumber", adVarChar, adParamInput, 10, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SalesmanName", adVarChar, adParamInput, 24, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ShipToName", adVarChar, adParamInput, 50, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ShipToAddress1", adVarChar, adParamInput, 50, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ShipToAddress2", adVarChar, adParamInput, 50, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ZipCode", adVarChar, adParamInput, 6, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@TerritoryNumber", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Area", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerClass", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ClassName", adVarChar, adParamInput, 24, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Principal", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SubPrincipal", adVarChar, adParamInput, 6, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@PrincipalDivisionCode", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SalesWeek", adVarChar, adParamInput, 1, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerDeliveryCode", adVarChar, adParamInput, 4, Trim(objWorksheet.Cells(i, 5)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ListPriceTaxInclude", adVarChar, adParamInput, 9, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ContractPrincipalApprovalNumber", adVarChar, adParamInput, 15, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@OrderType", adVarChar, adParamInput, 1, "Y")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@IsCode", adVarChar, adParamInput, 255, "")
        
        cmdRawData.Execute
        
        
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
