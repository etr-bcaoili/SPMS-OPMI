Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Public Class ucAdministrationCalendar
    Private GridRs As New ADODB.Recordset
    Private Operation As String = ""
    Private Sub PopulateComboBox()
        cmbcompany.Items.Clear()
        cmbyear.Items.Clear()
        Dim rs2 As New ADODB.Recordset
        If rs2.State = 1 Then rs2.Close()
        cmbcompany.Items.Add("")
        rs2.Open("SELECT TOP 1 COMID FROM Company Where DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs2.RecordCount > 0 Then
            cmbcompany.Items.Add(rs2.Fields("COMID").Value)
        End If

        Dim rs As New ADODB.Recordset
        rs.Open("select DISTINCT DISTCOMID  from DISTRIBUTOR where DLTFLG = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            For I As Integer = 1 To rs.RecordCount
                cmbcompany.Items.Add(rs.Fields("distCOMID").Value)
                rs.MoveNext()
            Next
        End If


        For i As Integer = Year(Now) - 10 To Year(Now) + 2
            cmbyear.Items.Add(i)
        Next

    End Sub

    Private Sub ClearForm()
        PopulateComboBox()
        
        cmb1.Text = MonthName(Month(dt1.Value))
        
        cmb2.Text = MonthName(Month(dt2.Value))
        
        cmb3.Text = MonthName(Month(dt3.Value))

        cmb4.Text = MonthName(Month(dt4.Value))
        
        cmb5.Text = MonthName(Month(dt5.Value))
        
        cmb6.Text = MonthName(Month(dt6.Value))
        
        cmb7.Text = MonthName(Month(dt7.Value))
        
        cmb8.Text = MonthName(Month(dt8.Value))
        
        cmb9.Text = MonthName(Month(dt9.Value))
        
        cmb10.Text = MonthName(Month(dt10.Value))
        
        cmb11.Text = MonthName(Month(dt11.Value))
        
        cmb12.Text = MonthName(Month(dt12.Value))

    End Sub

    Private Sub OpenListing()
        GridListing.Rows.Clear()
        If GridRs.State = 1 Then GridRs.Close()
        GridRs.Open("select distinct comid, cayr, effectivityStartDate, EffectivityEndDate  from calendar Order by ComID, cayr", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If GridRs.RecordCount > 0 Then
            For i As Integer = 1 To GridRs.RecordCount


                Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
                row.Cells(colCompany.Index).Value = GridRs.Fields("comid").Value
                row.Cells(colYear.Index).Value = GridRs.Fields("cayr").Value
                'row.Cells(colMonth.Index).Value = GridRs.Fields("capn").Value

                row.Cells(colStartDate.Index).Value = GridRs.Fields("effectivityStartDate").Value
                row.Cells(colEndDate.Index).Value = GridRs.Fields("EffectivityEndDate").Value
                GridRs.MoveNext()
            Next
        End If
    End Sub

    Private Sub SetupButtons(ByVal hasOperation As Boolean)
        btnAdd.Enabled = Not hasOperation
        btnEdit.Enabled = Not hasOperation
        btnDelete.Enabled = Not hasOperation
        btnSave.Enabled = hasOperation
    End Sub


    Private Function CheckRecordExists(ByVal Comid As String, ByVal Year As String)
        Dim rs As New ADODB.Recordset
        rs.Open("select * from calendar where comid = '" & Comid & "' and cayr = '" & Year & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function ValidFields() As Boolean
        If cmbcompany.Text = "" Then
            Return False
        ElseIf cmbyear.Text = "" Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Function SaveRecord() As Boolean
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'ADD', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt1.Text & "', @CASTD = '" & dt1.Value & "' , @CAEDT = '" & de1.Value & "', @MonthDescription = '" & cmb1.Text & "' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "'  ")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'ADD', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt2.Text & "', @CASTD = '" & dt2.Value & "' , @CAEDT = '" & de2.Value & "' , @MonthDescription = '" & cmb2.Text & "' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' ")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'ADD', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt3.Text & "', @CASTD = '" & dt3.Value & "' , @CAEDT = '" & de3.Value & "' , @MonthDescription = '" & cmb3.Text & "' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' ")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'ADD', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt4.Text & "', @CASTD = '" & dt4.Value & "' , @CAEDT = '" & de4.Value & "' , @MonthDescription = '" & cmb4.Text & "' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' ")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'ADD', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt5.Text & "', @CASTD = '" & dt5.Value & "' , @CAEDT = '" & de5.Value & "' , @MonthDescription = '" & cmb5.Text & "' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' ")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'ADD', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt6.Text & "', @CASTD = '" & dt6.Value & "' , @CAEDT = '" & de6.Value & "' , @MonthDescription = '" & cmb6.Text & "' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' ")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'ADD', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt7.Text & "', @CASTD = '" & dt7.Value & "' , @CAEDT = '" & de7.Value & "' , @MonthDescription = '" & cmb7.Text & "' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' ")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'ADD', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt8.Text & "', @CASTD = '" & dt8.Value & "' , @CAEDT = '" & de8.Value & "' , @MonthDescription = '" & cmb8.Text & "' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' ")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'ADD', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt9.Text & "', @CASTD = '" & dt9.Value & "' , @CAEDT = '" & de9.Value & "' , @MonthDescription = '" & cmb9.Text & "' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' ")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'ADD', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt10.Text & "', @CASTD = '" & dt10.Value & "' , @CAEDT = '" & de10.Value & "' , @MonthDescription = '" & cmb10.Text & "' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' ")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'ADD', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt11.Text & "', @CASTD = '" & dt11.Value & "' , @CAEDT = '" & de11.Value & "' , @MonthDescription = '" & cmb11.Text & "' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' ")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'ADD', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt12.Text & "', @CASTD = '" & dt12.Value & "' , @CAEDT = '" & de12.Value & "' , @MonthDescription = '" & cmb12.Text & "' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' ")
        Return True
    End Function
    Private Function UpdateRecord() As Boolean
        'SPMSConn.Execute("EXEC USPCALENDAR @Action = 'UPDATE', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & "', @CASTD = '" & dtStart.Value & "' , @CAEDT = '" & dtEnd.Value & "'")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'UPDATE', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt1.Text & "', @CASTD = '" & dt1.Value & "' , @CAEDT = '" & de1.Value & "' , @MonthDescription = '" & cmb1.Text & "'  , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "'")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'UPDATE', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt2.Text & "', @CASTD = '" & dt2.Value & "' , @CAEDT = '" & de2.Value & "' , @MonthDescription = '" & cmb2.Text & "' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' ")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'UPDATE', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt3.Text & "', @CASTD = '" & dt3.Value & "' , @CAEDT = '" & de3.Value & "' , @MonthDescription = '" & cmb3.Text & "' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' ")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'UPDATE', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt4.Text & "', @CASTD = '" & dt4.Value & "' , @CAEDT = '" & de4.Value & "' , @MonthDescription = '" & cmb4.Text & "' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' ")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'UPDATE', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt5.Text & "', @CASTD = '" & dt5.Value & "' , @CAEDT = '" & de5.Value & "' , @MonthDescription = '" & cmb5.Text & "' , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "' ")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'UPDATE', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt6.Text & "', @CASTD = '" & dt6.Value & "' , @CAEDT = '" & de6.Value & "' , @MonthDescription = '" & cmb6.Text & "'  , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "'")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'UPDATE', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt7.Text & "', @CASTD = '" & dt7.Value & "' , @CAEDT = '" & de7.Value & "' , @MonthDescription = '" & cmb7.Text & "'  , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "'")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'UPDATE', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt8.Text & "', @CASTD = '" & dt8.Value & "' , @CAEDT = '" & de8.Value & "' , @MonthDescription = '" & cmb8.Text & "'  , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "'")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'UPDATE', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt9.Text & "', @CASTD = '" & dt9.Value & "' , @CAEDT = '" & de9.Value & "' , @MonthDescription = '" & cmb9.Text & "'  , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "'")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'UPDATE', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt10.Text & "', @CASTD = '" & dt10.Value & "' , @CAEDT = '" & de10.Value & "' , @MonthDescription = '" & cmb10.Text & "'  , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "'")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'UPDATE', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt11.Text & "', @CASTD = '" & dt11.Value & "' , @CAEDT = '" & de11.Value & "' , @MonthDescription = '" & cmb11.Text & "'  , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "'")
        SPMSConn.Execute("EXEC USPCALENDAR @Action = 'UPDATE', @COMID = '" & cmbcompany.Text & "', @CAYR = '" & cmbyear.Text & "', @CAPN = '" & txt12.Text & "', @CASTD = '" & dt12.Value & "' , @CAEDT = '" & de12.Value & "' , @MonthDescription = '" & cmb12.Text & "'  , @EffectivityStartDate = '" & dtStart.Value & "', @EffectivityEndDate = '" & dtEnd.Value & "'")
    End Function
    Private Sub ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dt1.ValueChanged, dt2.ValueChanged, dt3.ValueChanged, dt4.ValueChanged, dt5.ValueChanged, dt6.ValueChanged, dt7.ValueChanged, dt8.ValueChanged, dt9.ValueChanged, dt10.ValueChanged, dt11.ValueChanged, dt12.ValueChanged
        If sender Is dt1 Then
            de1.Value = LastDayOfMonth(dt1.Value, DayOfWeek.Friday)
            cmb1.Text = MonthName(Month(dt1.Value))
        ElseIf sender Is dt2 Then
            de2.Value = LastDayOfMonth(dt2.Value, DayOfWeek.Friday)
            cmb2.Text = MonthName(Month(dt2.Value))
        ElseIf sender Is dt3 Then
            de3.Value = LastDayOfMonth(dt3.Value, DayOfWeek.Friday)
            cmb3.Text = MonthName(Month(dt3.Value))
        ElseIf sender Is dt4 Then
            de4.Value = LastDayOfMonth(dt4.Value, DayOfWeek.Friday)
            cmb4.Text = MonthName(Month(dt4.Value))
        ElseIf sender Is dt5 Then
            de5.Value = LastDayOfMonth(dt5.Value, DayOfWeek.Friday)
            cmb5.Text = MonthName(Month(dt5.Value))
        ElseIf sender Is dt6 Then
            de6.Value = LastDayOfMonth(dt6.Value, DayOfWeek.Friday)
            cmb6.Text = MonthName(Month(dt6.Value))
        ElseIf sender Is dt7 Then
            de7.Value = LastDayOfMonth(dt7.Value, DayOfWeek.Friday)
            cmb7.Text = MonthName(Month(dt7.Value))
        ElseIf sender Is dt8 Then
            de8.Value = LastDayOfMonth(dt8.Value, DayOfWeek.Friday)
            cmb8.Text = MonthName(Month(dt8.Value))
        ElseIf sender Is dt9 Then
            de9.Value = LastDayOfMonth(dt9.Value, DayOfWeek.Friday)
            cmb9.Text = MonthName(Month(dt9.Value))
        ElseIf sender Is dt10 Then
            de10.Value = LastDayOfMonth(dt10.Value, DayOfWeek.Friday)
            cmb10.Text = MonthName(Month(dt10.Value))
        ElseIf sender Is dt11 Then
            de11.Value = LastDayOfMonth(dt11.Value, DayOfWeek.Friday)
            cmb11.Text = MonthName(Month(dt11.Value))
        ElseIf sender Is dt12 Then
            de12.Value = LastDayOfMonth(dt12.Value, DayOfWeek.Friday)
            cmb12.Text = MonthName(Month(dt12.Value))
        End If
    End Sub
    Public Function LastDayOfMonth(ByRef dt As Date, ByVal wd As DayOfWeek) As Date
        Return New Date(dt.Year, dt.Month, Date.DaysInMonth(dt.Year, dt.Month))
    End Function
    Private Sub ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click, btnEdit.Click, btnSave.Click, btnClose.Click
        If sender Is btnAdd Then
            Operation = "Add"
            SetupButtons(True)
            ClearForm()

        ElseIf sender Is btnEdit Then
            Operation = "Edit"
            SetupButtons(True)

        ElseIf sender Is btnSave Then
            If Operation = "Add" Then
                If ValidFields() <> True Then
                    InvalidValues()
                ElseIf CheckRecordExists(cmbcompany.Text, cmbyear.Text) = True Then
                    RecordExists()
                Else
                    SaveRecord()
                    SaveSuccess()
                    SetupButtons(False)
                    Operation = ""
                    OpenListing()
                End If
            ElseIf Operation = "Edit" Then
                If ValidFields() <> True Then
                    InvalidValues()
                ElseIf CheckRecordExists(cmbcompany.Text, cmbyear.Text) = False Then
                    RecordInexist()
                Else
                    UpdateRecord()
                    SaveSuccess()
                    SetupButtons(False)
                    Operation = ""
                    OpenListing()
                End If
            End If
        ElseIf sender Is btnClose Then
            On Error Resume Next
            Dim m_TabPage As TabPage = Me.Parent
            CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
            Me.Dispose()
        End If

    End Sub

    Private Sub AdministrationCalendar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(GridListing)
        ClearForm()
        PopulateComboBox()
        Operation = "Add"
        SetupButtons(True)
        OpenListing()
    End Sub

    Private Sub GridListing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellContentClick

    End Sub

    Private Sub GridListing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListing.CellDoubleClick
        Dim rs As New ADODB.Recordset
        Dim row As DataGridViewRow = GridListing.Rows(e.RowIndex)
        rs.Open("select * from calendar where comid = '" & row.Cells(colCompany.Index).Value & "' and cayr = '" & row.Cells(colYear.Index).Value & "' order by CAPN", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        PopulateComboBox()
        If rs.RecordCount > 0 Then
            cmbyear.Text = rs.Fields("cayr").Value
            dt1.Value = rs.Fields("CASDT").Value
            cmb1.Text = rs.Fields("MonthDescription").Value
            rs.MoveNext()
            dt2.Value = rs.Fields("CASDT").Value
            cmb2.Text = rs.Fields("MonthDescription").Value
            rs.MoveNext()
            dt3.Value = rs.Fields("CASDT").Value
            cmb3.Text = rs.Fields("MonthDescription").Value
            rs.MoveNext()
            dt4.Value = rs.Fields("CASDT").Value
            cmb4.Text = rs.Fields("MonthDescription").Value
            rs.MoveNext()
            dt5.Value = rs.Fields("CASDT").Value
            cmb5.Text = rs.Fields("MonthDescription").Value
            rs.MoveNext()
            dt6.Value = rs.Fields("CASDT").Value
            cmb6.Text = rs.Fields("MonthDescription").Value
            rs.MoveNext()
            dt7.Value = rs.Fields("CASDT").Value
            cmb7.Text = rs.Fields("MonthDescription").Value
            rs.MoveNext()
            dt8.Value = rs.Fields("CASDT").Value
            cmb8.Text = rs.Fields("MonthDescription").Value
            rs.MoveNext()
            dt9.Value = rs.Fields("CASDT").Value
            cmb9.Text = rs.Fields("MonthDescription").Value
            rs.MoveNext()
            dt10.Value = rs.Fields("CASDT").Value
            cmb10.Text = rs.Fields("MonthDescription").Value
            rs.MoveNext()
            dt11.Value = rs.Fields("CASDT").Value
            cmb11.Text = rs.Fields("MonthDescription").Value
            rs.MoveNext()
            dt12.Value = rs.Fields("CASDT").Value
            cmb12.Text = rs.Fields("MonthDescription").Value

            dtStart.Value = rs.Fields("EffectivityStartDate").Value
            dtEnd.Value = rs.Fields("EffectivityEndDate").Value

            cmbcompany.Text = rs.Fields("COMID").Value
            cmbyear.Text = rs.Fields("cayr").Value

            Operation = ""
            SetupButtons(False)
            MainTab.SelectTab(0)

        End If
    End Sub
    Private Sub Filter()
        Dim rs As New ADODB.Recordset
        Dim field As String = ""
        If cmbfilter.Text = "" Then Exit Sub

        If cmbfilter.Text = "Company" Then
            field = "COMID"
        ElseIf cmbfilter.Text = "Year" Then
            field = "cayr"
        End If

        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("select  distinct comid, cayr, EffectivityStartDate, EffectivityEndDate from calendar where " & field & " like  '%" & txtFilter.Text & "%'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic)

        GridListing.Rows.Clear()
        For i As Integer = 1 To rs.RecordCount
            Dim row As DataGridViewRow = GridListing.Rows(GridListing.Rows.Add)
            row.Cells(colCompany.Index).Value = rs.Fields("comid").Value
            row.Cells(colYear.Index).Value = rs.Fields("cayr").Value
            'row.Cells(colStartDate.Index).Value = rs.Fields("EffectivityStartDate").Value
            'row.Cells(colEndDate.Index).Value = rs.Fields("EffectivityEndDate").Value
            rs.MoveNext()
        Next
    End Sub
    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Filter()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then
            Filter()
        End If
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged

    End Sub

    Private Sub cmbcompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcompany.SelectedIndexChanged

    End Sub

End Class