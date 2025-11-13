Imports System.Security.Policy
Imports System.Text.RegularExpressions
Imports DataLayer
Imports Telerik.WinControls
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI
Imports VisualStyleBuilder.Design

Public Class UISalesAccountSpecialistMapping
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private Table As DataTable
    Private _SalesAccountSpecialist As New SalesAccountSpecialist
    Private _DistrictAssignment As New DistrictAssignment
    Private _SalesAccountSpecialistTagging As New SalesAccountSpecialistTagging
    Private _SalesAccountSpecialistProcess As New SalesAccountSpecialistProcess
    Private _CompanyCodes As String = String.Empty
    Private m_ConfigtypeCode As String = String.Empty

    Private Function ValidateDataAll()
        m_Err.Clear()
        m_HasError = False
        Dim districtTarget As Decimal
        Dim areaNameTarget As Decimal
        Dim customerTarget As Decimal

        ' Try parsing the input values
        If Decimal.TryParse(txtDistrictTarget.Text, districtTarget) AndAlso
       Decimal.TryParse(txtAreaTarget.Text, areaNameTarget) AndAlso
       Decimal.TryParse(txtCustomerTarget.Text, customerTarget) Then

            ' Flag to track if any validation fails
            Dim validationFailed As Boolean = False

            ' Check if District Target is not equal to the Total Target
            'If districtTarget <> txtTargetAmount.Text Then
            '    txtDistrictTarget.BackColor = Color.Red ' Set error color
            '    validationFailed = True
            'Else
            '    txtDistrictTarget.BackColor = Color.White ' Set to normal color if valid
            'End If

            '' Check if AreaName Target is not equal to the Total Target
            'If areaNameTarget <> txtTargetAmount.Text Then
            '    txtTargetAmount.BackColor = Color.Red ' Set error color
            '    validationFailed = True
            'Else
            '    txtAreaTarget.BackColor = Color.White ' Set to normal color if valid
            'End If

            '' Check if Customer Target is not equal to the Total Target
            'If customerTarget <> txtTargetAmount.Text Then
            '    txtCustomerTarget.BackColor = Color.Red ' Set error color
            '    validationFailed = True
            'Else
            '    txtCustomerTarget.BackColor = Color.White ' Set to normal color if valid
            'End If

            ' Show validation message
            If validationFailed Then
                MessageBox.Show("One or more target amounts do not match the Total Target Amount!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                m_HasError = True
            End If
        Else
            ' If the user entered invalid values (non-numeric), change the background color to red
            txtDistrictTarget.BackColor = Color.Red
            txtAreaTarget.BackColor = Color.Red
            txtCustomerTarget.BackColor = Color.Red

            MessageBox.Show("Please enter valid numeric values for all target amounts!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
    Private Sub btnFinddata_Click(sender As Object, e As EventArgs) Handles btnFinddata.Click

        If ValidateDataAll() Then
            SalesAccountSpecialistProcess.DeleteUpdate(_SalesAccountSpecialist.SalesAccountSpecialistCode, _SalesAccountSpecialist.ConfigtypeCode)
            For m As Integer = 0 To GrdViewCustomer.Rows.Count - 1
                Dim rowCustomer As GridViewRowInfo = GrdViewCustomer.Rows(m)
                _SalesAccountSpecialistProcess = New SalesAccountSpecialistProcess
                _SalesAccountSpecialistProcess.SalesAccountSpecialistCode = GrdViewSAS.Text
                _SalesAccountSpecialistProcess.SalesAccountSpecialistName = txtSalesmanAccountName.Text
                _SalesAccountSpecialistProcess.CompanyCode = rowCustomer.Cells(5).Value
                _SalesAccountSpecialistProcess.CustomerCode = rowCustomer.Cells(2).Value
                _SalesAccountSpecialistProcess.CustomerName = rowCustomer.Cells(3).Value
                _SalesAccountSpecialistProcess.Target = rowCustomer.Cells(4).Value
                _SalesAccountSpecialistProcess.DistrictGroup = rowCustomer.Cells(6).Value
                _SalesAccountSpecialistProcess.DistrictName = rowCustomer.Cells(7).Value
                _SalesAccountSpecialistProcess.AreaName = rowCustomer.Cells(1).Value
                '_SalesAccountSpecialistProcess.ConfigtypeCode = m_ConfigtypeCode
                '_SalesAccountSpecialistProcess.Year = DropYear.Text
                '_SalesAccountSpecialistProcess.Month = DropMonth.Text
                _SalesAccountSpecialistProcess.Save()
            Next
            SalesAccountSpecialistProcess.SalesAccountSpecialistDistrictDelete(GrdViewSAS.Text)
            For m As Integer = 0 To GrdViewDistrictProperty.Rows.Count - 1
                Dim rowinfo As GridViewRowInfo = GrdViewDistrictProperty.Rows(m)
                _SalesAccountSpecialistProcess = New SalesAccountSpecialistProcess
                _SalesAccountSpecialistProcess.SalesAccountSpecialistCode = GrdViewSAS.Text
                '_SalesAccountSpecialistProcess.EffectivityStartDate = dtEffectivityStartDate.Text
                '_SalesAccountSpecialistProcess.EffectivityEndDate = dtEffectivityEndDate.Text
                _SalesAccountSpecialistProcess.Ischecked = rowinfo.Cells(0).Value
                _SalesAccountSpecialistProcess.DistrictGroup = rowinfo.Cells(1).Value
                _SalesAccountSpecialistProcess.DistrictName = rowinfo.Cells(2).Value
                _SalesAccountSpecialistProcess.Target = rowinfo.Cells(3).Value
                _SalesAccountSpecialistProcess.Createby = String.Empty
                _SalesAccountSpecialistProcess.UpCreateby = String.Empty
                _SalesAccountSpecialistProcess.SASDistrictSave()
            Next
            SalesAccountSpecialistProcess.SalesAccountSpecialistAreaNameDelete(GrdViewSAS.Text)
            For m As Integer = 0 To GrdViewAreaName.Rows.Count - 1
                Dim rowinfoAreaName As GridViewRowInfo = GrdViewAreaName.Rows(m)
                _SalesAccountSpecialistProcess = New SalesAccountSpecialistProcess
                _SalesAccountSpecialistProcess.SalesAccountSpecialistCode = GrdViewSAS.Text
                '_SalesAccountSpecialistProcess.EffectivityStartDate = dtEffectivityStartDate.Text
                '_SalesAccountSpecialistProcess.EffectivityEndDate = dtEffectivityEndDate.Text
                _SalesAccountSpecialistProcess.Ischecked = rowinfoAreaName.Cells(0).Value
                _SalesAccountSpecialistProcess.DistrictName = rowinfoAreaName.Cells(1).Value
                _SalesAccountSpecialistProcess.AreaName = rowinfoAreaName.Cells(2).Value
                _SalesAccountSpecialistProcess.DistrictGroup = rowinfoAreaName.Cells(4).Value
                _SalesAccountSpecialistProcess.Target = rowinfoAreaName.Cells(3).Value
                _SalesAccountSpecialistProcess.Createby = String.Empty
                _SalesAccountSpecialistProcess.UpCreateby = String.Empty
                _SalesAccountSpecialistProcess.SASAreaNameSave()
            Next
            SalesAccountSpecialistProcess.SalesAccountSpecialistChannelbyCustomerDelete(GrdViewSAS.Text)
            For m As Integer = 0 To GrdViewCustomer.Rows.Count - 1
                Dim rowinfoChannelbyCustomer As GridViewRowInfo = GrdViewCustomer.Rows(m)
                _SalesAccountSpecialistProcess = New SalesAccountSpecialistProcess
                _SalesAccountSpecialistProcess.SalesAccountSpecialistCode = GrdViewSAS.Text
                '_SalesAccountSpecialistProcess.EffectivityStartDate = dtEffectivityStartDate.Text
                '_SalesAccountSpecialistProcess.EffectivityEndDate = dtEffectivityEndDate.Text
                _SalesAccountSpecialistProcess.Ischecked = rowinfoChannelbyCustomer.Cells(0).Value
                _SalesAccountSpecialistProcess.CompanyCode = rowinfoChannelbyCustomer.Cells(5).Value
                _SalesAccountSpecialistProcess.CustomerCode = rowinfoChannelbyCustomer.Cells(2).Value
                _SalesAccountSpecialistProcess.CustomerName = rowinfoChannelbyCustomer.Cells(3).Value
                _SalesAccountSpecialistProcess.DistrictName = rowinfoChannelbyCustomer.Cells(7).Value
                _SalesAccountSpecialistProcess.AreaName = rowinfoChannelbyCustomer.Cells(1).Value
                _SalesAccountSpecialistProcess.DistrictGroup = rowinfoChannelbyCustomer.Cells(6).Value
                _SalesAccountSpecialistProcess.Target = rowinfoChannelbyCustomer.Cells(4).Value
                _SalesAccountSpecialistProcess.Createby = String.Empty
                _SalesAccountSpecialistProcess.UpCreateby = String.Empty
                _SalesAccountSpecialistProcess.SASChannelbyCustomerSave()
            Next
            SaveSuccess()
        End If
    End Sub
    Private Sub LoadPatientProfileAuto()
        Table = GetRecords(SalesAccountSpecialist.GetSearchSalesAccountSpecialistSql)
        GrdViewSAS.DataSource = Nothing
        GrdViewSAS.DataSource = Table
        'GrdViewPatient.Columns(0).Width = 120
        'GrdViewPatient.Columns(1).Width = 180
        'GrdViewPatient.Columns(2).Width = 180

        'GrdViewPatient.DisplayMember = "Patient FullName"
        'GrdViewPatient.ValueMember = "Patient Code"


        GrdViewSAS.AutoFilter = True
        GrdViewSAS.AutoSizeDropDownToBestFit = True
        Dim MultiColumnElement As RadMultiColumnComboBoxElement = Me.GrdViewSAS.MultiColumnComboBoxElement
        MultiColumnElement.DropDownMinSize = New Size(420, 300)
        'GrdViewPatient.Columns.Add(New GridViewTextBoxColumn("Patient Code"))
        'GrdViewPatient.Columns.Add(New GridViewTextBoxColumn("Patient FullName"))
        'GrdViewPatient.Columns.Add(New GridViewTextBoxColumn("Patient Classification"))
        Me.GrdViewSAS.MultiColumnComboBoxElement.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend

    End Sub

    Private Sub GrdViewSAS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GrdViewSAS.SelectedIndexChanged
        Try
            'Dim selectedValue As Object = GrdViewPatient.SelectedValue
            'Dim selectedItem As Object = GrdViewPatient.SelectedItem
            Dim compositeFilter As New CompositeFilterDescriptor()
            Dim _SASCode As New FilterDescriptor("SAS Code", FilterOperator.Contains, "")
            Dim _SASName As New FilterDescriptor("Sales Account Specialist Name", FilterOperator.Contains, "")
            compositeFilter.FilterDescriptors.Add(_SASCode)
            compositeFilter.FilterDescriptors.Add(_SASName)
            compositeFilter.LogicalOperator = FilterLogicalOperator.[Or]
            Me.GrdViewSAS.EditorControl.FilterDescriptors.Add(compositeFilter)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UISalesAccountSpecialistMapping_Load(sender As Object, e As EventArgs) Handles Me.Load
        ''Clear()
        LoadPatientProfileAuto()
        GrdViewSAS.Text = String.Empty
        ''LoadYear()
    End Sub

    Private Sub GrdViewSAS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GrdViewSAS.KeyPress
        Dim PatientCode As String = String.Empty
        If (GrdViewSAS.Text) = "" Then
            If e.KeyChar = Chr(13) Then 'Chr(13) is the Enter Key
                'Clear()
            End If
        Else
            PatientCode = GrdViewSAS.Text
            If e.KeyChar = Chr(13) Then 'Chr(13) is the Enter Key
                'Clear()
                ShowData(PatientCode)
                If ValidateData() Then
                    ShowDataDistrict()
                    CountRowActive()
                    ''txtTargetAmount.Select()
                Else
                    ShowDataDistrictbySAS(PatientCode)
                    ShowAreaNamebySAS(PatientCode)
                    ShowCustomersWithChannelbySAS(PatientCode)
                    ShowDataChannelbySAS(PatientCode)
                End If
                'ShowDataPrescribingMD(m_PatientProfile.PatientCode)
                'GetLocationAutoSql()
            End If
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        _SalesAccountSpecialist = SalesAccountSpecialist.LoadByCode(RecordCode)
        GrdViewSAS.Text = _SalesAccountSpecialist.SalesAccountSpecialistCode
        txtSalesmanAccountName.Text = _SalesAccountSpecialist.SalesAccountSpecialistName
        'dtEffectivityStartDate.Text = _SalesAccountSpecialist.DateStart
        'dtEffectivityEndDate.Text = _SalesAccountSpecialist.DateEnd
        m_ConfigtypeCode = _SalesAccountSpecialist.ConfigtypeCode
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False


        If GrdViewSAS.Text = "" Then
            m_Err.SetError(GrdViewSAS, "SAS Code is Required!")
            m_HasError = True
        Else
            If SalesAccountSpecialistProcess.CheckofSalesAccountSpecialistAlreadyExist(_SalesAccountSpecialist.SalesAccountSpecialistCode, _SalesAccountSpecialist.ConfigtypeCode) Then
                m_HasError = True
            End If
        End If
        Return Not m_HasError
    End Function

    Private Sub ShowDataChannelbySAS(ByVal SASCode As String)
        Table = GetRecords(SalesAccountSpecialistTagging.GetSalesAccountSpecialistChannelbySASSql(SASCode))
        GrdViewChannel.Rows.Clear()
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfoChannel As GridViewRowInfo = GrdViewChannel.Rows.AddNew
            rowinfoChannel.Cells(0).Value = Table.Rows(i)("CheckIn")
            rowinfoChannel.Cells(1).Value = Table.Rows(i)("ChannelCode")
            rowinfoChannel.Cells(2).Value = Table.Rows(i)("DISTNAME")
        Next
        txtChannelCount.Text = GrdViewChannel.Rows.Count
    End Sub
    Private Sub ShowDataDistrict()
        Table = GetRecords(DistrictAssignment.GetDistrictAssignmentSql)
        GrdViewDistrictProperty.Rows.Clear()
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewDistrictProperty.Rows.AddNew
            rowinfo.Cells(0).Value = False
            rowinfo.Cells(1).Value = Table.Rows(i)("DistrictGroup")
            rowinfo.Cells(2).Value = Table.Rows(i)("STDISTRCTNAME")
            rowinfo.Cells(3).Value = "0.00"
        Next
        txtDistrictCount.Text = GrdViewDistrictProperty.Rows.Count
    End Sub
    Private Sub ShowDataDistrictbySAS(ByVal SASCode As String)
        Table = GetRecords(DistrictAssignment.GetDistrictAssignmentbySASSql(SASCode))
        GrdViewDistrictProperty.Rows.Clear()
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewDistrictProperty.Rows.AddNew
            rowinfo.Cells(0).Value = Table.Rows(i)("CheckIn")
            rowinfo.Cells(1).Value = Table.Rows(i)("DistrictGroupCode")
            rowinfo.Cells(2).Value = Table.Rows(i)("DistrictName")
            rowinfo.Cells(3).Value = Table.Rows(i)("TargetAmount")
        Next
        Table = GetRecords(DistrictAssignment.GetTargetDistrictAssignmentbySql(SASCode))
        For i As Integer = 0 To Table.Rows.Count - 1
            txtDistrictTarget.Text = Table.Rows(i)("TargetAmount")
            Exit Sub
        Next
        txtDistrictCount.Text = GrdViewDistrictProperty.Rows.Count
    End Sub
    Private Sub ShowAreaNamebySAS(ByVal SASCode As String)
        GrdViewAreaName.Rows.Clear()
        Table = GetRecords(SalesAccountSpecialistTagging.GetSalesAccountSpecialAreaNamebySASSql(SASCode))
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewAreaName.Rows.AddNew
            rowinfo.Cells(0).Value = Table.Rows(i)("CheckIn")
            rowinfo.Cells(1).Value = Table.Rows(i)("DistrictName")
            rowinfo.Cells(2).Value = Table.Rows(i)("AreaName")
            rowinfo.Cells(3).Value = Table.Rows(i)("TargetAmount")
            rowinfo.Cells(4).Value = Table.Rows(i)("DistrictGroupCode")
        Next
        Table = GetRecords(SalesAccountSpecialistTagging.GetTargetAmountSalesAccountSpecialistChannelSql(SASCode))
        For i As Integer = 0 To Table.Rows.Count - 1
            txtAreaTarget.Text = Table.Rows(i)("TargetAmount")
            Exit Sub
        Next
        txtAreaCount.Text = GrdViewAreaName.Rows.Count
    End Sub
    Private Sub ShowAreaName(ByVal DistrictGroupCode As String)
        Table = GetRecords(SalesAccountSpecialistTagging.GetSalesAccountSpecialAreaNameSql(DistrictGroupCode, m_ConfigtypeCode))
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewAreaName.Rows.AddNew
            rowinfo.Cells(0).Value = False
            rowinfo.Cells(1).Value = Table.Rows(i)("STDISTRCTNAME")
            rowinfo.Cells(2).Value = Table.Rows(i)("STACOVNAME")
            rowinfo.Cells(3).Value = "0.00"
            rowinfo.Cells(4).Value = Table.Rows(i)("DistrictGroup")
        Next
        txtAreaCount.Text = GrdViewAreaName.Rows.Count
    End Sub

    Private Sub GrdViewAreaName_Click(sender As Object, e As EventArgs)
        For m As Integer = 0 To GrdViewAreaName.Rows.Count - 1
            Dim rowAreaName As GridViewRowInfo = GrdViewAreaName.Rows(m)
            If rowAreaName.Cells(0).Value = True Then
                ShowCustomers(rowAreaName.Cells(2).Value)
            End If
        Next
    End Sub
    Private Sub ShowCustomersWithChannel(ByVal AreaName As String, ByVal ChannelCode As String, ByVal TargetAmount As Decimal, ByVal DistrictGroup As String, ByVal DistrictName As String)
        Table = GetRecords(SalesAccountSpecialistTagging.GetSalesAccountSpecialCustomerWithChannelSql(AreaName, ChannelCode, m_ConfigtypeCode))
        txtCustomerCount.Text = Table.Rows.Count
        Dim TotalCount As Integer = Table.Rows.Count
        Dim TargetAmountAll As Decimal = "0.00"
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfoCustomer As GridViewRowInfo = GrdViewCustomer.Rows.AddNew
            rowinfoCustomer.Cells(0).Value = True
            rowinfoCustomer.Cells(1).Value = Table.Rows(i)("STACOVNAME")
            rowinfoCustomer.Cells(2).Value = Table.Rows(i)("Customer Code")
            rowinfoCustomer.Cells(3).Value = Table.Rows(i)("Customer Name")
            rowinfoCustomer.Cells(4).Value = Math.Round(TargetAmount / TotalCount, 2)
            rowinfoCustomer.Cells(5).Value = Table.Rows(i)("Distributor Code")
            rowinfoCustomer.Cells(6).Value = DistrictGroup
            rowinfoCustomer.Cells(7).Value = DistrictName
        Next
        txtCustomerCount.Text = GrdViewCustomer.Rows.Count
    End Sub
    Private Sub ShowCustomersWithChannelbySAS(ByVal SASCode As String)
        Table = GetRecords(SalesAccountSpecialistTagging.GetSalesAccountSpecialCustomerWithChannelbySASSql(SASCode))
        GrdViewCustomer.Rows.Clear()
        txtCustomerCount.Text = Table.Rows.Count
        Dim TotalCount As Integer = Table.Rows.Count
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfoCustomer As GridViewRowInfo = GrdViewCustomer.Rows.AddNew
            rowinfoCustomer.Cells(0).Value = Table.Rows(i)("CheckIn")
            rowinfoCustomer.Cells(1).Value = Table.Rows(i)("AreaName")
            rowinfoCustomer.Cells(2).Value = Table.Rows(i)("CustomerCode")
            rowinfoCustomer.Cells(3).Value = Table.Rows(i)("CustomerName")
            rowinfoCustomer.Cells(4).Value = Table.Rows(i)("TargetAmount")
            rowinfoCustomer.Cells(5).Value = Table.Rows(i)("ChannelCode")
            rowinfoCustomer.Cells(6).Value = Table.Rows(i)("DistrictGroupCode")
            rowinfoCustomer.Cells(7).Value = Table.Rows(i)("DistrictName")
        Next
        txtCustomerCount.Text = GrdViewCustomer.Rows.Count
    End Sub
    Private Sub ShowCustomers(ByVal AreaName As String)
        Table = GetRecords(SalesAccountSpecialistTagging.GetSalesAccountSpecialCustomerSql(AreaName))
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfoCustomer As GridViewRowInfo = GrdViewCustomer.Rows.AddNew
            rowinfoCustomer.Cells(0).Value = True
            rowinfoCustomer.Cells(1).Value = Table.Rows(i)("STACOVNAME")
            rowinfoCustomer.Cells(2).Value = Table.Rows(i)("Customer Code")
            rowinfoCustomer.Cells(3).Value = Table.Rows(i)("Customer Name")
        Next
    End Sub

    Private Sub btnApplyDistrict_Click(sender As Object, e As EventArgs) Handles btnApplyDistrict.Click
        GrdViewAreaName.Rows.Clear()
        For m As Integer = 0 To GrdViewDistrictProperty.Rows.Count - 1
            Dim rowinfos As GridViewRowInfo = GrdViewDistrictProperty.Rows(m)
            If rowinfos.Cells(0).Value = True Then
                ShowAreaName(rowinfos.Cells(1).Value)
                CountRowActive()
            End If
        Next
    End Sub

    Private Sub btnApplyArea_Click(sender As Object, e As EventArgs) Handles btnApplyArea.Click
        GrdViewCustomer.Rows.Clear()
        Dim companyCode As New List(Of String)
        For m As Integer = 0 To GrdViewAreaName.Rows.Count - 1
            Dim rowAreaName As GridViewRowInfo = GrdViewAreaName.Rows(m)
            If rowAreaName.Cells(0).Value = True Then
                ShowCustomersWithChannel(rowAreaName.Cells(2).Value, _CompanyCodes, rowAreaName.Cells(3).Value, rowAreaName.Cells(4).Value, rowAreaName.Cells(1).Value)
                CountRowActive()
            End If
        Next
    End Sub

    Private Sub GrdViewChannel_CellEndEdit(sender As Object, e As GridViewCellEventArgs) Handles GrdViewChannel.CellEndEdit
        For m As Integer = 0 To GrdViewChannel.Rows.Count - 1
            Dim rowinfos As GridViewRowInfo = GrdViewChannel.Rows(m)
            If rowinfos.Cells(0).Value = True Then
                ShowAreaName(rowinfos.Cells(1).Value)
            End If
        Next
    End Sub

    Private Sub RadMenuButtonItem2_Click(sender As Object, e As EventArgs) Handles btnCheckCustomerUnAll.Click
        For m As Integer = 0 To GrdViewCustomer.Rows.Count - 1
            Dim rowfoCustomer As GridViewRowInfo = GrdViewCustomer.Rows(m)
            rowfoCustomer.Cells(0).Value = False
        Next
    End Sub

    Private Sub RadMenuButtonItem1_Click(sender As Object, e As EventArgs) Handles btnCheckCustomerAll.Click
        For m As Integer = 0 To GrdViewCustomer.Rows.Count - 1
            Dim rowfoCustomer As GridViewRowInfo = GrdViewCustomer.Rows(m)
            rowfoCustomer.Cells(0).Value = True
        Next
    End Sub

    Private Sub btnUncheckArea_Click(sender As Object, e As EventArgs) Handles btnUncheckArea.Click
        For m As Integer = 0 To GrdViewAreaName.Rows.Count - 1
            Dim rowfoAreaName As GridViewRowInfo = GrdViewAreaName.Rows(m)
            rowfoAreaName.Cells(0).Value = False
        Next
    End Sub

    Private Sub btnUnCheck_Click(sender As Object, e As EventArgs) Handles btnUnCheck.Click
        For m As Integer = 0 To GrdViewDistrictProperty.Rows.Count - 1
            Dim rowfoDistrict As GridViewRowInfo = GrdViewDistrictProperty.Rows(m)
            rowfoDistrict.Cells(0).Value = False
        Next
    End Sub
    Private Sub GrdViewAreaName_CellEndEdit(sender As Object, e As GridViewCellEventArgs) Handles GrdViewAreaName.CellEndEdit
        For m As Integer = 0 To GrdViewDistrictProperty.Rows.Count - 1
            Dim rowfoDistrict As GridViewRowInfo = GrdViewDistrictProperty.Rows(m)
            For i As Integer = 0 To GrdViewAreaName.Rows.Count - 1
                Dim rowfoAreaName As GridViewRowInfo = GrdViewAreaName.Rows(i)
                If rowfoDistrict.Cells(0).Value = True Then
                    Dim DistrictTargetAmount As Integer = rowfoDistrict.Cells(3).Value
                    Dim DistrictName As String = rowfoDistrict.Cells(2).Value
                    If rowfoAreaName.Cells(0).Value = True And rowfoAreaName.Cells(1).Value = DistrictName Then
                        rowfoAreaName.Cells(3).Value = DistrictTargetAmount
                    End If
                End If
            Next
        Next
    End Sub
    Private Sub CountRowActive()
        Dim activeCount As Integer = 0
        Dim DistrictTargetAmount As Decimal = 0
        Dim AreaTargetAmount As Decimal = 0
        Dim CustomerAmount As Decimal = 0
        If GrdViewDistrictProperty.Rows.Count <> 0 Then
            Dim Num1 As Integer = 0
            txtDistrictActive.Text = 0
            For m As Integer = 0 To GrdViewDistrictProperty.Rows.Count - 1
                Dim rowfoDistrict As GridViewRowInfo = GrdViewDistrictProperty.Rows(m)
                If rowfoDistrict.Cells(0).Value = True Then
                    txtDistrictActive.Text += Num1 + 1
                    DistrictTargetAmount += Convert.ToDouble(rowfoDistrict.Cells(3).Value)
                    txtDistrictTarget.Text = DistrictTargetAmount
                End If
            Next
            btnApplyDistrict.Enabled = True
            btnUnCheck.Enabled = True
        End If
        If GrdViewChannel.Rows.Count <> 0 Then
            Dim Num2 As Integer = 0
            txtChannelActive.Text = 0
            _CompanyCodes = String.Empty
            For m As Integer = 0 To GrdViewChannel.Rows.Count - 1
                Dim rowfoChannel As GridViewRowInfo = GrdViewChannel.Rows(m)
                If rowfoChannel.Cells(0).Value = True Then
                    txtChannelActive.Text += Num2 + 1
                    Dim companyCode As String = rowfoChannel.Cells(1).Value.ToString()
                    If _CompanyCodes <> "" Then
                        _CompanyCodes &= ","  ' Add a comma between company codes
                    End If
                    _CompanyCodes &= "'" & companyCode & "'"  ' Add company code to the string
                End If
            Next
        End If
        If GrdViewAreaName.Rows.Count <> 0 Then
            Dim Num3 As Integer = 0
            txtAreaActive.Text = 0
            For m As Integer = 0 To GrdViewAreaName.Rows.Count - 1
                Dim rowfoAreaName As GridViewRowInfo = GrdViewAreaName.Rows(m)
                If rowfoAreaName.Cells(0).Value = True Then
                    txtAreaActive.Text += Num3 + 1
                    AreaTargetAmount += Convert.ToDouble(rowfoAreaName.Cells(3).Value)
                    txtAreaTarget.Text = AreaTargetAmount
                End If
            Next
            btnApplyArea.Enabled = True
            btnUncheckArea.Enabled = True
        End If
        If GrdViewCustomer.Rows.Count <> 0 Then
            Dim Num4 As Integer = 0
            txtCustomerActive.Text = 0
            For m As Integer = 0 To GrdViewCustomer.Rows.Count - 1
                Dim rowfoCustomer As GridViewRowInfo = GrdViewCustomer.Rows(m)
                If rowfoCustomer.Cells(0).Value = True Then
                    txtCustomerActive.Text += Num4 + 1
                    CustomerAmount += Convert.ToDouble(rowfoCustomer.Cells(4).Value)
                End If
            Next
            txtCustomerTarget.Text = Math.Round(CustomerAmount)
        End If
    End Sub

    Private Sub GrdViewChannel_Click(sender As Object, e As EventArgs) Handles GrdViewChannel.Click
        CountRowActive()
    End Sub

    Private Sub GrdViewAreaName_Click_1(sender As Object, e As EventArgs) Handles GrdViewAreaName.Click
        CountRowActive()
    End Sub

    Private Sub GrdViewDistrictProperty_Click(sender As Object, e As EventArgs) Handles GrdViewDistrictProperty.Click
        CountRowActive()
    End Sub
    'Private Sub txtTargetAmount_Leave(sender As Object, e As EventArgs)
    '    If IsNumeric(txtTargetAmount.Text) Then
    '        txtTargetAmount.Text = String.Format("{0:N2}", Convert.ToDecimal(txtTargetAmount.Text))
    '    End If
    'End Sub

    Private Sub GrdViewDistrictProperty_CellValueChanged(sender As Object, e As GridViewCellEventArgs) Handles GrdViewDistrictProperty.CellValueChanged
        If e.RowIndex >= 0 AndAlso e.Row.Cells("column4").Value IsNot Nothing Then
            ' Check if the cell value is empty or contains only white spaces
            If String.IsNullOrEmpty(e.Row.Cells("column4").Value.ToString().Trim()) Then
                ' Set the value to 0.00 if empty or white space
                e.Row.Cells("column4").Value = 0.00
            ElseIf IsNumeric(e.Row.Cells("column4").Value) Then
                ' Format the cell value as currency (1,000.00)
                e.Row.Cells("column4").Value = String.Format("{0:N2}", Convert.ToDecimal(e.Row.Cells("column4").Value))
            End If
        End If
    End Sub
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnApplyDistrict.Enabled = IsEditMode
        btnApplyArea.Enabled = IsEditMode
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Clear()
        EditMode(False)
    End Sub
    Private Sub Clear()
        GrdViewSAS.Text = String.Empty
        txtSalesmanAccountName.Text = String.Empty
        GrdViewDistrictProperty.Rows.Clear()
        GrdViewAreaName.Rows.Clear()
        GrdViewCustomer.Rows.Clear()
        GrdViewChannel.Rows.Clear()
        'txtTargetAmount.Text = "0.00"
        txtDistrictTarget.Text = "0.00"
        txtAreaTarget.Text = "0.00"
        txtCustomerTarget.Text = "0.00"
        txtChannelCount.Text = "0"
        txtDistrictCount.Text = "0"
        txtAreaCount.Text = "0"
        txtCustomerCount.Text = "0"
        txtChannelActive.Text = "0"
        txtDistrictActive.Text = "0"
        txtAreaActive.Text = "0"
        txtCustomerActive.Text = "0"
    End Sub
    'Private Sub GrdViewDistrictProperty_CellBeginEdit(sender As Object, e As GridViewCellCancelEventArgs) Handles GrdViewDistrictProperty.CellBeginEdit
    '    For m As Integer = 0 To GrdViewDistrictProperty.Rows.Count - 1
    '        Dim rowfoDistrict As GridViewRowInfo = GrdViewDistrictProperty.Rows(m)
    '        If rowfoDistrict.Cells(0).Value = True Then
    '            If rowfoDistrict.Cells(3).Value = "0.00" Then
    '                rowfoDistrict.Cells(3).Value = txtTargetAmount.Text
    '            End If
    '        End If
    '    Next
    'End Sub
    Private Sub btnClosed_Click(sender As Object, e As EventArgs) Handles btnClosed.Click
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub GrdViewCustomer_Click(sender As Object, e As EventArgs) Handles GrdViewCustomer.Click

    End Sub

    Private Sub GrdViewCustomer_CellBeginEdit(sender As Object, e As GridViewCellCancelEventArgs) Handles GrdViewCustomer.CellBeginEdit
        For m As Integer = 0 To GrdViewCustomer.Rows.Count - 1
            Dim rowinfoCustomer As GridViewRowInfo = GrdViewCustomer.Rows(m)
            If rowinfoCustomer.Cells(0).Value = False Then
                rowinfoCustomer.Cells(4).Value = "0.00"
            End If
        Next
        CountRowActive()
    End Sub

    Private Sub GrdViewCustomer_CellEndEdit(sender As Object, e As GridViewCellEventArgs) Handles GrdViewCustomer.CellEndEdit
        For m As Integer = 0 To GrdViewCustomer.Rows.Count - 1
            Dim rowinfoCustomer As GridViewRowInfo = GrdViewCustomer.Rows(m)
            If rowinfoCustomer.Cells(0).Value = False Then
                rowinfoCustomer.Cells(4).Value = "0.00"
            End If
        Next
        CountRowActive()
    End Sub

    Private Sub GrdViewCustomer_CellClick(sender As Object, e As GridViewCellEventArgs) Handles GrdViewCustomer.CellClick
        For m As Integer = 0 To GrdViewCustomer.Rows.Count - 1
            Dim rowinfoCustomer As GridViewRowInfo = GrdViewCustomer.Rows(m)
            If rowinfoCustomer.Cells(0).Value = False Then
                rowinfoCustomer.Cells(4).Value = "0.00"
            End If
        Next
        CountRowActive()
    End Sub

    Private Sub GrdViewAreaName_CellValueChanged(sender As Object, e As GridViewCellEventArgs) Handles GrdViewAreaName.CellValueChanged
        For m As Integer = 0 To GrdViewAreaName.Rows.Count - 1
            Dim rowinfoAreaName As GridViewRowInfo = GrdViewAreaName.Rows(m)
            If rowinfoAreaName.Cells(0).Value = False Then
                rowinfoAreaName.Cells(3).Value = "0.00"
            End If
        Next
        CountRowActive()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class
