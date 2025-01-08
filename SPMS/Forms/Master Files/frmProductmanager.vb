Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ucMasterRegion
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class frmProductManager
    Private Operation As String = ""
    Dim m_HasError As Boolean
    Private m_Err As New ErrorProvider
    Dim m_pm As New UCproductManager
    Private mp_PositionCode As String = ""
    Private mp_ID As String = ""

    Public Property PositionCode() As String
        Get
            Return mp_PositionCode
        End Get
        Set(ByVal value As String)
            mp_PositionCode = value
        End Set
    End Property

    Private Sub setupButtons(ByVal HasOperation As Boolean)
        btnAdd.Enabled = Not HasOperation
        btnDelete.Enabled = Not HasOperation
        btnEdit.Enabled = Not HasOperation
        btnSave.Enabled = HasOperation
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        setupButtons(True)
        m_pm = New UCproductManager
        clearData()
        BoxUpdate(True)
        UnEnabletext()
    End Sub
    Private Sub EnableText()
        txtpmcode.ReadOnly = True
        txtpmname.ReadOnly = True
    End Sub
    Private Sub UnEnabletext()
        txtpmcode.ReadOnly = False
        txtpmname.ReadOnly = False
    End Sub

    Private Function BoxUpdate(ByVal HasOperation As Boolean) As Boolean
        txtpmcode.ReadOnly = Not HasOperation
        txtpmname.ReadOnly = Not HasOperation
    End Function
    Private Sub ClearData()
        txtpmcode.Text = String.Empty
        txtpmname.Text = String.Empty
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Operation = "Add" Then
            If Validate() Then
                SaveData()
                ClearData()
                EnableText()
                setupButtons(False)
            End If
        ElseIf Operation = "Edit" Then
            If Validate() Then
                UpdateData()
                ClearData()
                EnableText()
                setupButtons(False)
            End If
        End If
    End Sub
    Private Function Validate() As Boolean
        m_Err.Clear()
        m_HasError = False

        If txtpmcode.Text = "" Then
            m_Err.SetError(txtpmcode, "Pls Enter the Code")
            m_HasError = True
        End If
        If txtpmname.Text = "" Then
            m_Err.SetError(txtpmname, "Pls Enter the Name")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function

    Private Function SaveData() As Boolean
        m_pm = New UCproductManager

        m_pm.PmCode = txtpmcode.Text
        m_pm.PmName = txtpmname.Text
        m_pm.EFFECTIVITYSTARTDATE = dtStart.Text
        m_pm.EFFECTIVITYENDDATE = dtEnd.Text
        m_pm.Save()
        SaveSuccess()
        gProductManager.Rows.Clear()
        loadviewDetails()
        setupButtons(True)
        BoxUpdate(False)
    End Function

    Private Function UpdateData() As Boolean
        SPMSConn.Execute("Update Productmanager set Pm_code = '" & txtpmcode.Text & "',PM_Name ='" & txtpmname.Text & "' where ID like '" & mp_ID & "'")
        SaveSuccess()
        gProductManager.Rows.Clear()
        loadviewDetails()
        setupButtons(False)
        BoxUpdate(False)
    End Function
    Private Function Delete() As Boolean
        SPMSConn.Execute("Delete from productmanager where ID like '" & mp_ID & "'")
        DeleteSuccess()
        gProductManager.Rows.Clear()
        ClearData()
        loadviewDetails()
        setupButtons(False)
        BoxUpdate(False)
    End Function

    Private Sub linkPosition_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim ViewSTAreacoverage As New frmViewStAreaCoverage
        ViewSTAreacoverage.ShowDialog(Me)
    End Sub

    Private Sub frmPositionManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call loadViewDetails()
        m_pm = New UCproductManager
        setupButtons(True)
        BoxUpdate(True)
        Operation = ("Add")
    End Sub

    Private Sub loadviewDetails()

        Connect()
        Dim cmd As New SqlCommand("uspProductManagerView", SPMSConn2)
        cmd.CommandType = CommandType.StoredProcedure
        Dim sqlda As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim tb As New DataTable
        sqlda.Fill(tb)

        If tb.Rows.Count = 0 Then
            gProductManager.Rows.Clear()
        Else
            For m As Integer = 0 To tb.Rows.Count - 1
                Dim dr As DataRow = tb.Rows(m)
                Dim row As DataGridViewRow = gProductManager.Rows(gProductManager.Rows.Add)
                row.Cells(colID.Index).Value = dr("ID")
                row.Cells(colprodid.Index).Value = dr("PM_code")
                row.Cells(colProdname.Index).Value = dr("PM_Name")
            Next
        End If
        gProductManager.Refresh()
    End Sub

    Private Sub SetEditOrDelete(ByVal HasOperation As Boolean)
        btnAdd.Enabled = HasOperation
        btnClose.Enabled = HasOperation
        btnDelete.Enabled = HasOperation
        btnEdit.Enabled = HasOperation
        btnSave.Enabled = Not HasOperation
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        setupButtons(True)
        Operation = "Edit"
        BoxUpdate(True)
        UnEnabletext()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Delete()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub gproductmanager_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gproductmanager.CellContentClick

        Dim row As DataGridViewRow = gproductmanager.Rows(e.RowIndex)

        mp_ID = row.Cells(colid.Index).Value
        txtpmcode.Text = row.Cells(colprodid.Index).Value
        txtpmname.Text = row.Cells(colprodname.Index).Value
        SetEditOrDelete(True)
        BoxUpdate(False)
    End Sub

    Private Sub gproductmanager_CellContentDoubleClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gproductmanager.CellContentDoubleClick
        Dim row As DataGridViewRow = gproductmanager.Rows(e.RowIndex)

        mp_ID = row.Cells(colid.Index).Value
        txtpmcode.Text = row.Cells(colprodid.Index).Value
        txtpmname.Text = row.Cells(colprodname.Index).Value
        SetEditOrDelete(True)
        BoxUpdate(False)
    End Sub

    Private Sub gproductmanager_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gproductmanager.CellDoubleClick
        Dim row As DataGridViewRow = gproductmanager.Rows(e.RowIndex)

        mp_ID = row.Cells(colid.Index).Value
        txtpmcode.Text = row.Cells(colprodid.Index).Value
        txtpmname.Text = row.Cells(colprodname.Index).Value
        SetEditOrDelete(True)
        BoxUpdate(False)
    End Sub

    Private Sub dtEnd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtEnd.ValueChanged

    End Sub

    Private Sub dtStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtStart.ValueChanged

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub
End Class