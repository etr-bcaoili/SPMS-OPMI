VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form FrmUploadDataMercury 
   BackColor       =   &H80000009&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "MERCURY DRUG"
   ClientHeight    =   4320
   ClientLeft      =   4185
   ClientTop       =   3990
   ClientWidth     =   7080
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4320
   ScaleWidth      =   7080
   StartUpPosition =   1  'CenterOwner
   Begin VB.PictureBox Picture1 
      BackColor       =   &H00DEC4B0&
      BorderStyle     =   0  'None
      Height          =   495
      Left            =   -120
      ScaleHeight     =   495
      ScaleWidth      =   8175
      TabIndex        =   10
      Top             =   3840
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
         TabIndex        =   12
         Top             =   120
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
         TabIndex        =   11
         Top             =   120
         Width           =   735
      End
   End
   Begin VB.Frame Frame1 
      BackColor       =   &H00FFFFFF&
      Height          =   1815
      Left            =   120
      TabIndex        =   5
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
         ItemData        =   "FrmUploadDataMER.frx":0000
         Left            =   1080
         List            =   "FrmUploadDataMER.frx":000A
         TabIndex        =   16
         Top             =   240
         Width           =   1335
      End
      Begin VB.TextBox txtfile 
         Appearance      =   0  'Flat
         Height          =   315
         Left            =   1080
         Locked          =   -1  'True
         TabIndex        =   6
         Top             =   960
         Width           =   5325
      End
      Begin MSComctlLib.ProgressBar ProgressBar1 
         Height          =   255
         Left            =   120
         TabIndex        =   7
         Top             =   1440
         Visible         =   0   'False
         Width           =   6495
         _ExtentX        =   11456
         _ExtentY        =   450
         _Version        =   393216
         BorderStyle     =   1
         Appearance      =   1
         MouseIcon       =   "FrmUploadDataMER.frx":0019
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
         TabIndex        =   15
         Top             =   240
         Width           =   735
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
         TabIndex        =   9
         Top             =   1080
         Width           =   330
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
         TabIndex        =   8
         Top             =   600
         Width           =   3615
      End
   End
   Begin VB.Frame Frame2 
      BackColor       =   &H00FFFFFF&
      Height          =   855
      Left            =   120
      TabIndex        =   0
      Top             =   1080
      Width           =   6855
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
         ItemData        =   "FrmUploadDataMER.frx":0CF3
         Left            =   1080
         List            =   "FrmUploadDataMER.frx":0CF5
         TabIndex        =   2
         Top             =   360
         Width           =   1455
      End
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
         TabIndex        =   1
         Top             =   360
         Width           =   1095
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
         TabIndex        =   4
         Top             =   360
         Width           =   615
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
         TabIndex        =   3
         Top             =   360
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
      TabIndex        =   13
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
      TabIndex        =   14
      Top             =   240
      Width           =   2295
   End
   Begin VB.Image Image2 
      Height          =   1005
      Left            =   0
      Picture         =   "FrmUploadDataMER.frx":0CF7
      Stretch         =   -1  'True
      Top             =   0
      Width           =   7125
   End
End
Attribute VB_Name = "FrmUploadDataMercury"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim rsCheckRawDataFile As New ADODB.Recordset
Dim rs As New ADODB.Recordset
Dim st As New ADODB.Recordset
Dim rsDistributor As New ADODB.Recordset
Dim repfile, filename As String
Dim TotalGrossAmount As Double
Dim TotalQuantity As Double
Dim urec As Long
Dim CheckIfUnmmaped As Integer
Dim GrossAmount
Dim NetAmount

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
    CommonDialog1.Filter = "SP files(*.SP)|*.SP"
    End If
    CommonDialog1.ShowOpen
    txtfile.Text = CommonDialog1.filename
    filename = Right(txtfile, 7)
   
End Sub
Private Sub cmdImport_Click()
'-----------------------------------------------------------

     cnn.Execute "Delete From Rawdata Where CompanyCode = '" & "MER" & "' AND CUTMO = '" & txtMonth.Text & "' AND CUTYEAR = '" & cmbYear.Text & "'"
 
    
 If txtfile = "" Then
 
    MsgBox "No file to be uploaded", vbInformation, "Please select file"
    Exit Sub
    
 End If
 
    repfile = txtfile.Text
    urec = 0
    SQLConnect
    
    'ProgressBar1.Visible = True
    ImportData

    cnn.Execute "Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity) " & _
        " Values('" & "MER" & "','" & Right(txtfile, 7) & "','" & txtMonth.Text & "','" & cmbYear.Text & "'," & TotalGrossAmount & "," & TotalQuantity & ")"

    If urec = 0 Then
        MsgBox "File not found!", vbCritical
    Else
    If CheckIfUnmmaped = 0 Then
       MsgBox "Importing Data complete! "
       Unload Me
     End If
  End If
