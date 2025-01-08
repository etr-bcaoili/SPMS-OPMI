VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form FrmUploadDataMetroDrug 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "GB DISTRIBUTOR INC."
   ClientHeight    =   4410
   ClientLeft      =   4185
   ClientTop       =   3990
   ClientWidth     =   7020
   ControlBox      =   0   'False
   BeginProperty Font 
      Name            =   "Tahoma"
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
   ScaleHeight     =   4410
   ScaleWidth      =   7020
   StartUpPosition =   1  'CenterOwner
   Begin VB.Frame Frame2 
      BackColor       =   &H00FFFFFF&
      Height          =   855
      Left            =   120
      TabIndex        =   9
      Top             =   1080
      Width           =   6855
      Begin VB.ComboBox cmbYear 
         BeginProperty Font 
            Name            =   "Segoe UI"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   315
         Left            =   3120
         TabIndex        =   11
         Top             =   360
         Width           =   1095
      End
      Begin VB.ComboBox cmbMonth 
         BeginProperty Font 
            Name            =   "Segoe UI"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   315
         ItemData        =   "FrmUploadDataMDI.frx":0000
         Left            =   1080
         List            =   "FrmUploadDataMDI.frx":0002
         TabIndex        =   10
         Top             =   360
         Width           =   1455
      End
      Begin VB.Label Label4 
         BackStyle       =   0  'Transparent
         Caption         =   "Year:"
         BeginProperty Font 
            Name            =   "Segoe UI"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FF0000&
         Height          =   255
         Left            =   2640
         TabIndex        =   13
         Top             =   360
         Width           =   615
      End
      Begin VB.Label Label3 
         BackStyle       =   0  'Transparent
         Caption         =   "Month:"
         BeginProperty Font 
            Name            =   "Segoe UI"
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
         TabIndex        =   12
         Top             =   360
         Width           =   615
      End
   End
   Begin VB.Frame Frame1 
      BackColor       =   &H00FFFFFF&
      Height          =   1815
      Left            =   120
      TabIndex        =   4
      Top             =   1920
      Width           =   6855
      Begin VB.ComboBox cmbFileType 
         BeginProperty Font 
            Name            =   "Segoe UI"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   315
         ItemData        =   "FrmUploadDataMDI.frx":0004
         Left            =   1080
         List            =   "FrmUploadDataMDI.frx":000E
         TabIndex        =   15
         Top             =   240
         Width           =   1335
      End
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
         TabIndex        =   5
         Top             =   960
         Width           =   5325
      End
      Begin MSComctlLib.ProgressBar ProgressBar1 
         Height          =   255
         Left            =   120
         TabIndex        =   14
         Top             =   1440
         Visible         =   0   'False
         Width           =   6615
         _ExtentX        =   11668
         _ExtentY        =   450
         _Version        =   393216
         BorderStyle     =   1
         Appearance      =   1
         MouseIcon       =   "FrmUploadDataMDI.frx":001E
         Max             =   1000
         Scrolling       =   1
      End
      Begin VB.Label Label5 
         BackStyle       =   0  'Transparent
         Caption         =   "File Type:"
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
         TabIndex        =   16
         Top             =   240
         Width           =   735
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
         TabIndex        =   7
         Top             =   600
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
         TabIndex        =   6
         Top             =   1080
         Width           =   330
      End
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
      Height          =   495
      Left            =   120
      ScaleHeight     =   495
      ScaleWidth      =   7095
      TabIndex        =   0
      Top             =   3840
      Width           =   7095
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
         Left            =   5520
         TabIndex        =   2
         Top             =   120
         Width           =   735
      End
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
         Left            =   6240
         TabIndex        =   1
         Top             =   120
         Width           =   615
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
      Height          =   285
      Left            =   6480
      TabIndex        =   8
      Top             =   1800
      Visible         =   0   'False
      Width           =   615
   End
   Begin VB.Label Label1 
      BackStyle       =   0  'Transparent
      Caption         =   "Raw Data Upload"
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
      Left            =   480
      TabIndex        =   3
      Top             =   240
      Width           =   2295
   End
   Begin VB.Image Image2 
      Height          =   1005
      Left            =   0
      Picture         =   "FrmUploadDataMDI.frx":0CF8
      Stretch         =   -1  'True
      Top             =   0
      Width           =   7125
   End
