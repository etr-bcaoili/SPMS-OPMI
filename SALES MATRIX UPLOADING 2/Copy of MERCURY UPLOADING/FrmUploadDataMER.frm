VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomctl.ocx"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form FrmUploadDataMercury 
   BackColor       =   &H80000009&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "MERCURY DRUG"
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
      Left            =   600
      TabIndex        =   8
      Top             =   2640
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
      Top             =   2280
      Width           =   4125
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
      MouseIcon       =   "FrmUploadDataMER.frx":0000
      Max             =   1000
      Scrolling       =   1
   End
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   0
      Top             =   4080
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
      CancelError     =   -1  'True
   End
   Begin VB.Label Label2 
      BackStyle       =   0  'Transparent
      Caption         =   "Please select file to be uploaded"
      Height          =   255
      Left            =   600
      TabIndex        =   7
      Top             =   1920
      Width           =   3615
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
      Picture         =   "FrmUploadDataMER.frx":0CDA
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
      Left            =   600
      TabIndex        =   2
      Top             =   2280
      Width           =   375
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
Dim repfile, filename As String
Dim urec As Long
Dim CheckIfUnmmaped As Integer

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
    CommonDialog1.Filter = "SP files(*.SP)|*.SP"
    CommonDialog1.ShowOpen
    txtfile.Text = CommonDialog1.filename
    filename = Right(txtfile, 7)
   
End Sub
Private Sub cmdImport_Click()
'-----------------------------------------------------------
If chkDeleteBillingOrder.Value = 1 Then
    
    Dim cmdDeleteRawData As ADODB.Command
    Set cmdDeleteRawData = New ADODB.Command
        
        cmdDeleteRawData.ActiveConnection = cnn
        cmdDeleteRawData.CommandType = adCmdStoredProc
        cmdDeleteRawData.CommandText = "uspDeleteRawData"
        cmdDeleteRawData.Parameters.Append cmdDeleteRawData.CreateParameter("@CompanyCode", adVarChar, adParamInput, 10, "MER")
    cmdDeleteRawData.Execute
    
    Dim cmdDeleteBillingOrder As ADODB.Command
    Set cmdDeleteBillingOrder = New ADODB.Command
        
        cmdDeleteBillingOrder.ActiveConnection = cnn
        cmdDeleteBillingOrder.CommandType = adCmdStoredProc
        cmdDeleteBillingOrder.CommandText = "uspX32DeleteBillingOrderData"
        cmdDeleteBillingOrder.Parameters.Append cmdDeleteBillingOrder.CreateParameter("@CompanyCode", adVarChar, adParamInput, 10, "MER")
    cmdDeleteBillingOrder.Execute
    
 Else
    
    If rsCheckRawDataFile.State = 1 Then rsCheckRawDataFile.Close
    rsCheckRawDataFile.Open "Select * from UploadedRawData Where CheckFileName = '" & filename & "' AND CompanyCode = '" & "MER" & "'", cnn, adOpenKeyset

    If rsCheckRawDataFile.RecordCount <> 0 Then
        MsgBox "Uploading cannot be completed, raw data already exist!", vbInformation
        Exit Sub
    End If
 
 End If
    
 If txtfile = "" Then
 
    MsgBox "No file to be uploaded", vbInformation, "Please select file"
    Exit Sub
    
 End If
    repfile = txtfile.Text
    urec = 0
    SQLConnect
    
    'ProgressBar1.Visible = True
    ImportData

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
Dim rsUnmmaped As New ADODB.Recordset
Dim strdata As String
Dim ln, i As Long
Dim x, y
inthandle = FreeFile

'open the file and count valid lines
Open repfile For Input Access Read As inthandle
ln = 0
'rsUnmmaped.Fields.Append "MercuryCode", adVarChar, 255
'rsUnmmaped.Open
   If rsUnmmaped.State = 1 Then rsUnmmaped.Close
        rsUnmmaped.Open "Select * from Unmmaped", cnn, adOpenKeyset
 
Do While Not EOF(inthandle)   ' Loop until end of file.
   Line Input #inthandle, strdata ' Read data into 1 variable.
    dte = Val(Mid(strdata, 186, 8))
    co = Trim(Mid(strdata, 1, 2))
    prn = Trim(Mid(strdata, 641, 3))
    
    If rsCustomerShiptoDetails.State = 1 Then rsCustomerShiptoDetails.Close
    rsCustomerShiptoDetails.Open "Select ShipToCustomerID from CustomerShipToDetails Where DistributorCode = '" & Trim(Mid(strdata, 2, 3)) & "'", cnnMercuryCustomer, adOpenKeyset
    
        
    If rsCustomerShiptoDetails.RecordCount = 0 Then
       
        cnn.Execute "Insert into Unmmaped(MercuryCode) Values('" & Trim(Mid(strdata, 2, 3)) & "')"
       
    End If
    
        ln = ln + 1
 
Loop


If ln <= 0 Then
    urec = 0
    Exit Sub
End If
Close #inthandle   'Close file.
inthandle = FreeFile


n = (ProgressBar1.Max / ln) * 0.99
ProgressBar1.Value = 0

   If rsUnmmaped.State = 1 Then rsUnmmaped.Close
        rsUnmmaped.Open "Select Distinct(MercuryCode) from Unmmaped", cnn, adOpenKeyset
 
If rsUnmmaped.RecordCount > 1 Then
    Set frmUnmmaped.DataGrid1.DataSource = rsUnmmaped
        frmUnmmaped.Show 1
        cnn.Execute "Delete from Unmmaped"
    urec = 1
    CheckIfUnmmaped = 1
    Exit Sub
