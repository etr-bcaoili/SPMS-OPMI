VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomctl.ocx"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form FrmUploadDataInhouse 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "In - House"
   ClientHeight    =   4320
   ClientLeft      =   4185
   ClientTop       =   3990
   ClientWidth     =   7095
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4320
   ScaleWidth      =   7095
   StartUpPosition =   1  'CenterOwner
   Begin VB.Frame Frame2 
      BackColor       =   &H00FFFFFF&
      Height          =   1095
      Left            =   120
      TabIndex        =   8
      Top             =   840
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
         Left            =   3240
         TabIndex        =   10
         Top             =   480
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
         ItemData        =   "FrmUploadDataINH.frx":0000
         Left            =   1080
         List            =   "FrmUploadDataINH.frx":0002
         TabIndex        =   9
         Top             =   480
         Width           =   1215
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
         TabIndex        =   12
         Top             =   480
         Width           =   615
      End
      Begin VB.Label Label1 
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
         TabIndex        =   11
         Top             =   480
         Width           =   615
      End
   End
   Begin VB.Frame Frame1 
      BackColor       =   &H00FFFFFF&
      Height          =   1695
      Left            =   120
      TabIndex        =   3
      Top             =   1920
      Width           =   6855
      Begin VB.TextBox txtfile 
         Appearance      =   0  'Flat
         Height          =   315
         Left            =   1080
         Locked          =   -1  'True
         TabIndex        =   4
         Top             =   600
         Width           =   5205
      End
      Begin MSComctlLib.ProgressBar ProgressBar1 
         Height          =   255
         Left            =   120
         TabIndex        =   5
         Top             =   1320
         Visible         =   0   'False
         Width           =   6615
         _ExtentX        =   11668
         _ExtentY        =   450
         _Version        =   393216
         BorderStyle     =   1
         Appearance      =   1
         MouseIcon       =   "FrmUploadDataINH.frx":0004
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
         TabIndex        =   7
         Top             =   240
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
         Top             =   720
         Width           =   330
      End
   End
   Begin VB.PictureBox Picture1 
      BackColor       =   &H00DEC4B0&
      BorderStyle     =   0  'None
      Height          =   615
      Left            =   -120
      ScaleHeight     =   615
      ScaleWidth      =   8175
      TabIndex        =   0
      Top             =   3720
      Width           =   8175
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
         TabIndex        =   2
         Top             =   240
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
         Left            =   6480
         TabIndex        =   1
         Top             =   240
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
   Begin VB.Label Label5 
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
      Left            =   360
      TabIndex        =   14
      Top             =   120
      Width           =   2295
   End
   Begin VB.Image Image2 
      Height          =   765
      Left            =   0
      Picture         =   "FrmUploadDataINH.frx":0CDE
      Stretch         =   -1  'True
      Top             =   0
      Width           =   7125
   End
End
Attribute VB_Name = "FrmUploadDataInhouse"
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
Dim GrossAmount, TotalQuantity
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
''If "GPI" <> objWorksheet.Cells(i, 1) Then
'    MsgBox "Please check your rawdata and Company Code", vbInformation, "Invalid"
'    objExcel.Workbooks.Close
'    End
'End If
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
    GrossAmount = 0
    TotalQuantity = 0
n = (ProgressBar1.Max / ln) * 0.99
ProgressBar1.Value = 0