End Sub
Private Sub ImportData()
Dim rsRawdata As New ADODB.Recordset
Dim rsCustomer As New ADODB.Recordset
Dim rsCustomerID As New ADODB.Recordset
Dim rsCustomerShiptoDetails As New ADODB.Recordset
Dim rsCustomerName As New ADODB.Recordset
Dim rsUnmmaped As New ADODB.Recordset
Dim rsCheckDuplicateUnammped As New ADODB.Recordset
Dim rsCompanyID As New ADODB.Recordset

Dim chkdata, strdata, MercuryCode, dte, CustomerName, CustomerAddress1, CustomerAddress2 As String
Dim m_Address, m_CustomerStoreName As String
Dim CheckUnmmaped As Integer
Dim ln, i As Long
Dim x, y
inthandle = FreeFile

'open the file and count valid lines
Open repfile For Input Access Read As inthandle
ln = 0
'rsUnmmaped.Fields.Append "MercuryCode", adVarChar, 255
'rsUnmmaped.Open
'rsCheckDuplicateUnammped.Fields.Append "MercuryCode", adVarChar, 255
'rsCheckDuplicateUnammped.Open

'   If rsUnmmaped.State = 1 Then rsUnmmaped.Close
'        rsUnmmaped.Open "Select * from Unmmaped", cnn, adOpenKeyset
Line Input #inthandle, chkdata ' Read data into 1 variable.
 If Trim(Mid(chkdata, 12, 20)) <> "" Then
        MsgBox "To fix alignments please open your raw data in word pad", vbInformation, "Invalid data format"
    Exit Sub
 End If
 
Do While Not EOF(inthandle)   ' Loop until end of file.
   Line Input #inthandle, strdata ' Read data into 1 variable.
    dte = Val(Mid(strdata, 186, 8))
    co = Trim(Mid(strdata, 1, 2))
    prn = Trim(Mid(strdata, 641, 3))
'
'    If rsCustomerShiptoDetails.State = 1 Then rsCustomerShiptoDetails.Close
'    rsCustomerShiptoDetails.Open "Select ShipToCustomerID from CustomerShipToDetails Where DistributorCode = '" & Trim(Mid(strdata, 2, 3)) & "'", cnnMercuryCustomer, adOpenKeyset
'
'  If Trim(Mid(strdata, 1, 1)) = 2 Then
'    If rsCustomerShiptoDetails.RecordCount = 0 Then
'
'       rsUnmmaped.AddNew
'       rsUnmmaped!MercuryCode = Trim(Mid(strdata, 2, 3))
'       rsUnmmaped.Update
'
'    End If
'  End If
        ln = ln + 1
Loop

If ln <= 0 Then
    urec = 0
    Exit Sub
End If
Close #inthandle   'Close file.
inthandle = FreeFile

'frmUnmmaped.ListView1.View = lvwReport
'frmUnmmaped.ListView1.ColumnHeaders.Clear
'frmUnmmaped.ListView1.ColumnHeaders.Add , , "Mercury Code", 4000, lvwColumnLeft
'
'If rsUnmmaped.RecordCount <> 0 Then
'rsUnmmaped.MoveFirst
'End If
'Do Until rsUnmmaped.EOF
'
'    MercuryCode = rsUnmmaped!MercuryCode
'
'    If CheckUnmmaped = 0 Then
'
'     rsCheckDuplicateUnammped.AddNew
'     rsCheckDuplicateUnammped!MercuryCode = MercuryCode
'     rsCheckDuplicateUnammped.Update
'     CheckUnmmaped = 1
'
'    Else
'
'    If MercuryCode <> rsCheckDuplicateUnammped!MercuryCode Then
'     rsCheckDuplicateUnammped.AddNew
'     rsCheckDuplicateUnammped!MercuryCode = MercuryCode
'     frmUnmmaped.ListView1.ListItems.Add , , MercuryCode
'     rsCheckDuplicateUnammped.Update
'    End If
'    End If
'    rsUnmmaped.MoveNext
'Loop



n = (ProgressBar1.Max / ln) * 0.99
ProgressBar1.Value = 0

'If rsCheckDuplicateUnammped.RecordCount > 1 Then
'   'Do Until rsCheckDuplicateUnammped.EOF
'   'frmUnmmaped.ListView1.ListItems.Add , , rsCheckDuplicateUnammped!mercury
'   ' Set frmUnmmaped.DataGrid1.DataSource = rsCheckDuplicateUnammped
'   'rsCheckDuplicateUnammped.MoveNext
'   'Loop
'    frmUnmmaped.Show 1
'    urec = 1
'    CheckIfUnmmaped = 1
'    Exit Sub
'Else
On Error Resume Next
ProgressBar1.Visible = True
Open repfile For Input Access Read As inthandle
urec = 0

