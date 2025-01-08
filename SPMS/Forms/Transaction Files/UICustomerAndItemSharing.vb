Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.Windows
Imports Telerik.WinControls
Imports Telerik.Windows.Controls
Imports Telerik.WinControls.UI
Imports System.Text
Imports DataLayer
Imports System.Drawing.Drawing2D
Imports SPMSOPCI.UserLogin
Public Class UICustomerAndItemSharing
    Dim Table As New DataTable
    Dim TablePMR As New DataTable
    Private m_Configtype As New Configuration
    Private m_CustomerItemSharing As New CustomerItemSharing
    Dim m_HasError As Boolean = False
    Private m_Err As New ErrorProvider
    Private m_DistributorPrimary As String = "OPCI"
    Private m_DistrictGrouplist As String = ""
    Private m_TRSCODE As String = String.Empty
    Private Function AutoTextAdd()
        Dim myDate As DateTime = DateTime.Now
        Dim myYear As Int32 = myDate.Year
        Dim format As String = "PRH"
        Dim myMonth As Int32 = myDate.Month

        Try
            m_TRSCODE = myMonth & myYear & Strings.Right(myDate.ToString(format), 15)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return True
    End Function
    Private Sub LoadYear()
        Table = GetRecords(Configuration.GetYearbyConfig)
        For i As Integer = 0 To Table.Rows.Count - 1
            DropYear.Items.Add(Table.Rows(i)("CAYR"))
        Next
    End Sub
    Private Sub DropYear_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles DropYear.SelectedIndexChanged
        If DropYear.SelectedIndex = -1 Then Exit Sub
        LoadMonth(m_DistributorPrimary, DropYear.Text)
    End Sub
    Private Sub LoadMonth(ByVal DistributorCode As String, ByVal Year As String)
        DropMonth.Items.Clear()
        Table = GetRecords(Configuration.GetMonthConfigtype(DistributorCode, Year))
        For i As Integer = 0 To Table.Rows.Count - 1
            DropMonth.Items.Add(Table.Rows(i)("CAPN"))
        Next
    End Sub

    Private Sub UICustomerAndItemSharing_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.GrdViewDistrict.TableElement.RowHeight = 35
        Me.GrdViewPMRORG.TableElement.RowHeight = 35
        Me.GrdViewPMRSHR.TableElement.RowHeight = 35
        LoadYear()
        EditMode(False)
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Medical Configuration")
        If Not tag Is Nothing Then
            txtConfigtypeCode.Text = tag.KeyColumn11
            txtConfigtypeName.Text = tag.KeyColumn33
        End If
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        If DropYear.Text <> "" Or DropMonth.Text <> "" Or txtConfigtypeCode.Text <> "" Then
            Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ProcessConfig.GetItemSql(DropYear.Text, DropMonth.Text, txtConfigtypeCode.Text), "Medical Items")
            If Not tag Is Nothing Then
                txtItemCode.Text = tag.KeyColumn11
                txtItemName.Text = tag.KeyColumn33
                LoadDistrictTable(DropYear.Text, DropMonth.Text, txtConfigtypeCode.Text, txtItemCode.Text)
            End If
        End If
    End Sub
    Private Sub LoadDistrictTable(ByVal Year As String, ByVal Month As String, ByVal ConfigtypeCode As String, ByVal ItemCode As String)
        Table = GetRecords(ProcessConfig.GetDistrictItemSql(Year, Month, ConfigtypeCode, ItemCode))
        GrdViewDistrict.Rows.Clear()
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewDistrict.Rows.AddNew
            rowinfo.Cells(0).Value = False
            rowinfo.Cells(1).Value = Table.Rows(i)("District Code")
            rowinfo.Cells(2).Value = Table.Rows(i)("District Name")
        Next
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If GrdViewDistrict.RowCount <> 0 Then
            LoadDistrictMultiple()
            Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ProcessConfig.GetDistrictlistSql(DropYear.Text, DropMonth.Text, txtConfigtypeCode.Text, txtItemCode.Text, m_DistrictGrouplist), "Medical Items")
            If Not tag Is Nothing Then
                txtChannelCode.Text = tag.KeyColumn33
                txtChannelName.Text = tag.KeyColumn44
            End If
        End If
    End Sub
    Private Sub LoadDistrictMultiple()
        Dim valuesList As New List(Of String)()

        ' Loop through the rows in the GridView
        For i As Integer = 0 To GrdViewDistrict.Rows.Count - 1
            ' Get the current row
            Dim District As GridViewRowInfo = GrdViewDistrict.Rows(i)

            ' Check if the checkbox column (Cells(0)) is checked
            If District.Cells(0).Value IsNot Nothing AndAlso Convert.ToBoolean(District.Cells(0).Value) = True Then
                ' Get the value from Cells(1)
                Dim value As Object = District.Cells(1).Value

                ' Ensure the value is not null before converting to string
                If value IsNot Nothing Then
                    ' Add the value to the list, wrapped in single quotes
                    valuesList.Add($"'{value.ToString()}'")
                End If
            End If
        Next

        ' Convert the list to an array and join it
        m_DistrictGrouplist = String.Join(",", valuesList.ToArray())
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ProcessConfig.GetDistrictChannelAndCustomerlistSql(DropYear.Text, DropMonth.Text, txtConfigtypeCode.Text, txtItemCode.Text, m_DistrictGrouplist, txtChannelCode.Text), "Medical Items")
        If Not tag Is Nothing Then
            txtCustomerCode.Text = tag.KeyColumn33
            txtCustomerName.Text = tag.KeyColumn44
            txtShiptoCode.Text = tag.KeyColumn55
        End If
    End Sub

    Private Sub btnAddPMRORG_Click(sender As Object, e As EventArgs) Handles btnAddPMRORG.Click
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ProcessConfig.GetDistrictChannelAndCustomerPMRORGlistSql(DropYear.Text, DropMonth.Text, txtConfigtypeCode.Text, txtItemCode.Text, m_DistrictGrouplist, txtChannelCode.Text, txtCustomerCode.Text), "Medical Items")
        If Not tag Is Nothing Then
            GrdViewPMRORG.Rows.Clear()
            Dim rowinfo As GridViewRowInfo = GrdViewPMRORG.Rows.AddNew
            rowinfo.Cells(0).Value = True
            rowinfo.Cells(1).Value = tag.KeyColumn22
            rowinfo.Cells(2).Value = tag.KeyColumn33
            rowinfo.Cells(3).Value = "1.0"
        End If
    End Sub

    Private Sub RadMenuButtonItem8_Click(sender As Object, e As EventArgs) Handles btnAccountItemSharingPMRSHR.Click
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ProcessConfig.GetDistrictChannelAndCustomerPMRSHRlistSql(DropYear.Text, DropMonth.Text, txtConfigtypeCode.Text), "Medical Items")
        If Not tag Is Nothing Then
            Dim rowinfo As GridViewRowInfo = GrdViewPMRSHR.Rows.AddNew
            rowinfo.Cells(0).Value = True
            rowinfo.Cells(1).Value = tag.KeyColumn22
            rowinfo.Cells(2).Value = tag.KeyColumn33
            rowinfo.Cells(3).Value = "0.0"
        End If
    End Sub
    Private Sub Clear()
        DropYear.Text = String.Empty
        DropMonth.Text = String.Empty
        txtConfigtypeCode.Text = String.Empty
        txtConfigtypeName.Text = String.Empty
        txtItemCode.Text = String.Empty
        txtItemName.Text = String.Empty
        GrdViewDistrict.Rows.Clear()
        txtChannelCode.Text = String.Empty
        txtChannelName.Text = String.Empty
        txtCustomerCode.Text = String.Empty
        txtCustomerName.Text = String.Empty
        txtShiptoCode.Text = String.Empty
        GrdViewPMRORG.Rows.Clear()
        GrdViewPMRSHR.Rows.Clear()
        m_TRSCODE = String.Empty
    End Sub
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtConfigtypeCode.ReadOnly = Not IsEditMode
        txtConfigtypeCode.BackColor = Color.White

        txtConfigtypeName.ReadOnly = Not IsEditMode
        txtConfigtypeName.BackColor = Color.White

        txtItemCode.ReadOnly = Not IsEditMode
        txtItemCode.BackColor = Color.White

        txtItemName.ReadOnly = Not IsEditMode
        txtItemName.BackColor = Color.White

        txtChannelCode.ReadOnly = Not IsEditMode
        txtChannelCode.BackColor = Color.White

        txtChannelName.ReadOnly = Not IsEditMode
        txtChannelName.BackColor = Color.White

        txtCustomerCode.ReadOnly = Not IsEditMode
        txtCustomerCode.BackColor = Color.White

        txtCustomerName.ReadOnly = Not IsEditMode
        txtCustomerName.BackColor = Color.White

        LinkLabel3.Enabled = IsEditMode
        LinkLabel4.Enabled = IsEditMode
        LinkLabel1.Enabled = IsEditMode
        LinkLabel2.Enabled = IsEditMode

        btnAddPMRORG.Enabled = IsEditMode
        btnRemovePMRORG.Enabled = IsEditMode
        btnAccountItemSharingPMRSHR.Enabled = IsEditMode
        btnPMRHRRemove.Enabled = IsEditMode


    End Sub
    Private Sub NewRecord()
        Clear()
        NewTransaction()
        EditMode(True)
    End Sub
    Private Sub NewTransaction()
        m_TRSCODE = "TR-" & SystemSequences.GetMedicalDoctorSequence
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnDelete.Click, btnEdit.Click, btnFinddata.Click, btnSave.Click, btnClear.Click, btnClose.Click
        If sender Is btnNew Then
            NewRecord()
        ElseIf sender Is btnDelete Then
            Delete()
        ElseIf sender Is btnEdit Then
            EditMode(True)
        ElseIf sender Is btnClear Then
            Clear()
            EditMode(False)
        ElseIf sender Is btnClose Then
            Close()
        ElseIf sender Is btnFinddata Then
            Find()
        ElseIf sender Is btnSave Then
            If ValidateData() Then
                CustomerItemSharing.GetResetRecordSql(m_TRSCODE)
                NewTransaction()
                ProcessDataFinal()
                EditMode(False)
            End If
        End If
    End Sub
    Private Sub ProcessDataFinal()
        If ShowProcessDialog() = DialogResult.Yes Then
            SaveRecord()
            m_CustomerItemSharing.DataProcessSC02()
            m_CustomerItemSharing.DataProcessSC0File()
            SaveSuccess()
        End If
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog() = DialogResult.Yes Then
            If m_CustomerItemSharing.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub
    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(CustomerItemSharing.GetCustomerItemSharingSql, "Customer Item Sharing")
        If Not tag Is Nothing Then
            Clear()
            ShowDataCustomerItemSharing(tag.KeyColumn11)
        End If
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        'If txtEmployeeCode.Text = "" Then
        '    m_Err.SetError(txtEmployeeCode, "Employee Code is Required!")
        '    m_HasError = True
        'Else
        '    If EmployeeSalesman.CheckofEmployeeSalesmanAlreadyExist(txtEmployeeCode.Text, IIf(txtEmployeeCode.Tag Is Nothing, -1, txtEmployeeCode.Tag)) Then
        '        m_Err.SetError(txtEmployeeCode, "Employee Code Already Exist")
        '        m_HasError = True
        '    End If
        'End If

        If GrdViewPMRORG.RowCount = 0 Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "PMR Orig - Shared is required please select the properly set", "", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Exit Function
            m_HasError = True
        End If

        If GrdViewPMRSHR.RowCount = 0 Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "PMR Per - Shared is required please select the properly set", "", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Exit Function
            m_HasError = True
        End If

        If txtConfigtypeCode.Text = "" Then
            m_Err.SetError(txtConfigtypeCode, "Configtype is Required!")
            m_HasError = True
        End If

        If txtChannelCode.Text = "" Then
            m_Err.SetError(txtChannelCode, "Channel is Required!")
            m_HasError = True
        End If

        If txtCustomerCode.Text = "" Then
            m_Err.SetError(txtCustomerCode, "Customer Details is Required!")
            m_HasError = True
        End If

        If txtItemCode.Text = "" Then
            m_Err.SetError(txtItemCode, "Item Details is Required!")
            m_HasError = True
        End If
        Return Not m_HasError
    End Function
    Private Sub SaveRecord()
        For a As Integer = 0 To GrdViewPMRSHR.Rows.Count - 1
            m_CustomerItemSharing = New CustomerItemSharing
            Dim rowinfo As GridViewRowInfo = GrdViewPMRSHR.Rows(a)
            If rowinfo.Cells(0).Value = True Then
                m_CustomerItemSharing.TRSCODE = m_TRSCODE
                m_CustomerItemSharing.PMRCO = rowinfo.Cells(1).Value
                m_CustomerItemSharing.PMRCOName = rowinfo.Cells(2).Value
                m_CustomerItemSharing.PERSHRCO = rowinfo.Cells(3).Value
                m_CustomerItemSharing.Year = DropYear.Text
                m_CustomerItemSharing.Month = DropMonth.Text
                m_CustomerItemSharing.ConfigtypeCode = txtConfigtypeCode.Text
                m_CustomerItemSharing.ConfigtypeName = txtConfigtypeName.Text
                m_CustomerItemSharing.ItemCode = txtItemCode.Text
                m_CustomerItemSharing.ItemName = txtItemName.Text
                m_CustomerItemSharing.ChannelCode = txtChannelCode.Text
                m_CustomerItemSharing.ChannelName = txtChannelName.Text
                m_CustomerItemSharing.CustomerCode = txtCustomerCode.Text
                m_CustomerItemSharing.CustomerName = txtCustomerName.Text
                m_CustomerItemSharing.ShiptoCode = txtShiptoCode.Text
                For m As Integer = 0 To GrdViewPMRORG.Rows.Count - 1
                    Dim row As GridViewRowInfo = GrdViewPMRORG.Rows(m)
                    If row.Cells(0).Value = True Then
                        m_CustomerItemSharing.PMRORG = row.Cells(1).Value
                        m_CustomerItemSharing.PMRORGName = row.Cells(2).Value
                        m_CustomerItemSharing.PERSHRORG = row.Cells(3).Value
                    End If
                Next
                m_CustomerItemSharing.CRTBY = UserLogin.Username
            End If
            m_CustomerItemSharing.Save()
        Next
        ShowDataCustomerItemSharing(m_CustomerItemSharing.TRSCODE)
    End Sub
    Private Sub ShowDataCustomerItemSharing(ByVal RecordCode As String)
        m_CustomerItemSharing = CustomerItemSharing.LoadByCode(RecordCode)
        m_TRSCODE = m_CustomerItemSharing.TRSCODE
        DropYear.Text = m_CustomerItemSharing.Year
        DropMonth.Text = m_CustomerItemSharing.Month
        txtConfigtypeCode.Text = m_CustomerItemSharing.ConfigtypeCode
        txtConfigtypeName.Text = m_CustomerItemSharing.ConfigtypeName
        txtChannelCode.Text = m_CustomerItemSharing.ChannelCode
        txtChannelName.Text = m_CustomerItemSharing.ChannelName
        txtCustomerCode.Text = m_CustomerItemSharing.CustomerCode
        txtCustomerName.Text = m_CustomerItemSharing.CustomerName
        txtShiptoCode.Text = m_CustomerItemSharing.ShiptoCode
        txtItemCode.Text = m_CustomerItemSharing.ItemCode
        txtItemName.Text = m_CustomerItemSharing.ItemName
        LoadPMRORG(RecordCode)
        LoadPMRSHRS(RecordCode)
    End Sub
    Private Sub LoadPMRORG(ByVal TRSCODE As String)
        Table = GetRecords(CustomerItemSharing.GetCustomerItemSharingPMRORGSql(TRSCODE))
        GrdViewPMRORG.Rows.Clear()
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewPMRORG.Rows.AddNew
            rowinfo.Cells(0).Value = True
            rowinfo.Cells(1).Value = Table.Rows(i)("PMRORG")
            rowinfo.Cells(2).Value = Table.Rows(i)("PMRORGDescrition")
            rowinfo.Cells(3).Value = Table.Rows(i)("PERSHRORG")
        Next
    End Sub
    Private Sub LoadPMRSHRS(ByVal TRSCODE As String)
        Table = GetRecords(CustomerItemSharing.GetCustomerItemSharingPMRSHSql(TRSCODE))
        GrdViewPMRSHR.Rows.Clear()
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewPMRSHR.Rows.AddNew
            rowinfo.Cells(0).Value = True
            rowinfo.Cells(1).Value = Table.Rows(i)("PMRCO")
            rowinfo.Cells(2).Value = Table.Rows(i)("PMRCODescription")
            rowinfo.Cells(3).Value = Table.Rows(i)("PERSHRCO")
        Next
    End Sub
    Private Sub GrdViewPMRSHR_CellEndEdit(sender As Object, e As GridViewCellEventArgs) Handles GrdViewPMRSHR.CellEndEdit
        ValidationMath()
    End Sub
    Private Sub ValidationMath()
        Dim Percenatages As Double = 0
        Dim PercentagesOriginal As Double = 1.0
        Dim ResultOrginal As Double = 0
        Dim ResultTotal As Double = 0

        For a As Integer = 0 To GrdViewPMRSHR.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewPMRSHR.Rows(a)
            If rowinfo.Cells(0).Value = True Then
                Percenatages = rowinfo.Cells(3).Value
                ResultOrginal += Percenatages

            End If
        Next
        For a As Integer = 0 To GrdViewPMRORG.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewPMRORG.Rows(a)
            If rowinfo.Cells(0).Value = True Then
                ResultTotal = PercentagesOriginal - ResultOrginal

                If ResultTotal > 1 Then
                    MessageBox.Show("Percentage is more than 100%")
                ElseIf ResultTotal < -1 Then
                    MessageBox.Show("Percentage is less than 100%")
                Else
                    rowinfo.Cells(3).Value = ResultTotal
                End If
                Exit Sub
            End If
        Next
    End Sub

    Private Sub btnRemovePMRORG_Click(sender As Object, e As EventArgs) Handles btnRemovePMRORG.Click
        Dim selectedRows(Me.GrdViewPMRORG.SelectedRows.Count - 1) As GridViewRowInfo
        Me.GrdViewPMRORG.SelectedRows.CopyTo(selectedRows, 0)
        Me.GrdViewPMRORG.TableElement.BeginUpdate()
        For i As Integer = 0 To selectedRows.Length - 1
            Me.GrdViewPMRORG.Rows.Remove(TryCast(selectedRows(i), GridViewDataRowInfo))
        Next i
        Me.GrdViewPMRORG.TableElement.EndUpdate()
        ValidationMath()
    End Sub

    Private Sub btnPMRHRRemove_Click(sender As Object, e As EventArgs) Handles btnPMRHRRemove.Click
        Dim selectedRows(Me.GrdViewPMRSHR.SelectedRows.Count - 1) As GridViewRowInfo
        Me.GrdViewPMRSHR.SelectedRows.CopyTo(selectedRows, 0)
        Me.GrdViewPMRSHR.TableElement.BeginUpdate()
        For i As Integer = 0 To selectedRows.Length - 1
            Me.GrdViewPMRSHR.Rows.Remove(TryCast(selectedRows(i), GridViewDataRowInfo))
        Next i
        Me.GrdViewPMRSHR.TableElement.EndUpdate()
        ValidationMath()
    End Sub

    Private Sub RadGroupBox1_Click(sender As Object, e As EventArgs) Handles RadGroupBox1.Click

    End Sub
End Class