'On Error Resume Next
cnn.Execute "Delete From Rawdata Where CompanyCode = '" & Trim(objWorksheet.Cells(2, 1)) & "' AND CUTMO = '" & txtMonth.Text & "' AND CUTYEAR = '" & cmbYear.Text & "'"

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
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CompanyCode", adVarChar, adParamInput, 10, Trim(objWorksheet.Cells(2, 1)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@BranchCode", adVarChar, adParamInput, 10, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@BranchName", adVarChar, adParamInput, 255, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerNumber", adVarChar, adParamInput, 10, Trim(objWorksheet.Cells(i, 7)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerName", adVarChar, adParamInput, 255, Trim(objWorksheet.Cells(i, 9)))
        If Trim(objWorksheet.Cells(i, 10)) <> "" Then
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerAddress1", adVarChar, adParamInput, 255, Trim(objWorksheet.Cells(i, 10)))
        Else
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerAddress1", adVarChar, adParamInput, 255, "")
        End If
        If Trim(objWorksheet.Cells(i, 11)) <> "" Then
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerAddress2", adVarChar, adParamInput, 255, Trim(objWorksheet.Cells(i, 11)))
        Else
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerAddress2", adVarChar, adParamInput, 255, "")
        End If
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@TransactionDate", adVarChar, adParamInput, 8, Format(Trim(objWorksheet.Cells(i, 3)), "yyyymmdd"))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@InvoiceNumber", adVarChar, adParamInput, 10, Trim(objWorksheet.Cells(i, 4)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@TransactionType", adVarChar, adParamInput, 2, Trim(objWorksheet.Cells(i, 2)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ItemNumber", adVarChar, adParamInput, 20, Trim(objWorksheet.Cells(i, 12)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ItemDescription", adVarChar, adParamInput, 255, Trim(objWorksheet.Cells(i, 13)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@WarehouseNumber", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Class", adVarChar, adParamInput, 3, "")
        If Trim(objWorksheet.Cells(i, 16)) <> "" Then
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@QuantitySold", adInteger, adParamInput, , Trim(objWorksheet.Cells(i, 16)))
        TotalQuantity = TotalQuantity + Val(Trim(objWorksheet.Cells(i, 16)))
        Else
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@QuantitySold", adInteger, adParamInput, , -1)
        End If
        If Trim(objWorksheet.Cells(i, 17)) <> "" Then
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@QuantityFree", adInteger, adParamInput, , Trim(objWorksheet.Cells(i, 17)))
        Else
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@QuantityFree", adInteger, adParamInput, , 0)
        End If
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@GrossAmount", adDouble, adParamInput, , Trim(objWorksheet.Cells(i, 18)))
        GrossAmount = GrossAmount + Val(Trim(objWorksheet.Cells(i, 18)))
        'cmdRawData.Parameters.Append cmdRawData.CreateParameter("@LineDiscount", adDouble, adParamInput, , CDbl(Mid(varx, 206, 7)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@LineDiscount", adDouble, adParamInput, , 0)
        
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ProductDiscount", adDouble, adParamInput, , 0)
        
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@VatCode", adVarChar, adParamInput, 1, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Route", adVarChar, adParamInput, 6, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Taxes", adDouble, adParamInput, , 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Freight", adDouble, adParamInput, , 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Additional", adDouble, adParamInput, , 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@NetAmount", adDouble, adParamInput, , Trim(objWorksheet.Cells(i, 18)))
        

        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@UnitPrice", adDouble, adParamInput, , 0)

        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@InvoiceReferenceNumber", adInteger, adParamInput, , -1)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CMCode", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SONumber", adInteger, adParamInput, , -1)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SODate", adVarChar, adParamInput, 30, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SOTerms", adVarChar, adParamInput, 6, "")
        
        If Trim(objWorksheet.Cells(i, 15)) <> "" Then
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ExpiryDate", adVarChar, adParamInput, 30, Trim(objWorksheet.Cells(i, 15)))
        Else
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ExpiryDate", adVarChar, adParamInput, 30, "")
        End If
        
        If Trim(objWorksheet.Cells(i, 14)) <> "" Then
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@LotNumber", adVarChar, adParamInput, 15, Trim(objWorksheet.Cells(i, 14)))
        Else
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@LotNumber", adVarChar, adParamInput, 15, "")
        End If
        
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SalesmanNumber", adVarChar, adParamInput, 10, "")
        
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SalesmanName", adVarChar, adParamInput, 24, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ShipToName", adVarChar, adParamInput, 255, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ShipToAddress1", adVarChar, adParamInput, 255, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ShipToAddress2", adVarChar, adParamInput, 255, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ZipCode", adVarChar, adParamInput, 6, Trim(objWorksheet.Cells(i, 20)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@TerritoryNumber", adVarChar, adParamInput, 3, 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Area", adVarChar, adParamInput, 3, 0)
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerClass", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ClassName", adVarChar, adParamInput, 24, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Principal", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SubPrincipal", adVarChar, adParamInput, 6, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@PrincipalDivisionCode", adVarChar, adParamInput, 3, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@SalesWeek", adVarChar, adParamInput, 1, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@CustomerDeliveryCode", adVarChar, adParamInput, 4, Trim(objWorksheet.Cells(i, 8)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ListPriceTaxInclude", adVarChar, adParamInput, 9, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@ContractPrincipalApprovalNumber", adVarChar, adParamInput, 15, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@OrderType", adVarChar, adParamInput, 1, Trim(objWorksheet.Cells(i, 19)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@IsCode", adVarChar, adParamInput, 255, "")
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Cutmo", adVarChar, adParamInput, 255, Trim(objWorksheet.Cells(i, 5)))
        cmdRawData.Parameters.Append cmdRawData.CreateParameter("@Cutyear", adVarChar, adParamInput, 255, Trim(objWorksheet.Cells(i, 6)))
        
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
cnn.Execute "Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalQuantity,TotalNetAmount) " & _
    " Values('" & Trim(objWorksheet.Cells(2, 1)) & "','" & Right(txtfile, 22) & "','" & txtMonth.Text & "','" & cmbYear.Text & "','" & TotalQuantity & "','" & GrossAmount & "' )"
  
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
SQLConnect
Dim c_Year As Integer
Dim c_Company

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

' If rsCompany.State = 1 Then rsCompany.Close
'    rsCompany.Open "Select Distcomid From Distributor", cnn, adOpenKeyset
'
'With cmbCompanyCode
'
'    For c_Company = 1 To rsCompany.RecordCount
'        .AddItem rsCompany.Fields(0).Value
'        rsCompany.MoveNext
'    Next c_Company
'
'End With


End Sub

