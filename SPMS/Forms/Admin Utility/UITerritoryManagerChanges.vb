Imports System.Data.OleDb
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports Telerik.WinControls.UI
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Text.RegularExpressions
Imports Telerik.WinControls.Data

Public Class UITerritoryManagerChanges
    Private m_FileName As String = String.Empty
    Private m_Err As New ErrorProvider
    Private m_HasError As Boolean = False
    Dim Table As New DataTable
    Private m_InqueryValidationData As New InqueryValidationData
    Private strKeyColumn As String = ""
    Private strKeyColumn1 As String = ""
    Private strKeyColumn2 As String = ""
    Private strKeyColumn3 As String = "'"
    Private strKeyColumn4 As String = "'"
    Private strKeyColumn5 As String = "'"

    Public ReadOnly Property Keycolumn() As String
        Get
            Return strKeyColumn
        End Get
    End Property


    Public ReadOnly Property Keycolumn1() As String
        Get
            Return strKeyColumn1
        End Get
    End Property


    Public ReadOnly Property Keycolumn2() As String
        Get
            Return strKeyColumn2
        End Get
    End Property

    Public ReadOnly Property Keycolumn4() As String
        Get
            Return strKeyColumn4
        End Get
    End Property
    Public ReadOnly Property Keycolumn5() As String
        Get
            Return strKeyColumn5
        End Get
    End Property
    Public ReadOnly Property Keycolumn3() As String
        Get
            Return strKeyColumn3
        End Get
    End Property

    Private Sub EditMode(ByVal IsEditMode As Boolean)

        btnUpdateSalesMatrix.Enabled = Not IsEditMode
        btnUpdateSharing.Enabled = Not IsEditMode
        btnUpdateFinal.Enabled = Not IsEditMode


        btnOpenData.Enabled = IsEditMode

        txtTMCode_Sharing.ReadOnly = Not IsEditMode
        txtTMCode_Sharing.BackColor = Color.White

        txtTMName_Sharing.ReadOnly = Not IsEditMode
        txtTMName_Sharing.BackColor = Color.White

        txtTMCode_Final.ReadOnly = Not IsEditMode
        txtTMCode_Final.BackColor = Color.White

        txtTMName_Final.ReadOnly = Not IsEditMode
        txtTMName_Final.BackColor = Color.White

        txtTerritoryCode_Final.ReadOnly = Not IsEditMode
        txtTerritoryCode_Final.BackColor = Color.White

        txtTerritoryAreaName_Final.ReadOnly = Not IsEditMode
        txtTerritoryAreaName_Final.BackColor = Color.White


    End Sub
    Private Sub EditModeSalesMatrix(ByVal IsEditMode As Boolean)

        'txtTMCode_SalesMatrix.ReadOnly = Not IsEditMode
        'txtTMCode_SalesMatrix.BackColor = Color.White

        txtTMName_SalesMatrix.ReadOnly = Not IsEditMode
        txtTMName_SalesMatrix.BackColor = Color.White

        txtTMArea_SalesMatrix.ReadOnly = Not IsEditMode
        txtTMArea_SalesMatrix.BackColor = Color.White
    End Sub
    Private Sub EditModeSharing(ByVal IsEditMode As Boolean)
        txtTM_TerritorySharing.ReadOnly = Not IsEditMode
        txtTM_TerritorySharing.BackColor = Color.White

        'txtTMCode_Sharing.ReadOnly = Not IsEditMode
        'txtTMCode_Sharing.BackColor = Color.White

        txtTMName_Sharing.ReadOnly = Not IsEditMode
        txtTMName_Sharing.BackColor = Color.White
    End Sub
    Private Sub EditModeFinal(ByVal IsEditMode As Boolean)
        txtTMName_Final.ReadOnly = Not IsEditMode
        txtTMName_Final.BackColor = Color.White

        txtTerritoryCode_Final.ReadOnly = Not IsEditMode
        txtTerritoryCode_Final.BackColor = Color.White

        txtTerritoryAreaName_Final.ReadOnly = Not IsEditMode
        txtTerritoryAreaName_Final.BackColor = Color.White
    End Sub

    Private Sub ClearSalesMatrix()
        txtTMName_SalesMatrix.Text = String.Empty
        txtTMArea_SalesMatrix.Text = String.Empty
        txtTMCode_SalesMatrix.Text = String.Empty
    End Sub
    Private Sub ClearSharing()
        txtTMCode_Sharing.Text = String.Empty
        txtTMName_Sharing.Text = String.Empty
        txtTM_TerritorySharing.Text = String.Empty
    End Sub
    Private Sub ClearSc02()
        txtTMCode_Final.Text = String.Empty
        txtTMName_Final.Text = String.Empty
        txtTerritoryCode_Final.Text = String.Empty
        txtTerritoryAreaName_Final.Text = String.Empty
    End Sub
    Private Sub loadData()
        Table = GetRecords("Select Configtypecode,ConfigTypeName from ConfigurationType")
        For i As Integer = 0 To Table.Rows.Count - 1
            cboConfigtype.Items.Add(Table.Rows(i)("Configtypecode"))
        Next
    End Sub
    Private Sub UITerritoryManagerChanges_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadData()
    End Sub
    Private Sub LoadConfigtypeName(ByVal ConfigtypeCode As String)
        Table = GetRecords("Select Configtypecode,ConfigTypeName from ConfigurationType Where Configtypecode = '" & ConfigtypeCode & "'")
        For i As Integer = 0 To Table.Rows.Count - 1
            txtConfigtypeNames.Text = Table.Rows(i)("ConfigTypeName")
            Exit Sub
        Next
    End Sub
    Private Sub cboConfigtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboConfigtype.SelectedIndexChanged
        LoadConfigtypeName(cboConfigtype.Text)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btnOpenData.Click
        If ValidateData() Then
            LoadSalesMatrix(cboConfigtype.Text, txtTerritoryManagerCode.Text)
            LoadSharing(cboConfigtype.Text, txtTerritoryManagerCode.Text)
            LoadFinal(cboConfigtype.Text, txtTerritoryManagerCode.Text)
            ClearSalesMatrix()
            ClearSharing()
            ClearSc02()
        End If
    End Sub
    Private Function ValidateData() As Boolean
        m_Err.Clear()
        m_HasError = False

        If txtConfigtypeNames.Text = "" Then
            MessageBox.Show("Configtype Name is required", "Invalid")
            m_HasError = True
        End If

        If txtTerritoryManagerCode.Text = "" Then
            MessageBox.Show("Territory TM is required", "Invalid")
            m_HasError = True
        End If
        Return Not m_HasError
    End Function
    Private Sub LoadSalesMatrix(ByVal ConfigtypeCode As String, ByVal TMCode As String)
        Table = GetRecords(InqueryValidationData.GetSalesMatrix(ConfigtypeCode, TMCode))
        GrdViewSalesMatrix.Rows.Clear()
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewSalesMatrix.Rows.AddNew
            rowinfo.Cells(0).Value = False
            rowinfo.Cells(1).Value = Table.Rows(i)("STSLSMNCD")
            rowinfo.Cells(2).Value = Table.Rows(i)("STSLSMNNAME")
            rowinfo.Cells(3).Value = Table.Rows(i)("STACOVNAME")
            rowinfo.Cells(4).Value = Format(Table.Rows(i)("EffectivityStartDate"), "MM/dd/yyyy")
            rowinfo.Cells(5).Value = Format(Table.Rows(i)("EffectivityEndDate"), "MM/dd/yyyy")
            txtTMCode_SalesMatrix.Text = Table.Rows(i)("STSLSMNCD")
        Next
    End Sub
    Private Sub LoadSharing(ByVal ConfigtypeCode As String, ByVal TMCode As String)
        Table = GetRecords(InqueryValidationData.GetSharing(ConfigtypeCode, TMCode))
        GrdViewSharing.Rows.Clear()
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewSharing.Rows.AddNew
            rowinfo.Cells(0).Value = False
            rowinfo.Cells(1).Value = Table.Rows(i)("STSLSMNCD")
            rowinfo.Cells(2).Value = Table.Rows(i)("STSLSMNNAME")
            rowinfo.Cells(3).Value = Table.Rows(i)("terrcd")
            rowinfo.Cells(4).Value = Table.Rows(i)("CUTYEAR")
            rowinfo.Cells(5).Value = Table.Rows(i)("CUTMO")
        Next
    End Sub
    Private Sub LoadFinal(ByVal ConfigtypeCode As String, ByVal TMCode As String)
        Table = GetRecords(InqueryValidationData.GetFinal(ConfigtypeCode, TMCode))
        GrdViewFinal.Rows.Clear()
        For i As Integer = 0 To Table.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewFinal.Rows.AddNew
            rowinfo.Cells(0).Value = False
            rowinfo.Cells(1).Value = Table.Rows(i)("Territory Manager Code")
            rowinfo.Cells(2).Value = Table.Rows(i)("Territory Manager Name")
            rowinfo.Cells(3).Value = Table.Rows(i)("Territory Code")
            rowinfo.Cells(4).Value = Table.Rows(i)("Territory Name")
            rowinfo.Cells(5).Value = Table.Rows(i)("Year")
            rowinfo.Cells(6).Value = Table.Rows(i)("Month")
        Next
    End Sub
    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub GrdViewSalesMatrix_CellBeginEdit(sender As Object, e As GridViewCellCancelEventArgs) Handles GrdViewSalesMatrix.CellBeginEdit
        SelectRecordSalesMatrix()
    End Sub
    Private Sub SelectRecordSalesMatrix()
        If GrdViewSalesMatrix.SelectedRows.Count > 0 Then
            strKeyColumn = GrdViewSalesMatrix.SelectedRows(0).Cells(0).Value
            If GrdViewSalesMatrix.ColumnCount > 1 Then
                txtTMCode_SalesMatrix.Text = GrdViewSalesMatrix.SelectedRows(0).Cells(1).Value
            Else
                txtTMCode_SalesMatrix.Text = String.Empty
            End If
            If GrdViewSalesMatrix.ColumnCount > 2 Then
                txtTMName_SalesMatrix.Text = GrdViewSalesMatrix.SelectedRows(0).Cells(2).Value
            Else
                txtTMName_SalesMatrix.Text = String.Empty
            End If
            If GrdViewSalesMatrix.ColumnCount > 3 Then
                txtTMArea_SalesMatrix.Text = GrdViewSalesMatrix.SelectedRows(0).Cells(3).Value
            Else
                txtTMArea_SalesMatrix.Text = String.Empty
            End If
        End If
    End Sub
    Private Sub SelectRecordSharing()
        If GrdViewSharing.SelectedRows.Count > 0 Then
            strKeyColumn = GrdViewSharing.SelectedRows(0).Cells(0).Value
            If GrdViewSharing.ColumnCount > 1 Then
                txtTMCode_Sharing.Text = GrdViewSharing.SelectedRows(0).Cells(1).Value
            Else
                txtTMCode_Sharing.Text = String.Empty
            End If
            If GrdViewSharing.ColumnCount > 2 Then
                txtTMName_Sharing.Text = GrdViewSharing.SelectedRows(0).Cells(2).Value
            Else
                txtTMName_Sharing.Text = String.Empty
            End If
            If GrdViewSharing.ColumnCount > 3 Then
                txtTM_TerritorySharing.Text = GrdViewSharing.SelectedRows(0).Cells(3).Value
            Else
                txtTM_TerritorySharing.Text = String.Empty
            End If
        End If
    End Sub
    Private Sub SelectRecordFinal()
        If GrdViewFinal.SelectedRows.Count > 0 Then
            strKeyColumn = GrdViewFinal.SelectedRows(0).Cells(0).Value
            If GrdViewFinal.ColumnCount > 1 Then
                txtTMCode_Final.Text = GrdViewFinal.SelectedRows(0).Cells(1).Value
            Else
                txtTMCode_Final.Text = String.Empty
            End If
            If GrdViewFinal.ColumnCount > 2 Then
                txtTMName_Final.Text = GrdViewFinal.SelectedRows(0).Cells(2).Value
            Else
                txtTMName_Final.Text = String.Empty
            End If
            If GrdViewFinal.ColumnCount > 3 Then
                txtTerritoryCode_Final.Text = GrdViewFinal.SelectedRows(0).Cells(3).Value
            Else
                txtTerritoryCode_Final.Text = String.Empty
            End If
            If GrdViewFinal.ColumnCount > 4 Then
                txtTerritoryAreaName_Final.Text = GrdViewFinal.SelectedRows(0).Cells(4).Value
            Else
                txtTerritoryAreaName_Final.Text = String.Empty
            End If
        End If
    End Sub

    Private Sub btnUpdateSalesMatrix_Click(sender As Object, e As EventArgs) Handles btnUpdateSalesMatrix.Click
        EditModeSalesMatrix(True)
    End Sub
    Private Function ValiDateSalesMatrix() As Boolean
        m_Err.Clear()
        m_HasError = False

        If txtTMCode_SalesMatrix.Text = "" Then
            m_Err.SetError(txtTMCode_SalesMatrix, "TM Code is required")
            m_HasError = True
        End If

        If txtTMName_SalesMatrix.Text = "" Then
            m_Err.SetError(txtTMName_SalesMatrix, "TM Name is required")
            m_HasError = True
        End If

        If txtTMArea_SalesMatrix.Text = "" Then
            m_Err.SetError(txtTMArea_SalesMatrix, "TM Area Name is required")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ValiDateSalesMatrix() Then
            For m As Integer = 0 To GrdViewSalesMatrix.Rows.Count - 1
                Dim rowinfo As GridViewRowInfo = GrdViewSalesMatrix.Rows(m)
                If rowinfo.Cells(0).Value = True Then
                    m_InqueryValidationData.TMName = txtTMName_SalesMatrix.Text
                    m_InqueryValidationData.TMAreaName = txtTMArea_SalesMatrix.Text
                    m_InqueryValidationData.TMCode = txtTMCode_SalesMatrix.Text
                    m_InqueryValidationData.ConfigtypeCode = cboConfigtype.Text
                    m_InqueryValidationData.EffectivityStartDate = rowinfo.Cells(4).Value
                    m_InqueryValidationData.EffectivityEndDate = rowinfo.Cells(5).Value
                    m_InqueryValidationData.UpdateSalesMatrix()
                End If
            Next
            ShowInformation("Record Successfully Update!", "Sales Matrix")
        End If
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles btnSaveSharing.Click
        If ValiDateSharing() Then
            For m As Integer = 0 To GrdViewSharing.Rows.Count - 1
                Dim rowinfo As GridViewRowInfo = GrdViewSharing.Rows(m)
                If rowinfo.Cells(0).Value = True Then
                    m_InqueryValidationData.TMName = txtTMName_Sharing.Text
                    m_InqueryValidationData.TMCode = txtTMCode_Sharing.Text
                    m_InqueryValidationData.TMTerritoryCode = txtTerritoryManagerCode.Text
                    m_InqueryValidationData.ConfigtypeCode = cboConfigtype.Text
                    m_InqueryValidationData.Year = rowinfo.Cells(4).Value
                    m_InqueryValidationData.Month = rowinfo.Cells(5).Value
                    m_InqueryValidationData.UpdateSharing()
                End If
            Next
            ShowInformation("Record Successfully Update!", "Sales Matrix")
        End If
    End Sub
    Private Function ValiDateSharing() As Boolean
        m_Err.Clear()
        m_HasError = False

        If txtTMCode_Sharing.Text = "" Then
            m_Err.SetError(txtTMCode_Sharing, "TM Code is required")
            m_HasError = True
        End If

        If txtTMName_Sharing.Text = "" Then
            m_Err.SetError(txtTMName_Sharing, "TM Name is required")
            m_HasError = True
        End If

        If txtTM_TerritorySharing.Text = "" Then
            m_Err.SetError(txtTM_TerritorySharing, "TM Territory Code is required")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function
    Private Function ValiDateFinal() As Boolean
        m_Err.Clear()
        m_HasError = False

        If txtTMCode_Final.Text = "" Then
            m_Err.SetError(txtTMCode_Final, "TM Code is required")
            m_HasError = True
        End If

        If txtTMName_Final.Text = "" Then
            m_Err.SetError(txtTMName_Final, "TM Name is required")
            m_HasError = True
        End If

        If txtTerritoryCode_Final.Text = "" Then
            m_Err.SetError(txtTerritoryCode_Final, "TM Territory Code is required")
            m_HasError = True
        End If

        If txtTerritoryAreaName_Final.Text = "" Then
            m_Err.SetError(txtTerritoryAreaName_Final, "TM Area Name is Required")
            m_HasError = True
        End If

        Return Not m_HasError
    End Function

    Private Sub GrdViewSharing_CellEndEdit(sender As Object, e As GridViewCellEventArgs) Handles GrdViewSharing.CellEndEdit
        SelectRecordSharing()
    End Sub

    Private Sub btnUpdateSharings_Click(sender As Object, e As EventArgs) Handles btnUpdateSharings.Click
        EditModeSharing(True)
    End Sub

    Private Sub btnSaveFinal_Click(sender As Object, e As EventArgs) Handles btnSaveFinal.Click
        If ValiDateFinal() Then
            For m As Integer = 0 To GrdViewFinal.Rows.Count - 1
                Dim rowinfo As GridViewRowInfo = GrdViewFinal.Rows(m)
                If rowinfo.Cells(0).Value = True Then
                    m_InqueryValidationData.TMName = txtTMName_Final.Text
                    m_InqueryValidationData.TMCode = txtTMCode_Final.Text
                    m_InqueryValidationData.TMTerritoryCode = txtTerritoryCode_Final.Text
                    m_InqueryValidationData.TMAreaName = txtTerritoryAreaName_Final.Text
                    m_InqueryValidationData.ConfigtypeCode = cboConfigtype.Text
                    m_InqueryValidationData.Year = rowinfo.Cells(5).Value
                    m_InqueryValidationData.Month = rowinfo.Cells(6).Value
                    m_InqueryValidationData.UpdateFinal()
                End If
            Next
            ShowInformation("Record Successfully Update!", "Sales Matrix")
        End If
    End Sub

    Private Sub GrdViewFinal_CellEndEdit(sender As Object, e As GridViewCellEventArgs) Handles GrdViewFinal.CellEndEdit
        SelectRecordFinal()
    End Sub

    Private Sub btnUpdateFinal_Click(sender As Object, e As EventArgs) Handles btnUpdateFinal.Click
        EditModeFinal(True)
    End Sub

    Private Sub MasterTemplate_Click(sender As Object, e As EventArgs) Handles GrdViewSalesMatrix.Click

    End Sub
End Class
