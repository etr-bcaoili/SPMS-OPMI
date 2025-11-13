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
Public Class UIProductManager
    Private _ProductManager As New ProductManager
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private Sub Clear()
        txtProductManagerCode.Text = String.Empty
        txtProductManagerName.Text = String.Empty
        txtConfigCode.Text = String.Empty
        txtConfgName.Text = String.Empty
        dtEffectivityStartDate.Text = DateTime.Now
        dtEffectivityEndDate.Text = DateTime.Now
        chkIsActive.Checked = False
    End Sub
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtProductManagerCode.ReadOnly = Not IsEditMode
        txtProductManagerCode.BackColor = Color.White

        txtProductManagerName.ReadOnly = Not IsEditMode
        txtProductManagerName.BackColor = Color.White

        txtConfigCode.ReadOnly = Not IsEditMode
        txtConfigCode.BackColor = Color.White

        txtConfgName.ReadOnly = Not IsEditMode
        txtConfgName.BackColor = Color.White

    End Sub
    Private Sub NewRecord()
        Clear()
        _ProductManager = New ProductManager
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
    Private Sub SaveRecord()
        _ProductManager.PriductID = txtProductManagerCode.Text
        _ProductManager.ProductManager = txtProductManagerName.Text
        _ProductManager.ConfigtypeCode = txtConfigCode.Text
        _ProductManager.EffectivityStartDate = dtEffectivityStartDate.Text
        _ProductManager.EffectivityEndDate = dtEffectivityEndDate.Text
        If chkIsActive.Checked = True Then
            _ProductManager.IsActive = True
        Else
            _ProductManager.IsActive = False
        End If
        _ProductManager.Createby = MainWindow.MainUserName

        If _ProductManager.Save Then
            SaveSuccess()
            ShowData(_ProductManager.ID)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        If RecordCode < 1 Then Exit Sub
        _ProductManager = ProductManager.Load(RecordCode)
        txtProductManagerCode.Tag = _ProductManager.ID
        txtProductManagerCode.Text = _ProductManager.PriductID
        txtProductManagerName.Text = _ProductManager.ProductManager

        If Not _ProductManager.ConfigtypeCode = String.Empty Then
            txtConfigCode.Tag = _ProductManager.ConfigtypeCode
            txtConfigCode.Text = _ProductManager.ConfigtypeCode
            txtConfgName.Text = Configuration.GetConfigTypeCode(txtConfigCode.Tag)
        End If
        dtEffectivityStartDate.Text = _ProductManager.EffectivityStartDate
        dtEffectivityEndDate.Text = _ProductManager.EffectivityEndDate

        If _ProductManager.IsActive = True Then
            chkIsActive.Checked = True
        Else
            chkIsActive.Checked = False
        End If

        EditMode(False)
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog() = DialogResult.Yes Then
            If _ProductManager.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(ProductManager.GetProductManagerSql, "Product Manager")
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

        If txtProductManagerCode.Text = "" Then
            m_Err.SetError(txtProductManagerCode, "Product Manager Code is Required!")
            m_HasError = True
        Else
            If ProductManager.CheckOProductManagerAlreadyExist(txtProductManagerCode.Text, IIf(txtProductManagerCode.Tag Is Nothing, -1, txtProductManagerCode.Tag)) Then
                m_Err.SetError(txtProductManagerCode, "Product Manager Code Already Exist")
                m_HasError = True
            End If
        End If

        If txtProductManagerName.Text = "" Then
            m_Err.SetError(txtProductManagerName, "Product Manager Name is Required!")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
    Private Sub Findconfig_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Findconfig.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Configuration.GetConfigtypeSql, "Medical Configuration")
        If Not tag Is Nothing Then
            txtConfigCode.Text = tag.KeyColumn11
            txtConfgName.Text = tag.KeyColumn33
        End If
    End Sub
End Class