For i = 1 To ln
    
    Line Input #inthandle, varx
    'transaction date
   
    If Trim(Mid(varx, 1, 1)) = 1 Then
        dte = Trim(Mid(varx, 6, 6))
    End If
    
    co = Trim(Mid(varx, 1, 2))
    prn = Trim(Mid(strdata, 641, 3))
    
   ' If co = "MD" And prn = "650" Then
    If Trim(Mid(varx, 1, 1)) = 2 Then
    Dim cmdRawData As ADODB.Command
    Set cmdRawData = New ADODB.Command
        
        cmdRawData.ActiveConnection = cnn
        cmdRawData.CommandType = adCmdStoredProc
        cmdRawData.CommandText = "uspRawData"
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Action", adVarChar, adParamInput, 10, "Save")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@RawDataID", adInteger, adParamInput, , -1)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CompanyCode", adVarChar, adParamInput, 10, "MER")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@BranchCode", adVarChar, adParamInput, 10, Trim(Mid(varx, 2, 4)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@BranchName", adVarChar, adParamInput, 255, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerNumber", adVarChar, adParamInput, 10, Trim(Mid(varx, 2, 4)))
        
        If rsCustomer.State = 1 Then rsCustomer.Close
            rsCustomer.Open "Select CUSTOMERNAME,CADD1,CADD2 FROM CUSTOMER WHERE CUSTOMERCD = '" & Trim(Mid(varx, 2, 4)) & "' AND COMID = '" & "MER" & "'", cnn, adOpenKeyset
        If rsCustomer.RecordCount <> 0 Then
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerName", adVarChar, adParamInput, 255, rsCustomer.Fields(0).Value)
        Else
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerName", adVarChar, adParamInput, 255, "")
        End If
        If rsCustomer.RecordCount <> 0 Then
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerAddress1", adVarChar, adParamInput, 255, rsCustomer.Fields(1).Value)
        Else
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerAddress1", adVarChar, adParamInput, 255, "")
        End If
        If rsCustomer.RecordCount <> 0 Then
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerAddress2", adVarChar, adParamInput, 255, rsCustomer.Fields(2).Value)
        Else
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerAddress2", adVarChar, adParamInput, 255, "")
        End If
        
        
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@TransactionDate", adVarChar, adParamInput, 8, dte)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@InvoiceNumber", adVarChar, adParamInput, 10, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@TransactionType", adVarChar, adParamInput, 2, "IV")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ItemNumber", adVarChar, adParamInput, 20, Trim(Mid(varx, 6, 6)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ItemDescription", adVarChar, adParamInput, 255, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@WarehouseNumber", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Class", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@QuantitySold", adInteger, adParamInput, , Trim(Mid(varx, 12, 5)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@QuantityFree", adInteger, adParamInput, , 0)
        
        GrossAmount = 0
        If rsDistributor.State = 1 Then rsDistributor.Close
            rsDistributor.Open "Select * from distributoritems where DISTITEMCD = '" & Trim(Mid(varx, 6, 6)) & "'", cnn, adOpenKeyset
        If rsDistributor.RecordCount <> 0 Then
        GrossAmount = rsDistributor.Fields(4).Value * Trim(Mid(varx, 12, 5))
        End If
        
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@GrossAmount", adDouble, adParamInput, , GrossAmount)
        'cmdRawData.Parameters.Append cmdRawData.CreateParameter("@LineDiscount", adDouble, adParamInput, , CDbl(Mid(varx, 206, 7)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@LineDiscount", adDouble, adParamInput, , 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ProductDiscount", adDouble, adParamInput, , 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@VatCode", adVarChar, adParamInput, 1, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Route", adVarChar, adParamInput, 6, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Taxes", adDouble, adParamInput, , 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Freight", adDouble, adParamInput, , 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Additional", adDouble, adParamInput, , 0)
        
         NetAmount = 0
        If rsDistributor.State = 1 Then rsDistributor.Close
            rsDistributor.Open "Select * from distributoritems where DISTITEMCD = '" & Trim(Mid(varx, 6, 6)) & "'", cnn, adOpenKeyset
        If rsDistributor.RecordCount <> 0 Then
        NetAmount = rsDistributor.Fields(4).Value * Trim(Mid(varx, 12, 5))
        End If
        
        
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@NetAmount", adDouble, adParamInput, , NetAmount)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@UnitPrice", adDouble, adParamInput, , 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@InvoiceReferenceNumber", adInteger, adParamInput, , -1)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CMCode", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SONumber", adInteger, adParamInput, , -1)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SODate", adVarChar, adParamInput, 30, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SOTerms", adVarChar, adParamInput, 6, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ExpiryDate", adVarChar, adParamInput, 30, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@LotNumber", adVarChar, adParamInput, 15, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SalesmanNumber", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SalesmanName", adVarChar, adParamInput, 24, "")
        
        
        
        If rsCustomer.RecordCount <> 0 Then
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ShipToName", adVarChar, adParamInput, 255, rsCustomer.Fields(0).Value)
        Else
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ShipToName", adVarChar, adParamInput, 255, "")
        End If
        If rsCustomer.RecordCount <> 0 Then
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ShipToAddress1", adVarChar, adParamInput, 255, rsCustomer.Fields(1).Value)
        Else
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ShipToAddress1", adVarChar, adParamInput, 255, "")
        End If
        If rsCustomer.RecordCount <> 0 Then
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ShipToAddress2", adVarChar, adParamInput, 255, rsCustomer.Fields(2).Value)
        Else
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ShipToAddress2", adVarChar, adParamInput, 255, "")
        End If
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ZipCode", adVarChar, adParamInput, 6, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@TerritoryNumber", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Area", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerClass", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ClassName", adVarChar, adParamInput, 24, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Principal", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SubPrincipal", adVarChar, adParamInput, 6, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@PrincipalDivisionCode", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SalesWeek", adVarChar, adParamInput, 1, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerDeliveryCode", adVarChar, adParamInput, 4, "001")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ListPriceTaxInclude", adVarChar, adParamInput, 9, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ContractPrincipalApprovalNumber", adVarChar, adParamInput, 15, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@OrderType", adVarChar, adParamInput, 1, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@IsCode", adVarChar, adParamInput, 255, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CUTMO", adVarChar, adParamInput, 255, txtMonth.Text)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CUTYEAR", adVarChar, adParamInput, 255, cmbYear.Text)
        
        cmdRawData.Execute
     End If
        
        TotalGrossAmount = TotalGrossAmount + GrossAmount
        TotalQuantity = TotalQuantity + Trim(Mid(varx, 12, 5))
        urec = urec + 1
   ' End If
   
    If ProgressBar1.Value + n < ProgressBar1.Max Then
        ProgressBar1.Value = ProgressBar1.Value + n
    Else
        ProgressBar1.Value = ProgressBar1.Max
    End If
