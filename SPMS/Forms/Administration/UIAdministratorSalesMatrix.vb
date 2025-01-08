Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls.UI
Imports Telerik.WinControls

Public Class UIAdministratorSalesMatrix
    Private Operation As String = ""
    Private table As New DataTable
    Private m_IsTerritoryCode As Integer = -1
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private m_IsNewMode As Boolean = True
    Private _ConfigtypeCode As String = "Y2019"
    Dim dt As SqlDataReader
    Private _SalesMatrix As New Sales_Matrix
    Private _ItemCoverageName As String = String.Empty

    Private _TerritoryName As String = String.Empty

    Private _MedRepID As String = String.Empty

    Private _MedRepDescription As String = String.Empty

    Private _SaleMatrixID As String = String.Empty



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.GrdViewSalesMatrix.EnableHotTracking = True
        Me.GrdViewSalesMatrix.ShowFilteringRow = False
        Me.GrdViewSalesMatrix.EnableFiltering = True
        Me.GrdViewSalesMatrix.EnableCustomFiltering = True
    End Sub
    Private Sub ClearForm()
        m_Err.Clear()
        cmbcoverage.Text = ""
        cmbregion.Text = ""
        cmbdistrict.Text = ""
        cmbDivision.Text = ""
        txtDistrict.Text = ""
        txtDivision.Text = ""
        txtRegion.Text = ""
        cmbCoverageName.Text = ""
        cmdRep.Text = ""
        cmdRepDescription.Text = ""
        cmbConfigtype.Text = ""
        txtConfigtypename.Text = ""
        dtEffectivityEndDate.Text = DateTime.Now
        dtEffectivityStartDate.Text = DateTime.Now
    End Sub

    Private Sub SetupOperation(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation
    End Sub


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        m_IsNewMode = True
        SetupOperation(True)
        ClearForm()
    End Sub

    Private Sub UIAdministratorSalesMatrix_Load(sender As Object, e As EventArgs) Handles Me.Load
        ClearForm()
        SetupOperation(False)
        OpenListing()
        PopulateComboBox()
        m_Err.Clear()
        dtEffectivityStartDate.Text = DateTime.Now
        dtEffectivityEndDate.Text = DateTime.Now
    End Sub
    Private Sub PopulateComboBox()
        Dim rs As New ADODB.Recordset
        cmbDivision.Items.Clear()
        cmbregion.Items.Clear()
        cmbdistrict.Items.Clear()
        cmdRep.Items.Clear()
        cmdRepDescription.Items.Clear()
        cmbcoverage.Items.Clear()
        cmbCoverageName.Items.Clear()
        cmbConfigtype.Items.Clear()

        cmbDivision.Text = ""
        cmbregion.Text = ""
        cmbdistrict.Text = ""
        cmdRep.Text = ""
        cmdRepDescription.Text = ""
        cmbcoverage.Text = ""
        cmbCoverageName.Text = ""
        txtConfigtypename.Text = ""
        'for the region
        rs.Open("SELECT * FROM STREGION WHERE DLTFLG = 0  and isactive = 1 ORDER BY STREGCD", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbregion.Items.Add(rs.Fields("stregcd").Value)
                rs.MoveNext()
            Next
        End If

        ''populate the Team  
        'rs.Open("select * from stteam where dltflg = 0 order by stteamcd, stteamname", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        'If rs.RecordCount > 0 Then
        '    For i As Integer = 1 To rs.RecordCount
        '        cmbTeam.Items.Add(rs.Fields("stteamcd").Value)
        '        rs.MoveNext()
        '    Next
        'End If

        'for the itemdivision
        rs = New ADODB.Recordset
        rs.Open("select * from itemdivision where dltflg = 0 and isactive = 1  order by itmdivcd", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbDivision.Items.Add(rs.Fields("itmdivcd").Value)
                rs.MoveNext()
            Next
        End If
        rs = New ADODB.Recordset
        rs.Open("select * from stareacoverage where dltflg = 0 and isactive = 1 order by stacovcd", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbcoverage.Items.Add(rs.Fields("stacovcd").Value)
                cmbCoverageName.Items.Add(rs.Fields("Stacovname").Value)

                rs.MoveNext()
            Next
        End If

        'for the sales agent
        rs = New ADODB.Recordset
        rs.Open("select * from MedicalRep where dltflg = 0 and isactive = 1 order by slsmncd", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmdRep.Items.Add(rs.Fields("slsmncd").Value)
                cmdRepDescription.Items.Add(rs.Fields("slsmnname").Value)
                rs.MoveNext()
            Next
        End If
        table = GetRecords("Select * from ConfigurationType")
        For i As Integer = 0 To table.Rows.Count - 1
            cmbConfigtype.Items.Add(table.Rows(i)("ConfigtypeCode"))
        Next

    End Sub
    Private Sub SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcoverage.SelectedIndexChanged, cmbDivision.SelectedIndexChanged, cmdRep.SelectedIndexChanged, cmdRepDescription.SelectedIndexChanged, _
       cmbregion.SelectedIndexChanged, cmbdistrict.SelectedIndexChanged, cmbConfigtype.SelectedIndexChanged
        If sender Is cmbcoverage Then
            Dim rs As New ADODB.Recordset
            m_IsTerritoryCode = 1
            rs.Open("select * from stareacoverage where dltflg = 0 and stacovcd = '" & cmbcoverage.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                _ItemCoverageName = rs.Fields("stacovname").Value
                cmbCoverageName.Text = rs.Fields("stacovname").Value
                _TerritoryName = cmbcoverage.Text
            End If

        ElseIf sender Is cmbregion Then
            cmbdistrict.Items.Clear()
            cmbdistrict.Text = ""
            txtDistrict.Text = ""
            Dim rs As New ADODB.Recordset
            rs.Open("SELECT * FROM STREGION WHERE DLTFLG = 0 AND STREGCD = '" & cmbregion.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                txtRegion.Text = rs.Fields("stregname").Value

            End If
            rs = New ADODB.Recordset
            rs.Open("SELECT * FROM STDISTRICTCreation WHERE DLTFLG = 0 AND  IsActive = 1  AND DIVCD  = '" & cmbregion.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                For i As Integer = 1 To rs.RecordCount
                    cmbdistrict.Items.Add(rs.Fields("DISTCD").Value)
                    rs.MoveNext()
                Next
            End If

        ElseIf sender Is cmbdistrict Then
            Dim rs As New ADODB.Recordset
            rs.Open("SELECT * FROM STDISTRICTCreation WHERE DLTFLG = 0  AND DivCd= '" & cmbregion.Text & "' AND DistCd = '" & cmbdistrict.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                txtDistrict.Text = rs.Fields("DistName").Value
            End If

            rs = New ADODB.Recordset
            rs.Open("SELECT * FROM STTEAM WHERE DLTFLG = 0 and STREGCD = '" & cmbregion.Text & "' AND STDISTRCTCD = '" & cmbdistrict.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                For i As Integer = 1 To rs.RecordCount
                    '' cmbTeam.Items.Add(rs.Fields("StTeamCd").Value)
                    rs.MoveNext()
                Next
            End If
        ElseIf sender Is cmbDivision Then
            Dim rs As New ADODB.Recordset
            rs.Open("select * from ItemDivision where dltflg = 0  and itmdivcd = '" & cmbDivision.Text & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rs.RecordCount > 0 Then
                txtDivision.Text = rs.Fields("ItmDivName").Value
            End If

            ''Dim rsItemGroup As New ADODB.Recordset
            ''rsItemGroup = New ADODB.Recordset
            ' '' rsItemGroup.Open("select distinct(Itemgrpcd) from item where itemdivcd = '" & rs.Fields("itmdivcd").Value & "' and itemdel = '" & "0" & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            '' ''  cmbItemGroup.Items.Clear()
            ' ''If rsItemGroup.RecordCount > 0 Then
            ' ''    For j As Integer = 1 To rsItemGroup.RecordCount
            ' ''        ''   cmbItemGroup.Items.Add(rsItemGroup.Fields("ITEMGRPCD").Value)
            ' ''        rsItemGroup.MoveNext()
            ' ''    Next
            ''End If


            ''ElseIf sender Is cmbItemGroup Then

            ''    Dim rs As New ADODB.Recordset
            ''    rs.Open("select * from ItemGroup where itemgroupcd = '" & cmbItemGroup.Text & "' and itemgroupdel = '" & "0" & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            ''    If rs.RecordCount > 0 Then
            ''        txtItemGroup.Text = rs.Fields("ITEMGROUPName").Value
            ''    End If

        ElseIf sender Is cmdRep Then
            Dim rs As New ADODB.Recordset
            rs.Open("select * from medicalRep where dltflg = 0 and slsmncd = '" & cmdRep.Text & "'", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                _MedRepID = rs.Fields("slsmnName").Value
                cmdRepDescription.Text = rs.Fields("slsmnname").Value
            End If

        ElseIf sender Is cmdRepDescription Then
            'Dim rs As New ADODB.Recordset
            'rs = MedRep("slsmnName = '" & cmbrepDesc.Text & "' ")
            'If rs.RecordCount > 0 Then
            '    cmbRep.Text = rs.Fields("slsmncd").Value
            'End If
            'ElseIf sender Is cmbTeam Then
            '    Dim rs As New ADODB.Recordset
            '    rs.Open("select * from stteam where stteamcd = '" & cmbTeam.Text & "' and dltflg = 0 ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            '    If rs.RecordCount > 0 Then
            '        txtTeamDescription.Text = rs.Fields("stteamName").Value

            '        'txtDistrict.Text = rs.Fields("StDistrctname").Value
            '        'txtRegion.Text = rs.Fields("STRegname").Value
            '    End If
        ElseIf sender Is cmbConfigtype Then
            table = GetRecords("Select ConfigtypeName from Configurationtype where ConfigtypeCode = '" & cmbConfigtype.Text & "'")
            For i As Integer = 0 To table.Rows.Count - 1
                txtConfigtypename.Text = table.Rows(i)("ConfigtypeName")
            Next
        End If
        m_IsTerritoryCode = -1
    End Sub
    Private Sub OpenListing()
        Connect()
        Try
            Dim cmd As SqlCommand = New SqlCommand("uspSalesMatrix_list", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Action", "Table")
            cmd.Parameters.AddWithValue("@ConfigtypeCode", _ConfigtypeCode)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Clear()

            da.Fill(dt)

            GrdViewSalesMatrix.DataSource = dt
            Disconnect()

            GrdViewSalesMatrix.Columns(0).Width = 50
            GrdViewSalesMatrix.Columns(1).Width = 150
            GrdViewSalesMatrix.Columns(2).Width = 300
            GrdViewSalesMatrix.Columns(3).Width = 100
            GrdViewSalesMatrix.Columns(4).Width = 110
            GrdViewSalesMatrix.Columns(5).Width = 100
            GrdViewSalesMatrix.Columns(6).Width = 200
            GrdViewSalesMatrix.Columns(7).Width = 100
            GrdViewSalesMatrix.Columns(8).FormatString = "{0:MM-dd-yyyy}"
            GrdViewSalesMatrix.Columns(8).Width = 110
            GrdViewSalesMatrix.Columns(9).Width = 110
            GrdViewSalesMatrix.Columns(9).FormatString = "{0:MM-dd-yyyy}"
            GrdViewSalesMatrix.Columns(10).Width = 90

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GrdViewSalesMatrix_CellClick(sender As Object, e As GridViewCellEventArgs) Handles GrdViewSalesMatrix.CellClick
        If e.RowIndex = -1 Then Exit Sub
        Dim row As GridViewRowInfo = GrdViewSalesMatrix.Rows(e.RowIndex)
        Connect()
        Dim cmd As SqlCommand = New SqlCommand("uspSalesMatrix_Selected", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Action", "Table")
        cmd.Parameters.AddWithValue("@ID", row.Cells(0).Value)

        Try
            DataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dt = DataReader
            Do While DataReader.Read = True
                cmdRep.Text = dt(0)
                cmdRepDescription.Text = dt(1)
                cmbregion.Text = dt(2)
                txtRegion.Text = dt(3)
                cmbdistrict.Text = dt(4)
                txtDistrict.Text = dt(5)
                cmbDivision.Text = dt(6)
                txtDivision.Text = dt(7)
                cmbcoverage.Text = dt(8)
                cmbCoverageName.Text = dt(9)
                cmbConfigtype.Text = dt(10)
                txtConfigtypename.Text = dt(11)
                dtEffectivityStartDate.Text = dt(12)
                dtEffectivityEndDate.Text = dt(13)
                If dt(14) = True Then
                    Check_IsActive.Checked = True
                Else
                    Check_IsActive.Checked = False
                End If
                _SaleMatrixID = row.Cells(0).Value
            Loop
        Catch ex As Exception
            RadMessageBox.SetThemeName("TelerikMetroBlue")
            Dim ds As DialogResult = RadMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub GrdViewSalesMatrix_Click(sender As Object, e As EventArgs) Handles GrdViewSalesMatrix.Click

    End Sub

    Private Sub GrdViewSalesMatrix_CustomFiltering(sender As Object, e As Telerik.WinControls.UI.GridViewCustomFilteringEventArgs) Handles GrdViewSalesMatrix.CustomFiltering
        If String.IsNullOrEmpty(Me.filterTextBox.Text) Then
            GrdViewSalesMatrix.BeginUpdate()
            e.Visible = True
            For i As Integer = 0 To Me.GrdViewSalesMatrix.ColumnCount - 1
                e.Row.Cells(i).Style.Reset()
            Next i
            GrdViewSalesMatrix.EndUpdate(False)
            Return
        End If
        GrdViewSalesMatrix.BeginUpdate()
        e.Visible = False
        For i As Integer = 0 To Me.GrdViewSalesMatrix.ColumnCount - 1
            Dim text As String = e.Row.Cells(i).Value.ToString()
            If text.IndexOf(Me.filterTextBox.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0 Then
                e.Visible = True
                e.Row.Cells(i).Style.CustomizeFill = True
                e.Row.Cells(i).Style.DrawFill = True
                e.Row.Cells(i).Style.BackColor = Color.FromArgb(201, 252, 254)
            Else
                e.Row.Cells(i).Style.Reset()
            End If
        Next
        GrdViewSalesMatrix.EndUpdate(False)
    End Sub

    Private Sub filterTextBox_TextChanged(sender As Object, e As EventArgs) Handles filterTextBox.TextChanged
        Me.GrdViewSalesMatrix.MasterTemplate.Refresh()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        filterTextBox.Text = String.Empty
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ValidatingDataEntry() Then
            If SaveData2() Then
                RadMessageBox.SetThemeName("TelerikMetroBlue")
                Dim ds As DialogResult = RadMessageBox.Show(Me, "Record Saved Successfully.", "Save", MessageBoxButtons.OK, RadMessageIcon.Info)
                m_IsNewMode = False
                OpenListing()
                SetupOperation(False)
                Me.GrdViewSalesMatrix.MasterTemplate.Refresh()
                ClearForm()
            End If
        End If
    End Sub
    Private Function SaveData2() As Boolean
        m_Err.Clear()
        m_HasError = False

        If m_IsNewMode = True Then
            _SalesMatrix.STREGCD = cmbregion.Text
            _SalesMatrix.STDISTRCTCD = cmbdistrict.Text
            _SalesMatrix.STITMDIVCD = cmbDivision.Text
            _SalesMatrix.STTERRCD = cmbcoverage.Text
            _SalesMatrix.STTEAMCD = "999"
            _SalesMatrix.STACOVNAME = cmbCoverageName.Text
            _SalesMatrix.STSLSMNCD = cmdRep.Text
            _SalesMatrix.STSLSMNNAME = cmdRepDescription.Text
            _SalesMatrix.CRTDATE = Now
            _SalesMatrix.CRTU = ""
            _SalesMatrix.UPDD = Now
            _SalesMatrix.UPDU = ""
            _SalesMatrix.EffectivityStartDate = dtEffectivityStartDate.Text
            _SalesMatrix.EffectivityEndDate = dtEffectivityEndDate.Text
            _SalesMatrix.ITEMGRPCD = ""
            _SalesMatrix.Configtypecode = cmbConfigtype.Text
            _SalesMatrix.Save()
        Else
            _SalesMatrix.STREGCD = cmbregion.Text
            _SalesMatrix.STDISTRCTCD = cmbdistrict.Text
            _SalesMatrix.STITMDIVCD = cmbDivision.Text
            _SalesMatrix.STTERRCD = cmbcoverage.Text
            _SalesMatrix.STTEAMCD = "999"
            _SalesMatrix.STACOVNAME = cmbCoverageName.Text
            _SalesMatrix.STSLSMNCD = cmdRep.Text
            _SalesMatrix.STSLSMNNAME = cmdRepDescription.Text
            _SalesMatrix.CRTDATE = Now
            _SalesMatrix.CRTU = ""
            _SalesMatrix.UPDD = Now
            _SalesMatrix.UPDU = ""
            _SalesMatrix.EffectivityStartDate = dtEffectivityStartDate.Text
            _SalesMatrix.EffectivityEndDate = dtEffectivityEndDate.Text
            _SalesMatrix.ITEMGRPCD = ""
            _SalesMatrix.Configtypecode = cmbConfigtype.Text
            _SalesMatrix.SalesMatrixID = _SaleMatrixID
            _SalesMatrix.Edit()
        End If
        Return Not m_HasError
    End Function
    Private Function ValidatingDataEntry() As Boolean
        m_Err.Clear()
        m_HasError = False

        If String.IsNullOrEmpty(cmdRep.Text) Then
            m_Err.SetError(cmdRep, "Medical Rep Employee Code is Requeired!")
            m_HasError = True
        ElseIf String.IsNullOrEmpty(cmdRepDescription.Text) Then
            m_Err.SetError(cmdRepDescription, "Medical Rep Employee Name is Requeired!")
            m_HasError = True
        ElseIf String.IsNullOrEmpty(cmbdistrict.Text) Then
            m_Err.SetError(cmbdistrict, "Medical District Code is Required!")
            m_HasError = True
        ElseIf String.IsNullOrEmpty(txtDistrict.Text) Then
            m_Err.SetError(txtDistrict, "Medical District Name is Required!")
            m_HasError = True

        ElseIf String.IsNullOrEmpty(cmbDivision.Text) Then
            m_Err.SetError(txtDivision, "Medical Division Code is Required!")
            m_HasError = True
        ElseIf String.IsNullOrEmpty(txtDivision.Text) Then
            m_Err.SetError(txtDivision, "Medical Division Name is Required!")
            m_HasError = True
        ElseIf String.IsNullOrEmpty(cmbcoverage.Text) Then
            m_Err.SetError(cmbcoverage, "Medical Area Coverage Code is Required!")
            m_HasError = True
        ElseIf String.IsNullOrEmpty(cmbCoverageName.Text) Then
            m_Err.SetError(cmbCoverageName, "Medical Area Coverage Name is Required!")
            m_HasError = True
        ElseIf String.IsNullOrEmpty(cmbConfigtype.Text) Then
            m_Err.SetError(cmbConfigtype, "Config Type Code is Required!")
            m_HasError = True
        ElseIf String.IsNullOrEmpty(txtConfigtypename.Text) Then
            m_Err.SetError(txtConfigtypename, "Configuration Name is Required!")
            m_HasError = True
        End If
       
        If m_IsNewMode = True Then
            If CheckAlready(cmbDivision.Text, cmbdistrict.Text, cmbcoverage.Text, cmdRep.Text, cmbConfigtype.Text, dtEffectivityStartDate.Text, dtEffectivityEndDate.Text) Then
                RadMessageBox.SetThemeName("TelerikMetroBlue")
                Dim ds As DialogResult = RadMessageBox.Show(Me, "MR Coverages is Already Exist", "Error Save", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                m_HasError = True
            End If
        End If
        Return Not m_HasError
    End Function
    Private Function CheckAlready(ByVal DivisionCode As String, ByVal DistrictCode As String, ByVal TerritoryCode As String, ByVal EmployeeCode As String, ByVal ConfigtypeCode As String, ByVal EffectivityStart As Date, ByVal EffectivityEnd As Date) As Boolean
        Connect()
        Dim cmd As SqlCommand = New SqlCommand("uspSalesMatrix", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Action", "Checkinfo")
        cmd.Parameters.AddWithValue("@STITMDIVCD", DivisionCode)
        cmd.Parameters.AddWithValue("@STDISTRCTCD", DistrictCode)
        cmd.Parameters.AddWithValue("@STTERRCD", TerritoryCode)
        cmd.Parameters.AddWithValue("@STSLSMNCD", EmployeeCode)
        cmd.Parameters.AddWithValue("@ConfigTypeCode", ConfigtypeCode)
        cmd.Parameters.AddWithValue("@EFFECTIVITYSTARTDATE", EffectivityStart)
        cmd.Parameters.AddWithValue("@EFFECTIVITYENDDATE", EffectivityEnd)
        Try
            DataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dt = DataReader
            If DataReader.Read = True Then
                Return True
                Exit Function
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        m_IsNewMode = False
        SetupOperation(True)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If _SaleMatrixID <> "" Then
            RadMessageBox.SetThemeName("TelerikMetroBlue")
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Not Selected MR Configuration Territory Details", "Delete", MessageBoxButtons.YesNo, RadMessageIcon.Question)
            If ds = Windows.Forms.DialogResult.Yes Then
                _SalesMatrix.SalesMatrixID = _SaleMatrixID
                _SalesMatrix.Delete()
                m_IsNewMode = False
                OpenListing()
                SetupOperation(False)
                Me.GrdViewSalesMatrix.MasterTemplate.Refresh()
                ClearForm()
            End If
        Else
            RadMessageBox.SetThemeName("TelerikMetroBlue")
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Not Selected MR Configuration Territory Details", "Erro Delete", MessageBoxButtons.OK, RadMessageIcon.Error)
        End If
    End Sub
End Class
