Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports Telerik.WinControls.UI
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports Infragistics.Win.FormattedLinkLabel
Imports DataLayer
Imports SPMSOPCI.MainWindow
Public Class UIAccountSpecialistEntry
    Private _SalesAccountSpecialist As New SalesAccountSpecialist
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False

    Private Sub Clear()
        txtSalesAccountCode.Text = String.Empty
        txtSalesmanAccountName.Text = String.Empty
        txtContactNo.Text = String.Empty
        txtEmailAddress.Text = String.Empty
        txtConfigCode.Text = String.Empty
        txtConfgName.Text = String.Empty
        dtEffectivityStartDate.Text = DateTime.Now
        dtEffectivityEndDate.Text = DateTime.Now
        cmbGender.Text = Nothing
        chkIsActive.Checked = False
    End Sub
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtSalesAccountCode.ReadOnly = Not IsEditMode
        txtSalesAccountCode.BackColor = Color.White

        txtSalesmanAccountName.ReadOnly = Not IsEditMode
        txtSalesmanAccountName.BackColor = Color.White

        txtContactNo.ReadOnly = Not IsEditMode
        txtContactNo.BackColor = Color.White

        txtEmailAddress.ReadOnly = Not IsEditMode
        txtEmailAddress.BackColor = Color.White

        txtConfigCode.ReadOnly = Not IsEditMode
        txtConfigCode.BackColor = Color.White

        txtConfgName.ReadOnly = Not IsEditMode
        txtConfgName.BackColor = Color.White

    End Sub
    Private Sub NewRecord()
        Clear()
        _SalesAccountSpecialist = New SalesAccountSpecialist
        EditMode(True)
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnDelete.Click, btnEdit.Click, btnFinddata.Click, btnSave.Click, btnClear.Click, btnClose.Click
        If sender Is btnNew Then
            NewRecord()
            chkIsActive.Checked = True
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
                SaveRecord()
            End If
        End If
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(SalesAccountSpecialist.GetSalesAccountSpecialistSql, "Sales Account Specialist")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
            EditMode(False)
        End If
    End Sub
    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Function ValidateData()
        m_Err.Clear()
        m_HasError = False

        If txtSalesAccountCode.Text = "" Then
            m_Err.SetError(txtSalesAccountCode, "SAS Code is Required!")
            m_HasError = True
        Else
            If SalesAccountSpecialist.CheckofSalesAccountSpecialistAlreadyExist(txtSalesAccountCode.Text, IIf(txtSalesAccountCode.Tag Is Nothing, -1, txtSalesAccountCode.Tag)) Then
                m_Err.SetError(txtSalesAccountCode, "SAS Code Already Exist")
                m_HasError = True
            End If
        End If

        If txtSalesmanAccountName.Text = "" Then
            m_Err.SetError(txtSalesmanAccountName, "SAS Name is Required!")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
    Private Sub SaveRecord()
        _SalesAccountSpecialist.SalesAccountSpecialistCode = txtSalesAccountCode.Text
        _SalesAccountSpecialist.SalesAccountSpecialistName = txtSalesmanAccountName.Text
        _SalesAccountSpecialist.PhoneNumber = txtContactNo.Text
        _SalesAccountSpecialist.Email = txtEmailAddress.Text
        _SalesAccountSpecialist.ConfigtypeCode = txtConfigCode.Text
        _SalesAccountSpecialist.DateStart = dtEffectivityStartDate.Text
        _SalesAccountSpecialist.DateEnd = dtEffectivityEndDate.Text
        If chkIsActive.Checked = True Then
            _SalesAccountSpecialist.IsActive = True
        Else
            _SalesAccountSpecialist.IsActive = False
        End If

        If cmbGender.Text = "Male" Then
            _SalesAccountSpecialist.Gender = 1
        ElseIf cmbGender.Text = "Female" Then
            _SalesAccountSpecialist.Gender = 2
        Else
            _SalesAccountSpecialist.Gender = -1
        End If

        _SalesAccountSpecialist.Createby = MainWindow.MainUserName

        If _SalesAccountSpecialist.Save Then
            SaveSuccess()
            ShowData(_SalesAccountSpecialist.SalesAccountSpecialistID)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        If RecordCode < 1 Then Exit Sub
        _SalesAccountSpecialist = SalesAccountSpecialist.Load(RecordCode)
        txtSalesAccountCode.Tag = _SalesAccountSpecialist.SalesAccountSpecialistID
        txtSalesAccountCode.Text = _SalesAccountSpecialist.SalesAccountSpecialistCode
        txtSalesmanAccountName.Text = _SalesAccountSpecialist.SalesAccountSpecialistName
        txtContactNo.Text = _SalesAccountSpecialist.PhoneNumber
        txtEmailAddress.Text = _SalesAccountSpecialist.Email
        If Not _SalesAccountSpecialist.ConfigtypeCode = String.Empty Then
            txtConfigCode.Tag = _SalesAccountSpecialist.ConfigtypeCode
            txtConfigCode.Text = _SalesAccountSpecialist.ConfigtypeCode
            txtConfgName.Text = Configuration.GetConfigTypeCode(txtConfigCode.Tag)
        End If
        dtEffectivityStartDate.Text = _SalesAccountSpecialist.DateStart
        dtEffectivityEndDate.Text = _SalesAccountSpecialist.DateEnd

        If _SalesAccountSpecialist.IsActive = True Then
            chkIsActive.Checked = True
        Else
            chkIsActive.Checked = False
        End If
        If _SalesAccountSpecialist.Gender = 1 Then
            cmbGender.Text = "Male"
        ElseIf _SalesAccountSpecialist.Gender = 2 Then
            cmbGender.Text = "Female"
        Else
            cmbGender.Text = ""
        End If

        EditMode(False)
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog() = DialogResult.Yes Then
            If _SalesAccountSpecialist.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub

    Private Sub Findconfig_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Findconfig.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Medical Configuration")
        If Not tag Is Nothing Then
            txtConfigCode.Text = tag.KeyColumn11
            txtConfgName.Text = tag.KeyColumn33
        End If
    End Sub

    Private Sub UIAccountSpecialistEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
        Clear()
    End Sub
End Class
