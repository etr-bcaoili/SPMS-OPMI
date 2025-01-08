Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule

Imports Microsoft.Office.Interop


Public Class UCSalesCreditExclusion
    Private Operation As String = "'"



    Private Sub ClearForm()
        PopulateComboBox()

        dgDetails.Rows.Clear()

        dtStart.Value = Today.ToShortDateString
        dtEnd.Value = Today.ToShortDateString
    End Sub

    Private Sub PopulateComboBox()
        cmbcomid.Items.Clear()
        cmbComDesc.Items.Clear()
        cmbcomid.Text = ""
        cmbComDesc.Text = ""


        Dim rs As New ADODB.Recordset
        rs = Company()
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount

                cmbcomid.Items.Add(rs.Fields("DistComid").Value)
                cmbComto.Items.Add(rs.Fields("DistComid").Value)

                cmbComDesc.Items.Add(rs.Fields("DistName").Value)
                cmbComToDesc.Items.Add(rs.Fields("Distname").Value)

                rs.MoveNext()
            Next
        End If
    End Sub

    Private Function Company(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("Select * from Distributor Where dltflg = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function



    Private Sub SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcomid.SelectedIndexChanged, cmbComDesc.SelectedIndexChanged, cmbComToDesc.SelectedIndexChanged, cmbComto.SelectedIndexChanged
        Dim rs As New ADODB.Recordset

        If sender Is cmbComDesc Then
            cmbMonth.Items.Clear()
            cmbyear.Items.Clear()
            rs = Company("DistName = '" & cmbComDesc.Text & "' ")
            If rs.RecordCount > 0 Then
                cmbcomid.Text = rs.Fields("DistComID").Value

                'rs = RsCalendarMonth("COMID = '" & cmbcomid.Text & "' ")
                'If rs.RecordCount > 0 Then
                '    For i As Integer = 1 To rs.RecordCount
                '        cmbMonth.Items.Add(rs.Fields("CAPN").Value)
                '        rs.MoveNext()
                '    Next
                'End If

                'rs = RsCalendarYear("COMID = '" & cmbcomid.Text & "' ")
                'If rs.RecordCount > 0 Then
                '    For i As Integer = 1 To rs.RecordCount
                '        cmbyear.Items.Add(rs.Fields("CAYR").Value)
                '        rs.MoveNext()

                '    Next
                'End If

            End If
        ElseIf sender Is cmbcomid Then
            cmbMonth.Items.Clear()
            cmbyear.Items.Clear()
            rs = Company("DistComID = '" & cmbcomid.Text & "' ")
            If rs.RecordCount > 0 Then
                cmbComDesc.Text = rs.Fields("DistName").Value



                rs = RsCalendarMonth("COMID = '" & cmbcomid.Text & "' ")
                If rs.RecordCount > 0 Then
                    For i As Integer = 1 To rs.RecordCount
                        cmbMonth.Items.Add(rs.Fields("CAPN").Value)
                        rs.MoveNext()
                    Next
                End If

                rs = RsCalendarYear("COMID = '" & cmbcomid.Text & "' ")
                If rs.RecordCount > 0 Then
                    For i As Integer = 1 To rs.RecordCount
                        cmbyear.Items.Add(rs.Fields("CAYR").Value)
                        rs.MoveNext()

                    Next
                End If
            End If

        ElseIf sender Is cmbComto Then
            rs = Company("DistComid = '" & cmbComto.Text & "' ")
            If rs.RecordCount > 0 Then
                cmbComToDesc.Text = rs.Fields("Distname").Value


            End If

        ElseIf sender Is cmbComToDesc Then
            rs = Company("Distname = '" & cmbComToDesc.Text & "' ")

            If rs.RecordCount > 0 Then
                cmbComto.Text = rs.Fields("DistCOMID").Value
            End If
        End If

    End Sub

    Private Sub UCSalesCreditExclusion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(dgDetails)
        ApplyGridTheme(GridListing)
        ClearForm()
        SetupOperation(True)
        Operation = "Add"
        PopulateListingGrid(OpenListing)
    End Sub

    Private Sub ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click, btnClose.Click, btnDelete.Click, btnEdit.Click, btnSave.Click
        If sender Is btnAdd Then
            ClearForm()
            SetupOperation(True)
            Operation = "Add"
        ElseIf sender Is btnEdit Then
            SetupOperation(True)
            Operation = "Edit"
        ElseIf sender Is btnDelete Then
            If ValidFields() = True Then
                DeleteRecord()
                SetupOperation(False)
                Operation = ""
                ClearForm()
                DeleteSuccess()
                PopulateListingGrid(OpenListing)
            End If
        ElseIf sender Is btnSave Then
            If Operation = "Add" Then
                If ValidFields() = True Then
                    SaveRecord()
                    SetupOperation(False)
                    Operation = ""
                    SaveSuccess()
                End If
            ElseIf Operation = "Edit" Then
                If ValidFields() = True Then
                    UpdateRecord()
                    SetupOperation(False)
                    Operation = ""
                    SaveSuccess()
                End If
            End If
            PopulateListingGrid(OpenListing)
        ElseIf sender Is btnClose Then
            On Error Resume Next
            Dim m_TabPage As TabPage = Me.Parent
            CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
            Me.Dispose()
            End If

    End Sub



    Private Sub llCustomerSelection_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCustomerSelection.LinkClicked

        If cmbComDesc.Text = "" Or cmbcomid.Text = "" Then
            ShowInformation("Please Select a Channel First", "Blank Channel")
        Else
            Dim tag As New SelectionTag
            Dim rs As New ADODB.Recordset
            'tag = ShowSearchDialog("CustomerCD; ComID; CustomerCD; CustomerName; RegCD;  DistCD; AreaCD", "SELECT COMID AS  COMID, CUSTOMERCD AS CUSTOMERCODE, CustomerName AS CUSTOMERNAME, REGCD  AS REGIONCODE, DISTCD AS PROVINCECODE, AREACD AS MUNICIPALITY FROM CUSTOMER WHERE CustomerDel = 0 AND COMID = '" & cmbcomid.Text & "' /*ORDER BY COMID, CustomerCD, CDACD*/")
            tag = ShowSearchDialog("CustomerCD; ComID; CustomerCD; CustomerName; RegCD;  DistCD; AreaCD", "Select CustomerCD, COMID, CustomerCD AS CustomerCode, CustomerName as CustomerName, RegCD as RegionCode, DistCD as Provincecode, AreaCd as Municipality FROM Customer WHERE CustomerDel =  0 AND COMID  = '" & cmbcomid.Text & "' ")

            If Not tag Is Nothing Then
                Dim row As DataGridViewRow = dgDetails.Rows(dgDetails.Rows.Add)

                'rs = LinkedCustomer(" A.CustomerCD = '" & tag.KeyColumn2 & "' AND A.COMID = '" & tag.KeyColumn1 & "' AND CDACD = '" & tag.KeyColumn3 & "' ")
                rs = LinkedCustomer(" A.CustomerCd = '" & tag.KeyColumn1 & "' AND A.COMID = '" & tag.KeyColumn2 & "'")

                row.Cells(colCustomerCd.Index).Value = rs.Fields("CustomerCD").Value
                ' row.Cells(colShipto.Index).Value = rs.Fields("ShiptoCode").Value
                row.Cells(colCustomerName.Index).Value = rs.Fields("CustomerName").Value
                row.Cells(colRegCD.Index).Value = rs.Fields("RegCD").Value
                row.Cells(colRegName.Index).Value = rs.Fields("RegName").Value
                row.Cells(colDistrictCD.Index).Value = rs.Fields("DistrctCD").Value
                row.Cells(colDistrictName.Index).Value = rs.Fields("DistrctName").Value
                row.Cells(colAreaCD.Index).Value = rs.Fields("AreaCD").Value
                row.Cells(colAreaName.Index).Value = rs.Fields("AreaName").Value

                'row.Cells(colCustomerCd.Index).Value = tag.KeyColumn2
                'row.Cells(colCustomerName.Index).Value = tag.KeyColumn3
            End If
        End If



    End Sub

    Private Function RsCalendarYear(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset

        If Filter <> "" Then
            Filter = " WHERE " & Filter
        End If

        rs.Open("SELECT DISTINCT CAYR FROM CALENDAR  " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Return rs
    End Function

    Private Function RsCalendarMonth(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset

        If Filter <> "" Then
            Filter = " WHERE " & Filter
        End If
        rs.Open("SELECT Distinct Capn FROM CALENDAR  " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs


    End Function

    Private Function LinkedCustomer(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        Dim str As String = ""
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If
        str = str & "SELECT A.COMID AS COMID, "
        str = str & "A.CUSTOMERCD AS CUSTOMERCD, "
        str = str & "A.CUSTOMERNAME AS CUSTOMERNAME, "
        str = str & "A.REGCD AS REGCD,  "
        str = str & "B.REGNAME AS REGNAME, "
        str = str & "A.DISTCD AS DISTRCTCD, "
        str = str & " DISTRCTNAME AS DISTRCTNAME, "
        str = str & "A.AREACD AS AREACD,   "
        str = str & "AREANAME AS AREANAME "
        str = str & "FROM	CUSTOMER AS A,  "
        str = str & "REGION AS B,  "
        str = str & "DISTRICT AS C,  "
        str = str & "AREA AS D  "
        str = str & "WHERE(B.REGCD = A.REGCD)"
        str = str & "AND 	C.REGCD = A.REGCD  "
        str = str & "AND 	C.DISTRCTCD = A.DISTCD  "
        str = str & "AND 	D.REGCD = A.REGCD  "
        str = str & "AND 	D.DISTRCTCD = A.DISTCD  "
        str = str & "AND 	D.AREACD = A.AREACD  "
        str = str & "AND 	A.CUSTOMERDEL = 0  "
        str = str & "AND 	B.DLTFLG = 0   "
        str = str & "AND 	C.DLTFLG = 0  "
        str = str & "AND 	D.DLTFLG = 0 "

        rs.Open(str & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs
    End Function

    'Private Function LinkedCustomer(Optional ByVal Filter As String = "") As ADODB.Recordset
    '    Dim rs As New ADODB.Recordset
    '    Dim str As String = ""
    '    If Filter <> "" Then
    '        Filter = " AND " & Filter
    '    End If
    '    str = str & "SELECT	A.COMID AS COMID, "
    '    str = str & "A.CUSTOMERCD AS CUSTOMERCD, "
    '    str = str & "A.CDACD AS SHIPTOCODE, "
    '    str = str & " A.CDANAME AS CUSTOMERNAME, "
    '    str = str & "A.REGCD AS REGCD, "
    '    str = str & " B.REGNAME AS REGNAME, "
    '    str = str & "A.DISTCD AS DISTRCTCD, "
    '    str = str & "C.DISTRCTNAME AS DISTRCTNAME, "
    '    str = str & "A.AREACD AS AREACD,  "
    '    str = str & " D.AREANAME AS AREANAME"
    '    str = str & " FROM	CUSTOMERSHIPTO AS A, "
    '    str = str & " REGION AS B, "
    '    str = str & " DISTRICT AS C, "
    '    str = str & " AREA AS D "
    '    str = str & " WHERE		B.REGCD = A.REGCD "
    '    str = str & " AND C.REGCD = A.REGCD "
    '    str = str & " AND C.DISTRCTCD = A.DISTCD "
    '    str = str & " AND D.REGCD = A.REGCD "
    '    str = str & " AND D.DISTRCTCD = A.DISTCD "
    '    str = str & " AND D.AREACD = A.AREACD "
    '    str = str & " AND A.CUSTOMERSHIPTODEL = 0 "
    '    str = str & " AND B.DLTFLG = 0  "
    '    str = str & " AND C.DLTFLG = 0 "
    '    str = str & " AND D.DLTFLG = 0 "
    '    rs.Open(str & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)



    '    Return rs

    'End Function

    Private Sub SetupOperation(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation

    End Sub


    Private Function ValidFields() As Boolean
        If cmbcomid.Text = "" Or cmbComDesc.Text = "" Then
            ShowInformation("Select Channel first", "Invalid Channel")
            Return False
            'ElseIf cmbMonth.Text = "" Then
            '    ShowInformation("Select Month first", "Invalid Month")
            'ElseIf cmbyear.Text = "" Then
            '    ShowInformation("Select Year first", "Invalid Year")
        ElseIf dgDetails.Rows.Count = 0 Then
            ShowInformation("No Customer Selected", "No Customer Selected")
            Return False
        Else
            Return True
        End If
    End Function

    Private Function SaveRecord() As Boolean
        On Error GoTo ErrorHandler
     


        For i As Integer = 0 To dgDetails.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetails.Rows(i)
            SPMSConn.Execute("EXEC USPSALESEXTENSION @ACTION = 'ADD' ,@COMID = '" & cmbcomid.Text & "'  , " & _
            "@COMNAME = '" & cmbComDesc.Text & "', " & _
            "@CUSTOMERCD = '" & row.Cells(colCustomerCd.Index).Value & "' , " & _
            "@CUSTOMERNAME  = '" & row.Cells(colCustomerName.Index).Value & "' , " & _
           "@CRTDDTE =  '" & Today.ToShortDateString & "' , " & _
           "@CRTDBY = '', " & _
           "@UPDD = '" & Today.ToShortDateString & "' , " & _
           "@UPDU = '', " & _
           "@CUTMO = '" & cmbMonth.Text & "', " & _
           "@CUTYEAR = '" & cmbyear.Text & "' , " & _
           "@EFFECTIVITYSTARTDATE = '" & dtStart.Value & "' , " & _
           "@EFFECTIVITYENDDATE = '" & dtEnd.Value & "' , " & _
           "@DLTFLG  = 0 , @CDACD = '" & row.Cells(colShipto.Index).Value & "', " & _
           "@COMIDTo = '" & cmbComto.Text & "' , @CreateNewChannel = '" & chkIsCreateNew.Checked & "' ")

            If chkIsCreateNew.Checked Then
                CreateCustomer(cmbcomid.Text, row.Cells(colCustomerCd.Index).Value, cmbComto.Text)
            End If

        Next

        Return True

ErrorHandler:
        ShowInformation(Err.Number & ": " & Err.Description, "Save Error")
        Err.Clear()
        Return False
    End Function

    Private Sub CreateCustomer(ByVal ComID As String, ByVal CustomerCode As String, ByVal ComIDTO As String)
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()

        rs.Open("SELECT * FROM CUSTOMER WHERE CUSTOMERDEL = 0 AND COMID = '" & HandleSingleQuoteInSql(ComID) & "' AND CustomerCD = '" & CustomerCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Dim m_Action As String = ""
            Try

                If CheckIfCustomerCodeExist(CustomerCode, ComIDTO) Then
                    m_Action = "UPDATE"
                Else
                    m_Action = "ADD"
                End If

                SPMSConn.Execute("EXEC uspCustomer @Action = '" & m_Action & "' , @Comid = '" & ComIDTO & "' , " & _
                                            " @CustomerCD = '" & HandleSingleQuoteInSql(rs.Fields("CUSTOMERCD").Value) & "', @CustomerNAME = '" & HandleSingleQuoteInSql(rs.Fields("CUSTOMERNAME").Value) & "' , " & _
                                            " @CADD1 = '" & HandleSingleQuoteInSql(rs.Fields("CADD1").Value) & "', @CADD2 = '" & HandleSingleQuoteInSql(rs.Fields("CADD2").Value) & "' , @CMCont = '" & HandleSingleQuoteInSql(rs.Fields("CMCont").Value) & "' , @Cmphon = '" & rs.Fields("CMPHON").Value & "', " & _
                                            " @CDACD = '" & HandleSingleQuoteInSql(rs.Fields("CDACD").Value) & "' , @ZIPCD = '" & rs.Fields("ZIPCD").Value & "' , @REGCD = '" & rs.Fields("REGCD").Value & "' , " & _
                                            " @DISTCD = '" & rs.Fields("DISTCD").Value & "' , @AREACD = '" & rs.Fields("AREACD").Value & "', @CMGRP = '" & rs.Fields("CMGRP").Value & "' , @CMCLASS = '" & rs.Fields("CMCLASS").Value & "'  , " & _
                                            " @AREACOVRG = '" & rs.Fields("AREACOVRG").Value & "' , @VAT = " & rs.Fields("VAT").Value & ", @OLDCUSTCODE = '" & rs.Fields("CUSTOMERCD").Value & "' , " & _
                                            " @ACCNTSHRD = " & rs.Fields("ACCNTSHRD").Value & "  ")

                CreateShipTo(ComID, CustomerCode, ComIDTO)

            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try

        End If


    End Sub


    Private Function CheckIfCustomerCodeExist(ByVal CustomerCode As String, ByVal ComID As String) As Boolean

        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM CUSTOMER WHERE CUSTOMERDEL = 0 AND CUSTOMERCD = '" & CustomerCode & "'  AND COMID = '" & ComID & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function CheckIfShipToCustomerCodeExist(ByVal CustomerShipToCode As String, ByVal CompanyCode As String, ByVal CustomerCode As String) As Boolean
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * FROM CUSTOMERSHIPTO WHERE CUSTOMERSHIPTODEL = 0  AND COMID = '" & HandleSingleQuoteInSql(CompanyCode) & "' AND CUSTOMERCD = '" & HandleSingleQuoteInSql(CustomerCode) & "' AND CDACD = '" & HandleSingleQuoteInSql(CustomerShipToCode) & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub CreateShipTo(ByVal ComID As String, ByVal CustomerCode As String, ByVal COmIDTO As String)

        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()

        rs.Open("SELECT * FROM CUSTOMERSHIPTO WHERE COMID = '" & ComID & "' AND CUSTOMERCD = '" & CustomerCode & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Dim m_Action As String = ""
            Try

                For m As Integer = 0 To rs.RecordCount - 1

                    If CheckIfShipToCustomerCodeExist(rs.Fields("CDACD").Value, COmIDTO, CustomerCode) Then
                        m_Action = "UPDATE"
                    Else
                        m_Action = "ADD"
                    End If

                    SPMSConn.Execute("EXEC uspCustomerShipTo @Action = '" & m_Action & "' ,  @COMID =  '" & COmIDTO & "' , " & _
                                " @CustomerCD = '" & HandleSingleQuoteInSql(rs.Fields("CUSTOMERCD").Value) & "' ,  " & _
                                " @CDACD = '" & HandleSingleQuoteInSql(rs.Fields("CDACD").Value) & "' , @CDANAME = '" & HandleSingleQuoteInSql(rs.Fields("CDANAME").Value) & "' , " & _
                                " @CDACADD1 = '" & HandleSingleQuoteInSql(rs.Fields("CDACADD1").Value) & "' , @CDACADD2 = '" & HandleSingleQuoteInSql(rs.Fields("CDACADD2").Value) & "' , " & _
                                " @CDACONT= '" & rs.Fields("CDACONT").Value & "' , @CDAPHON = '" & rs.Fields("CDACONT").Value & "', " & _
                                " @ZIPCD = '" & rs.Fields("ZIPCD").Value & "' , @REGCD = '" & rs.Fields("REGCD").Value & "' , " & _
                                " @DISTCD = '" & rs.Fields("DISTCD").Value & "' , @AREACD = '" & rs.Fields("AREACD").Value & "' , @TERRCD = '" & "" & "' , @CMGRP = '" & rs.Fields("CMGRP").Value & "' , @CMCLASS = '" & rs.Fields("CMCLASS").Value & "'  , " & _
                                " @AREACOVRG = '" & "" & "' , @ACCNTSHRD = " & rs.Fields("ACCNTSHRD").Value & "  ")

                    rs.MoveNext()
                Next



            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try


        End If


    End Sub


    Private Function UpdateRecord() As Boolean
        On Error GoTo ErrorHandler



        For i As Integer = 0 To dgDetails.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetails.Rows(i)
            Dim strsql As String = ""

            strsql = strsql & "EXEC USPSALESEXTENSION @ACTION = 'UPDATE' ,@COMID = '" & cmbcomid.Text & "'  , "
            strsql = strsql & "@COMNAME = '" & cmbComDesc.Text & "', "
            strsql = strsql & "@CUSTOMERCD = '" & row.Cells(colCustomerCd.Index).Value & "' , "
            strsql = strsql & "@CUSTOMERNAME  = '" & row.Cells(colCustomerName.Index).Value & "' , "
            strsql = strsql & "@CRTDDTE =  '" & Today.ToShortDateString & "' , "
            strsql = strsql & "@CRTDBY = '', "
            strsql = strsql & "@UPDD = '" & Today.ToShortDateString & "' , "
            strsql = strsql & "@UPDU = '', "
            strsql = strsql & "@CUTMO = '" & cmbMonth.Text & "', "
            strsql = strsql & "@CUTYEAR = '" & cmbyear.Text & "' , "
            strsql = strsql & "@EFFECTIVITYSTARTDATE = '" & dtStart.Value & "' , "
            strsql = strsql & "@EFFECTIVITYENDDATE = '" & dtEnd.Value & "' , "
            strsql = strsql & "@DLTFLG  = 0, @SALESEXTENSIONID = " & row.Cells(colID.Index).Value
            strsql = strsql & ", @ComIDTo = '" & cmbComto.Text & "'  , @CreateNewChannel = '" & chkIsCreateNew.Checked & "'  "

            SPMSConn.Execute(strsql)
            ' SPMSConn.Execute("EXEC USPSALESEXTENSION @ACTION = 'UPDATE' ,@COMID = '" & cmbcomid.Text & "'  , " 
            ' "@COMNAME = '" & cmbComDesc.Text & "', " 
            ' "@CUSTOMERCD = '" & row.Cells(colCustomerCd.Index).Value & "' , " 
            ' "@CUSTOMERNAME  = '" & row.Cells(colCustomerName.Index).Value & "' , " 
            '"@CRTDDTE =  '" & Today.ToShortDateString & "' , " 
            '"@CRTDBY = '', " 
            '"@UPDD = '" & Today.ToShortDateString & "' , " 
            '"@UPDU = '', " 
            '"@CUTMO = '" & cmbMonth.Text & "', " 
            '"@CUTYEAR = '" & cmbyear.Text & "' , " 
            '"@EFFECTIVITYSTARTDATE = '" & dtStart.Value & "' , " 
            '"@EFFECTIVITYENDDATE = '" & dtEnd.Value & "' , " 
            '"@DLTFLG  = 0, @SALESEXTENSIONID = " & row.Cells(colID.Index).Value)
        Next

        Return True

ErrorHandler:
        ShowInformation(Err.Number & ": " & Err.Description, "Save Error")
        Err.Clear()
        Return False
        Return True
    End Function


    Private Function DeleteRecord() As Boolean
        On Error GoTo ErrorHandler



        For i As Integer = 0 To dgDetails.Rows.Count - 1
            Dim row As DataGridViewRow = dgDetails.Rows(i)
            SPMSConn.Execute("EXEC USPSALESEXTENSION @ACTION = 'DELETE',  @SALESEXTENSIONID = " & row.Cells(colID.Index).Value & ", @DLTFLG = 1 ")
        Next

        Return True

ErrorHandler:
        ShowInformation(Err.Number & ": " & Err.Description, "Delete Error")
        Err.Clear()
        Return False
        Return True
    End Function

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim rows() As Integer
        Dim ctr As Integer = -1
        If dgDetails.Rows.Count > 0 Then
            For i As Integer = 0 To dgDetails.Rows.Count - 1
                Dim row As DataGridViewRow = dgDetails.Rows(i)
                If row.Cells(colSelect.Index).Value = True Then
                    ctr += 1
                    ReDim rows(ctr)
                    rows(ctr) = i
                    'dgDetails.Rows.Remove(row)
                    'dgDetails.Rows.RemoveAt(i)

                End If
            Next

            If ctr >= 0 Then
                Dim tmp As Integer = ctr
                For i As Integer = 0 To ctr
                    dgDetails.Rows.RemoveAt(rows(ctr))
                    'dgDetails.Rows.RemoveAt(rows(i))
                    'dgDetails.Rows.Remove(
                    ctr -= 1
                Next
            End If
        End If
    End Sub

    Private Function OpenListing(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT * FROM SALESEXTENSION WHERE DLTFLG = 0 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs
    End Function

    Private Sub PopulateListingGrid(ByVal rs As ADODB.Recordset)
        GridListing.Rows.Clear()
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(selCompanyCode.Index).Value = rs.Fields("COMID").Value
                row.Cells(selCompanyName.Index).Value = rs.Fields("ComName").Value
                row.Cells(selCustoemrCode.Index).Value = rs.Fields("CustomerCD").Value
                row.Cells(selShiptoCode.Index).Value = rs.Fields("CDACD").Value
                row.Cells(selCustomerName.Index).Value = rs.Fields("CustomerName").Value
                row.Cells(selID.Index).Value = rs.Fields("SalesExtensionID").Value
                row.Cells(selEffectivityStartDate.Index).Value = rs.Fields("EffectivityStartDate").Value
                row.Cells(selEffectivityEndDate.Index).Value = rs.Fields("EffectivityEndDate").Value
                row.Cells(colCreateNew.Index).Value = rs.Fields("CreateNewChannel").Value
                'row.Cells(selShiptoCode.Index).Value = rs.Fields("CDACD")
                rs.MoveNext()
            Next
        End If
    End Sub



    Private Sub GridListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick
        If e.RowIndex <> -1 Then
            Dim rs As New ADODB.Recordset
            ClearForm()
            Dim row As DataGridViewRow = GridListing.Rows(e.RowIndex)

            cmbcomid.Text = row.Cells(selCompanyCode.Index).Value
            dtStart.Value = row.Cells(selEffectivityStartDate.Index).Value
            dtEnd.Value = row.Cells(selEffectivityEndDate.Index).Value
            chkIsCreateNew.Checked = row.Cells(colCreateNew.Index).Value

            Dim Rows As DataGridViewRow = dgDetails.Rows(dgDetails.Rows.Add)
            'Rows.Cells(colID.Index).Value = row.Cells(selID.Index).Value
            'Rows.Cells(colCustomerCd.Index).Value = row.Cells(selCustoemrCode.Index).Value
            'Rows.Cells(colCustomerName.Index).Value = row.Cells(selCustomerName.Index).Value


            'rs = LinkedCustomer(" A.COMID = '" & row.Cells(selCompanyCode.Index).Value & "' AND A.CustomerCd = '" & row.Cells(selCustoemrCode.Index).Value & "'  AND A.CDACD = '" & row.Cells(selShiptoCode.Index).Value & "' ")
            rs = LinkedCustomer(" A.COMID = '" & row.Cells(selCompanyCode.Index).Value & "' AND A.CustomerCd = '" & row.Cells(selCustoemrCode.Index).Value & "' ")

            If rs.RecordCount > 0 Then
                Rows.Cells(colCustomerCd.Index).Value = rs.Fields("CustomerCD").Value
                'Rows.Cells(colShipto.Index).Value = rs.Fields("ShiptoCode").Value
                Rows.Cells(colCustomerName.Index).Value = rs.Fields("CustomerName").Value
                Rows.Cells(colRegCD.Index).Value = rs.Fields("RegCD").Value
                Rows.Cells(colRegName.Index).Value = rs.Fields("RegName").Value
                Rows.Cells(colDistrictCD.Index).Value = rs.Fields("DistrctCD").Value
                Rows.Cells(colDistrictName.Index).Value = rs.Fields("DistrctName").Value
                Rows.Cells(colAreaCD.Index).Value = rs.Fields("AreaCD").Value
                Rows.Cells(colAreaName.Index).Value = rs.Fields("AreaName").Value
                Rows.Cells(colID.Index).Value = row.Cells(selID.Index).Value

            End If

            SetupOperation(False)
            Operation = ""
            MainTab.SelectTab(0)

        End If
    End Sub

    Private Sub GridListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick

    End Sub


    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        filter()
    End Sub

    Private Sub filter()
        Dim rs As New ADODB.Recordset
        If cmbfilter.Text <> "" Then
            If cmbfilter.Text = "All" Then
                rs = OpenListing()
            ElseIf cmbfilter.Text = "ChannelCode" Then
                rs = OpenListing("COMID like '%" & txtFilter.Text & "%' ")
            ElseIf cmbfilter.Text = "ChannelName" Then
                rs = OpenListing("COMNAME like '%" & txtFilter.Text & "%'")
            ElseIf cmbfilter.Text = "CustomerCode" Then
                rs = OpenListing("CustomerCd like '%" & txtFilter.Text & "%'")
            ElseIf cmbfilter.Text = "CustomerName" Then
                rs = OpenListing("CustomerName like '%" & txtFilter.Text & "%' ")
            End If
            PopulateListingGrid(rs)
        End If
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If AscW(e.KeyChar) = 13 Then
            filter()
        End If
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub

    Private Sub chkIsCreateNew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsCreateNew.CheckedChanged
        If chkIsCreateNew.Checked Then
            Label5.Visible = True
            cmbComto.Visible = True
            cmbComToDesc.Visible = True
        Else
            Label5.Visible = False
            cmbComto.Visible = False
            cmbComToDesc.Visible = False
        End If
    End Sub
End Class