End
Attribute VB_Name = "FrmUploadDataMetroDrug"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim rsCheckRawDataFile As New ADODB.Recordset
Dim rs As New ADODB.Recordset
Dim st As New ADODB.Recordset
Dim TotalGrossAmount As Double
Dim TotalGrossAmountCR As Double
Dim TotalGrossAmountIV As Double
Dim TotalNetAmount As Double
Dim TotalNetAmountCR As Double
Dim TotalNetAmountIV As Double
Dim TotalQuantity As Double
Dim TotalQuantityCR As Double
Dim TotalQuantityIV As Double
Dim TotalProductDisc As Double
Dim TotalProductDiscIV As Double
Dim TotalProductDiscCR As Double
Dim repfile As String
Dim urec As Long

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
    If cmbFileType.Text = ".XLS" Then
    CommonDialog1.Filter = "Excel files(*.xls)|*.xls"
    Else
    CommonDialog1.Filter = "Text files(*.txt)|*.txt"
    End If
    CommonDialog1.ShowOpen
    txtfile.Text = CommonDialog1.FileName
    Text1.Text = Right(txtfile, 8)
    Text2.Text = Right(txtfile, 5)
End Sub
Private Sub cmdImport_Click()
'-----------------------------------------------------------
'FOR GBD
    
 If txtfile = "" Then
 
    MsgBox "No file to be uploaded", vbInformation, "Please select file"
    Exit Sub
    
 End If
 
  
    repfile = txtfile.Text
    urec = 0
    SQLConnect

 
  cnn.Execute "Delete From Rawdata Where CompanyCode = '" & "GBD" & "' AND CUTMO = '" & txtMonth.Text & "' AND CUTYEAR = '" & cmbYear.Text & "'"
    
'    Dim cmdDeleteBillingOrder As ADODB.Command
'    Set cmdDeleteBillingOrder = New ADODB.Command
'
'        cmdDeleteBillingOrder.ActiveConnection = cnn
'        cmdDeleteBillingOrder.CommandType = adCmdStoredProc
'        cmdDeleteBillingOrder.CommandText = "uspX32DeleteBillingOrderData"
'        cmdDeleteBillingOrder.Parameters.Append cmdDeleteBillingOrder.CreateParameter("@CompanyCode", adVarChar, adParamInput, 10, "MDI")
'    cmdDeleteBillingOrder.Execute
    
    


    ProgressBar1.Visible = True
    ImportData
    
    cnn.Execute "Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount,TotalProductDisc) " & _
        " Values('" & "GBD" & "','" & Right(txtfile, 12) & "','" & txtMonth.Text & "','" & cmbYear.Text & "'," & TotalGrossAmount & "," & TotalQuantity & "," & TotalNetAmount & "," & TotalProductDisc & " )"
        
    If urec = 0 Then
        MsgBox "File not found!", vbCritical
   Else

       MsgBox "Importing Data completed! "
       Unload Me
  End If
End Sub
Private Sub ImportData()
Dim rsRawdata As New ADODB.Recordset
Dim rsRegion As New ADODB.Recordset
Dim IntegerHolder As Integer
Dim DoubleHolder As Integer
Dim strdata As String
Dim ln, i As Long

inthandle = FreeFile

'open the file and count valid lines
Open repfile For Input Access Read As inthandle
ln = 0
Do While Not EOF(inthandle)   ' Loop until end of file.
   Line Input #inthandle, strdata ' Read data into 1 variable.
    dte = Val(Mid(strdata, 186, 8))
    co = Trim(Mid(strdata, 1, 2))
    prn = Trim(Mid(strdata, 641, 3))

        ln = ln + 1
 