Else
ProgressBar1.Visible = True
Open repfile For Input Access Read As inthandle
urec = 0

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
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@RawDataID", adInteger, adParamInput, , -1)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CompanyCode", adVarChar, adParamInput, 10, "MER")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@BranchCode", adVarChar, adParamInput, 10, Trim(Mid(varx, 2, 3)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@BranchName", adVarChar, adParamInput, 255, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerNumber", adVarChar, adParamInput, 10, Trim(Mid(varx, 2, 3)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerName", adVarChar, adParamInput, 255, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerAddress1", adVarChar, adParamInput, 255, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerAddress2", adVarChar, adParamInput, 255, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@TransactionDate", adVarChar, adParamInput, 8, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@InvoiceNumber", adVarChar, adParamInput, 10, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@TransactionType", adVarChar, adParamInput, 2, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ItemNumber", adVarChar, adParamInput, 20, Trim(Mid(varx, 5, 6)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ItemDescription", adVarChar, adParamInput, 255, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@WarehouseNumber", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Class", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@QuantitySold", adInteger, adParamInput, , Trim(Mid(varx, 11, 5)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@QuantityFree", adInteger, adParamInput, , -1)
        
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@GrossAmount", adDouble, adParamInput, , 0)
        'cmdRawData.Parameters.Append cmdRawData.CreateParameter("@LineDiscount", adDouble, adParamInput, , CDbl(Mid(varx, 206, 7)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@LineDiscount", adDouble, adParamInput, , 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ProductDiscount", adDouble, adParamInput, , 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@VatCode", adVarChar, adParamInput, 1, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Route", adVarChar, adParamInput, 6, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Taxes", adDouble, adParamInput, , 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Freight", adDouble, adParamInput, , 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Additional", adDouble, adParamInput, , 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@NetAmount", adDouble, adParamInput, , 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@UnitPrice", adDouble, adParamInput, , 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@InvoiceReferenceNumber", adInteger, adParamInput, , -1)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CMCode", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SONumber", adInteger, adParamInput, , -1)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SODate", adInteger, adParamInput, , -1)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SOTerms", adVarChar, adParamInput, 6, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ExpiryDate", adInteger, adParamInput, , -1)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@LotNumber", adVarChar, adParamInput, 15, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SalesmanNumber", adVarChar, adParamInput, 3, "")
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
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerDeliveryCode", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ListPriceTaxInclude", adVarChar, adParamInput, 9, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ContractPrincipalApprovalNumber", adVarChar, adParamInput, 15, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@OrderType", adVarChar, adParamInput, 1, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@IsCode", adVarChar, adParamInput, 255, "")
        
        cmdRawData.Execute
        
        
    
        urec = urec + 1
   ' End If
   
    If ProgressBar1.Value + n < ProgressBar1.Max Then
        ProgressBar1.Value = ProgressBar1.Value + n
    Else
        ProgressBar1.Value = ProgressBar1.Max
    End If
Next i
If rsRawdata.State = 1 Then rsRawdata.Close
    rsRawdata.Open "Select * from Rawdata Where CompanyCode = '" & "MER" & "'", cnn, adOpenKeyset
 
For x = 1 To rsRawdata.RecordCount
    
If rsCustomerShiptoDetails.State = 1 Then rsCustomerShiptoDetails.Close
    rsCustomerShiptoDetails.Open "Select ShipToCustomerID from CustomerShipToDetails Where DistributorCode = '" & rsRawdata.Fields(4).Value & "'", cnnMercuryCustomer, adOpenKeyset
If rsCustomerShiptoDetails.RecordCount <> 0 Then
 If rsCustomer.State = 1 Then rsCustomer.Close
    rsCustomer.Open "SELECT cust_accntno, cust_storename, b.street,  d.description + ', ' + c.description " & _
                   "FROM customers  a , " & _
                   "addresses b, " & _
                   "systemclassification c, " & _
                   "systemclassification d " & _
                   "Where custkey = " & rsCustomerShiptoDetails.Fields(0).Value & " " & _
                   "and b.addressid = a.customeraddressid " & _
                   "and c.systemclassificationid = b.provincekey " & _
                   "and d.systemclassificationid = b.citykey", cnnMercuryCustomer, adOpenKeyset
                                   
    cnn.Execute "Update RawData Set CustomerName = '" & rsCustomer.Fields(1).Value & "' Where RawDataID = " & rsRawdata.Fields(0).Value & ""
    cnn.Execute "Update RawData Set CustomerAddress1 = '" & rsCustomer.Fields(2).Value & "' Where RawDataID = " & rsRawdata.Fields(0).Value & ""
    cnn.Execute "Update RawData Set CustomerAddress2 = '" & rsCustomer.Fields(3).Value & "' Where RawDataID = " & rsRawdata.Fields(0).Value & ""
     
End If
 rsRawdata.MoveNext
 Next x

Close #inthandle
inthandle = FreeFile
End If
End Sub


Private Sub lblBrowseFile_Click()

cmdfile_Click
End Sub

Private Sub lblClose_Click()
Unload Me
End Sub

Private Sub lblUpload_Click()
SQLConnect
SQLCustomerMercury

cmdImport_Click
If CheckIfUnmmaped = 1 Then
   Else
cnn.Execute "Insert Into UploadedRawData(CompanyCode,CheckFileName) " & _
        " Values('" & "MER" & "','" & filename & "')"
End If
End Sub