Next i
'If rsRawdata.State = 1 Then rsRawdata.Close
'    rsRawdata.Open "Select * from Rawdata Where CompanyCode = '" & "MER" & "'", cnn, adOpenKeyset
'
'If rsRawdata.RecordCount <> 0 Then
'For x = 1 To rsRawdata.RecordCount
'        Dim cmdPerformance As ADODB.Command
'        Set cmdPerformance = New ADODB.Command
'
'        cmdPerformance.ActiveConnection = cnnMercuryCustomer
'        cmdPerformance.CommandType = adCmdStoredProc
'        cmdPerformance.CommandText = "uspUploadingMercury"
'        cmdPerformance.Parameters.Append cmdPerformance.CreateParameter("@Distributor", adVarChar, adParamInput, 100, rsRawdata.Fields(4).Value)
'
'        cmdPerformance.Parameters.Append cmdPerformance.CreateParameter("Address", adVarChar, adParamOutput, 255)
'        cmdPerformance.Parameters.Append cmdPerformance.CreateParameter("CustomerStoreName", adVarChar, adParamOutput, 255)
'
'        cmdPerformance.Execute
'
'           m_Address = cmdPerformance("Address")
'           m_CustomerStoreName = cmdPerformance("CustomerStoreName")
'
'         Set cmdPerformance.ActiveConnection = Nothing
'
'    m_CustomerStoreName = Replace(m_CustomerStoreName, "'", "`")
'    cnn.Execute "Update RawData Set CustomerName = '" & m_CustomerStoreName & "' Where RawDataID = " & rsRawdata.Fields(0).Value & ""
'
'    m_Address = Replace(m_Address, "'", "`")
'    cnn.Execute "Update RawData Set CustomerAddress1 = '" & m_Address & "' Where RawDataID = " & rsRawdata.Fields(0).Value & ""
'
'
' rsRawdata.MoveNext
' Next x
'End If
Close #inthandle
inthandle = FreeFile
'End If
End Sub


Private Sub lblBrowseFile_Click()

cmdfile_Click
End Sub

Private Sub lblClose_Click()
Unload Me
End Sub

Private Sub lblUpload_Click()
SQLConnect
'SQLCustomerMercury

cmdImport_Click
'If CheckIfUnmmaped = 1 Then
'   Else
'End If
End
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