Loop


If ln <= 0 Then
    urec = 0
    Exit Sub
End If
Close #inthandle   'Close file.
inthandle = FreeFile


Open repfile For Input Access Read As inthandle
urec = 0
n = (ProgressBar1.Max / ln) * 0.99
ProgressBar1.Value = 0

'On Error Resume Next
TotalGrossAmount = 0
TotalGrossAmountCR = 0
TotalGrossAmountIV = 0
TotalNetAmount = 0
TotalNetAmountCR = 0
TotalNetAmountIV = 0
TotalProductDisc = 0
TotalProductDiscCR = 0
TotalProductDiscIV = 0
TotalQuantity = 0
TotalQuantityCR = 0
TotalQuantityIV = 0

For i = 1 To ln
    
    Line Input #inthandle, varx
    'transaction date
    dte = Val(Mid(varx, 186, 8))
    co = Trim(Mid(varx, 1, 2))
    prn = Trim(Mid(strdata, 641, 3))
    
   ' If co = "MD" And prn = "650" Then
         
     Dim cmdRawData As ADODB.Command
    Set cmdRawData = New ADODB.Command
     
    
      
      
        cmdRawData.ActiveConnection = cnn
        cmdRawData.CommandType = adCmdStoredProc
        cmdRawData.CommandText = "uspRawData"
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Action", adVarChar, adParamInput, 10, "Save")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CompanyCode", adInteger, adParamInput, , -1)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CompanyCode", adVarChar, adParamInput, 10, "GBD")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@BranchCode", adVarChar, adParamInput, 10, Trim(Mid(varx, 3, 3)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@BranchName", adVarChar, adParamInput, 255, Trim(Mid(varx, 6, 24)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerNumber", adVarChar, adParamInput, 10, Trim(Mid(varx, 30, 6)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerName", adVarChar, adParamInput, 255, CheckField(Trim(Mid(varx, 36, 50))))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerAddress1", adVarChar, adParamInput, 255, Trim(Mid(varx, 86, 50)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerAddress2", adVarChar, adParamInput, 255, Trim(Mid(varx, 136, 50)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@TransactionDate", adVarChar, adParamInput, 8, dte)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@InvoiceNumber", adVarChar, adParamInput, 10, Trim(Mid(varx, 194, 8)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@TransactionType", adVarChar, adParamInput, 2, Trim(Mid(varx, 202, 2)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ItemNumber", adVarChar, adParamInput, 20, Trim(Mid(varx, 204, 20)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ItemDescription", adVarChar, adParamInput, 255, Trim(Mid(varx, 224, 20)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@WarehouseNumber", adVarChar, adParamInput, 3, Trim(Mid(varx, 244, 3)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Class", adVarChar, adParamInput, 3, "")
        
        If Trim(Mid(varx, 202, 2)) = "CR" Then
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@QuantitySold", adInteger, adParamInput, , 0 - Trim(Mid(varx, 250, 9)))
        TotalQuantityCR = TotalQuantityCR + (0 - Trim(Mid(varx, 250, 9)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@QuantityFree", adInteger, adParamInput, , 0 - Trim(Mid(varx, 259, 9)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@GrossAmount", adDouble, adParamInput, , 0 - CDbl(Mid(varx, 268, 13)) / 100)
        TotalGrossAmountCR = TotalGrossAmountCR + (0 - CDbl(Mid(varx, 268, 13)) / 100)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@LineDiscount", adDouble, adParamInput, , 0 - CDbl(Mid(varx, 281, 7)) / 10000)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ProductDiscount", adDouble, adParamInput, , 0 - CDbl(Mid(varx, 288, 13)) / 100)
        TotalProductDiscCR = TotalProductDiscCR + (0 - CDbl(Mid(varx, 288, 13)) / 100)
        Else
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@QuantitySold", adInteger, adParamInput, , Trim(Mid(varx, 250, 9)))
        TotalQuantityIV = TotalQuantityIV + Trim(Mid(varx, 250, 9))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@QuantityFree", adInteger, adParamInput, , Trim(Mid(varx, 259, 9)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@GrossAmount", adDouble, adParamInput, , CDbl(Mid(varx, 268, 13)) / 100)
        TotalGrossAmountIV = TotalGrossAmountIV + CDbl(Mid(varx, 268, 13)) / 100
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@LineDiscount", adDouble, adParamInput, , CDbl(Mid(varx, 281, 7)) / 10000)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ProductDiscount", adDouble, adParamInput, , CDbl(Mid(varx, 288, 13)) / 100)
        TotalProductDiscIV = TotalProductDiscIV + CDbl(Mid(varx, 288, 13)) / 100
        End If
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@VatCode", adVarChar, adParamInput, 1, Trim(Mid(varx, 301, 1)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Route", adVarChar, adParamInput, 6, Trim(Mid(varx, 653, 4)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Taxes", adDouble, adParamInput, , CDbl(Mid(varx, 308, 13)) / 100)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Freight", adDouble, adParamInput, , CDbl(Mid(varx, 321, 13)) / 100)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Additional", adDouble, adParamInput, , 0)
        If Trim(Mid(varx, 202, 2)) = "CR" Then
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@NetAmount", adDouble, adParamInput, , 0 - CDbl(Mid(varx, 347, 13)) / 100)
        TotalNetAmountCR = TotalNetAmountCR + (0 - CDbl(Mid(varx, 347, 13)) / 100)
        Else
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@NetAmount", adDouble, adParamInput, , CDbl(Mid(varx, 347, 13)) / 100)
        TotalNetAmountIV = TotalNetAmountIV + CDbl(Mid(varx, 347, 13)) / 100
        End If
        On Error Resume Next
        
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@UnitPrice", adDouble, adParamInput, , CDbl(Mid(varx, 360, 9)) / 100)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@InvoiceReferenceNumber", adInteger, adParamInput, , Val(Mid(varx, 369, 8)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CMCode", adVarChar, adParamInput, 3, Trim(Mid(varx, 377, 3)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SONumber", adInteger, adParamInput, , Val(Mid(varx, 380, 8)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SODate", adVarChar, adParamInput, 30, Val(Mid(varx, 388, 8)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SOTerms", adVarChar, adParamInput, 6, Trim(Mid(varx, 396, 6)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ExpiryDate", adVarChar, adParamInput, 30, Val(Mid(varx, 402, 8)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@LotNumber", adVarChar, adParamInput, 15, Trim(Mid(varx, 410, 15)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SalesmanNumber", adVarChar, adParamInput, 3, Trim(Mid(varx, 425, 3)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SalesmanName", adVarChar, adParamInput, 24, Trim(Mid(varx, 428, 24)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ShipToName", adVarChar, adParamInput, 255, Trim(Mid(varx, 452, 50)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ShipToAddress1", adVarChar, adParamInput, 255, Trim(Mid(varx, 502, 50)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ShipToAddress2", adVarChar, adParamInput, 255, Trim(Mid(varx, 552, 50)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ZipCode", adVarChar, adParamInput, 6, Trim(Mid(varx, 602, 6)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@TerritoryNumber", adVarChar, adParamInput, 3, Trim(Mid(varx, 608, 3)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Area", adVarChar, adParamInput, 3, Trim(Mid(varx, 611, 3)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerClass", adVarChar, adParamInput, 3, Trim(Mid(varx, 614, 3)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ClassName", adVarChar, adParamInput, 24, Trim(Mid(varx, 247, 3)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Principal", adVarChar, adParamInput, 3, Trim(Mid(varx, 641, 3)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SubPrincipal", adVarChar, adParamInput, 6, Trim(Mid(varx, 644, 6)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@PrincipalDivisionCode", adVarChar, adParamInput, 3, Trim(Mid(varx, 650, 3)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SalesWeek", adVarChar, adParamInput, 1, Trim(Mid(varx, 653, 1)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerDeliveryCode", adVarChar, adParamInput, 3, Trim(Mid(varx, 654, 3)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ListPriceTaxInclude", adVarChar, adParamInput, 9, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ContractPrincipalApprovalNumber", adVarChar, adParamInput, 15, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@OrderType", adVarChar, adParamInput, 1, Trim(Mid(varx, 684, 1)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@IsCode", adVarChar, adParamInput, 255, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Cutmo", adVarChar, adParamInput, 20, txtMonth.Text)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CutYear", adVarChar, adParamInput, 20, cmbYear.Text)
        
        If rsRegion.State = 1 Then rsRegion.Close
            rsRegion.Open "Select REGCD from Zipcode " & _
                "WHERE ZIPCD = '" & Trim(Mid(varx, 602, 6)) & "' AND " & _
                "Areacd = '" & Trim(Mid(varx, 608, 3)) & "' AND " & _
                "distrctcd = '" & Trim(Mid(varx, 611, 3)) & "'", cnn, adOpenKeyset
        If rsRegion.RecordCount <> 0 Then
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CutYear", adVarChar, adParamInput, 20, rsRegion.Fields(0).Value)
        End If
        
        cmdRawData.Execute
        
        
    
    
    
        urec = urec + 1
   ' End If
   
    If ProgressBar1.Value + n < ProgressBar1.Max Then
        ProgressBar1.Value = ProgressBar1.Value + n
    Else
        ProgressBar1.Value = ProgressBar1.Max
    End If
Next i
TotalQuantity = TotalQuantityCR + TotalQuantityIV
TotalGrossAmount = TotalGrossAmountCR + TotalGrossAmountIV
TotalNetAmount = TotalNetAmountCR + TotalNetAmountIV
TotalProductDisc = TotalProductDiscCR + TotalProductDiscIV

Close #inthandle
inthandle = FreeFile
End Sub

Private Sub cmbMonth_Click()
If cmbMonth.Text = "January" Then
    txtMonth.Text = "01"
    ElseIf cmbMonth.Text = "February" Then
    txtMonth.Text = "02"
    ElseIf cmbMonth.Text = "March" Then
    txtMonth.Text = "03"
    ElseIf cmbMonth.Text = "April" Then
    txtMonth.Text = "04"
    ElseIf cmbMonth.Text = "May" Then
    txtMonth.Text = "05"
    ElseIf cmbMonth.Text = "June" Then
    txtMonth.Text = "06"
    ElseIf cmbMonth.Text = "July" Then
    txtMonth.Text = "07"
    ElseIf cmbMonth.Text = "August" Then
    txtMonth.Text = "08"
    ElseIf cmbMonth.Text = "September" Then
    txtMonth.Text = "09"
    ElseIf cmbMonth.Text = "October" Then
    txtMonth.Text = "10"
    ElseIf cmbMonth.Text = "November" Then
    txtMonth.Text = "11"
    ElseIf cmbMonth.Text = "December" Then
    txtMonth.Text = "12"
End If
End Sub

Private Sub Form_Load()
Dim c_Year As Integer
With cmbMonth
    .AddItem "January"
    .AddItem "February"
    .AddItem "March"
    .AddItem "April"
    .AddItem "May"
    .AddItem "June"
    .AddItem "July"
    .AddItem "August"
    .AddItem "September"
    .AddItem "October"
    .AddItem "November"
    .AddItem "December"
End With


With cmbYear
    For c_Year = 2008 To Format(Now, "yyyy") + 1
            .AddItem c_Year
    Next c_Year
    
End With
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


