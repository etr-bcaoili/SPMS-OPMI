Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports System.Security.Policy
Public Class UIDistributors
    Private _Distributor As New Distributor
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnEdit.Enabled = Not IsEditMode
        btnNew.Enabled = Not IsEditMode
        btnDelete.Enabled = Not IsEditMode

        txtChannelCode.ReadOnly = Not IsEditMode
        txtChannelCode.BackColor = Color.White

        txtChannelDescription.ReadOnly = Not IsEditMode
        txtChannelDescription.BackColor = Color.White

        txtChannelAddress.ReadOnly = Not IsEditMode
        txtChannelAddress.BackColor = Color.White
    End Sub
    Private Sub EditModeVat(ByVal IsEditMode As Boolean)
        txtMunicipalTax.ReadOnly = Not IsEditMode
        txtMunicipalTax.BackColor = Color.White

        txtDistributorMargin.ReadOnly = Not IsEditMode
        txtDistributorMargin.BackColor = Color.White
    End Sub
    Private Sub Clear()
        txtChannelCode.Text = String.Empty
        txtChannelDescription.Text = String.Empty
        txtChannelAddress.Text = String.Empty
        CheckNetVat.Checked = False
        txtMunicipalTax.Text = String.Empty
        txtDistributorMargin.Text = String.Empty
        dtFromDate.Text = DateTime.Now
        dtTodate.Text = DateTime.Now
    End Sub
    Private Sub NewRecord()
        Clear()
        _Distributor = New Distributor
        EditMode(True)
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnDelete.Click, btnEdit.Click, btnFind.Click, btnSave.Click, btnClear.Click, btnClose.Click
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
        ElseIf sender Is btnFind Then
            Find()
        ElseIf sender Is btnSave Then
            If ValidateData() Then
                SaveRecord()
            End If
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

        If txtChannelCode.Text = "" Then
            m_Err.SetError(txtChannelCode, "Channel Code is Required!")
            m_HasError = True
        Else
            If Distributor.CheckofDistributorAlreadyExist(txtChannelCode.Text, IIf(txtChannelCode.Tag Is Nothing, -1, txtChannelCode.Tag)) Then
                m_Err.SetError(txtChannelCode, "Channel Code Already Exist")
                m_HasError = True
            End If
        End If
        If txtChannelDescription.Text = "" Then
            m_Err.SetError(txtChannelDescription, "Channel Description is Required!")
            m_HasError = True
        End If

        If CheckNetVat.Checked = True Then
            If txtMunicipalTax.Text = "0.0000" Then
                m_Err.SetError(txtMunicipalTax, "Municipal Tax is Required!")
                m_HasError = True
            End If
            If txtDistributorMargin.Text = "0.0000" Then
                m_Err.SetError(txtDistributorMargin, "Distributor Marging Tax is Required!")
                m_HasError = True
            End If
        End If

        Return Not m_HasError
    End Function
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Distributor.GetDistributorSql, "Distributor")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
            EditMode(False)
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        Clear()
        If RecordCode < 1 Then Exit Sub
        _Distributor = Distributor.Load(RecordCode)
        txtChannelCode.Tag = _Distributor.DISTRIBUTORID
        txtChannelCode.Text = _Distributor.DISTCOMID
        txtChannelDescription.Text = _Distributor.DISTNAME
        txtChannelAddress.Text = _Distributor.ADDR

        If _Distributor.IsActiveVat = True Then
            CheckNetVat.Checked = True
        Else
            CheckNetVat.Checked = False
        End If
        txtMunicipalTax.Text = _Distributor.MunTax
        txtDistributorMargin.Text = _Distributor.DistMargin

        EditMode(False)
    End Sub
    Private Sub SaveRecord()
        _Distributor.DISTCOMID = txtChannelCode.Text
        _Distributor.DISTNAME = txtChannelDescription.Text
        _Distributor.ADDR = txtChannelAddress.Text
        _Distributor.EFFECTIVITYSTARTDATE = dtFromDate.Text
        _Distributor.EFFECTIVITYENDDATE = dtTodate.Text


        If CheckNetVat.Checked = True Then
            _Distributor.MunTax = txtMunicipalTax.Text
            _Distributor.DistMargin = txtDistributorMargin.Text
            _Distributor.IsActiveVat = True
        Else
            _Distributor.MunTax = "0.00"
            _Distributor.DistMargin = "0.00"
            _Distributor.IsActiveVat = False
        End If


        If _Distributor.Save Then
            SaveSuccess()
            ShowData(_Distributor.DISTRIBUTORID)
            EditMode(False)
        Else
            UnSuccesSave()
        End If
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog() = MsgBoxResult.Yes Then
            If _Distributor.Delete Then
                DeleteSuccess()
                NewRecord()
            Else
                UnDeleteSuccess()
            End If
        End If
    End Sub

    Private Sub CheckNetVat_CheckedChanged(sender As Object, e As EventArgs) Handles CheckNetVat.CheckedChanged
        If CheckNetVat.Checked = True Then
            EditModeVat(True)
        Else
            txtDistributorMargin.Text = String.Empty
            txtMunicipalTax.Text = String.Empty
        End If
    End Sub

    Private Sub UIDistributors_Load(sender As Object, e As EventArgs) Handles Me.Load
        EditModeVat(False)
        EditMode(False)
    End Sub
End Class
