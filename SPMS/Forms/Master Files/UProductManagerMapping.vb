Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Text.RegularExpressions
Imports Telerik.WinControls.Enumerations
Public Class UProductManagerMapping
    Private m_Product As New ProductManager

    Private m_HasError As Boolean = False
    Private m_IsNewMode As Boolean = True

    Private m_RsItem As New ADODB.Recordset
    Public Sub New()
        InitializeComponent()
        Me.gridviewCustomer.EnableHotTracking = False
        Me.gridviewCustomer.ShowFilteringRow = True
        Me.gridviewCustomer.EnableFiltering = True
        Me.gridviewCustomer.EnableCustomFiltering = False

        Me.GridviewproductManager.EnableHotTracking = False
        Me.GridviewproductManager.ShowFilteringRow = True
        Me.GridviewproductManager.EnableFiltering = True
        Me.GridviewproductManager.EnableCustomFiltering = False

    End Sub

    Dim dt As SqlDataReader

    Private m_IsAction As Boolean = True
    Private m_Action As String = String.Empty

    Private m_Err As New ErrorProvider

    Private _MotherCode As String = String.Empty
    Private _MotherName As String = String.Empty
    Private _Address As String = String.Empty

    Private _ProductManagerCode As String = String.Empty
    Private _ProductMangerName As String = String.Empty

    Private strCondition As String = String.Empty
    Private strTableName As String = String.Empty

    Private Codes As String = String.Empty
    Private Names As String = String.Empty
    Private Enum EnumAction
        ADD = 1
        Update = 2
        Delete = 3
        Remove = 4
    End Enum
    Private Sub Clear()
        LoadViewUnMotherAccount(txtPM_ID.Text)
        LoadViewProductManagerMapping(txtPM_ID.Text)
    End Sub
    Private Sub loadtext2()
        txtPM_ID.ReadOnly = False
        txtPm_Name.ReadOnly = False
    End Sub
    Private Property MotherCode As String
        Get
            Return _MotherCode
        End Get
        Set(value As String)
            _MotherCode = value
        End Set
    End Property
    Private Property MotherName As String
        Get
            Return _MotherName
        End Get
        Set(value As String)
            _MotherName = value
        End Set
    End Property
    Private Property ProductManagerCode As String
        Get
            Return _ProductManagerCode
        End Get
        Set(value As String)
            _ProductManagerCode = value
        End Set
    End Property
    Private Property ProductManagerName As String
        Get
            Return _ProductMangerName
        End Get
        Set(value As String)
            _ProductMangerName = value
        End Set
    End Property

    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnAdd.Enabled = Not IsEditMode
    End Sub
    Private Sub EditMode1(ByVal IsEditMode As Boolean)
        btnSave.Enabled = Not IsEditMode
        btnAdd.Enabled = Not IsEditMode
    End Sub
    Private Sub loadtext()
        txtPM_ID.ReadOnly = True
        txtPm_Name.ReadOnly = True
    End Sub

    Private Sub UProductManagerMapping_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadViewProductManager()
        EditMode1(True)
        Me.GridviewproductManager.TableElement.RowHeight = 35
        gridvieConvertMotherAccount.TableElement.RowHeight = 35
        gridviewCustomer.TableElement.RowHeight = 35
        ''GridviewproductManager.EnableAlternatingRowColor = True
        GridviewproductManager.Columns(1).Width = 100
        GridviewproductManager.Columns(2).Width = 500
        GridviewproductManager.Columns(3).Width = 150
        GridviewproductManager.Columns(4).Width = 150
        GridviewproductManager.Columns(5).Width = 50
        GridviewproductManager.Columns(1).ReadOnly = True
        GridviewproductManager.Columns(2).ReadOnly = True
        GridviewproductManager.Columns(3).ReadOnly = True
        GridviewproductManager.Columns(4).ReadOnly = True
        GridviewproductManager.Columns(5).ReadOnly = True
        Me.GridviewproductManager.Columns(0).IsVisible = False
        Me.GridviewproductManager.MasterTemplate.EnableSorting = True
        'UpperCaseTextbox()
    End Sub
    Private Sub LoadViewProductManager()
        Try
            Connect()
            Dim cmd As SqlCommand = New SqlCommand("Select * from ProductManagers where isActive = 1", SPMSConn2)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Clear()

            da.Fill(dt)

            GridviewproductManager.DataSource = dt
            Disconnect()

        Catch ex As Exception
            ShowInformation(ex.Message, "Search error")
        End Try
    End Sub
    Private Function LoadViewProductManagerMapping(ByVal ProductManagerCode As String) As Boolean
        Try
            Connect()
            Dim cmd As SqlCommand = New SqlCommand("Select itemthr[Item Mother Code],IMDBRN [Item Mother Description] from Item where itemdel = 0 and  itemthr in(select Item_Mother_code from ProductManagersMapping where Pm_ID ='" & ProductManagerCode & "') Group by Itemthr,IMDBRN ", SPMSConn2)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Clear()

            da.Fill(dt)

            gridvieConvertMotherAccount.DataSource = dt
            Disconnect()
            Me.GridviewproductManager.MasterTemplate.EnableSorting = True
            gridvieConvertMotherAccount.EnableAlternatingRowColor = True
            gridvieConvertMotherAccount.Columns(0).Width = 100
            gridvieConvertMotherAccount.Columns(1).Width = 350
            gridvieConvertMotherAccount.Columns(0).ReadOnly = True
            gridvieConvertMotherAccount.Columns(1).ReadOnly = True
        Catch ex As Exception
            ShowInformation(ex.Message, "Search error")
        End Try
    End Function
    Private Function LoadViewUnMotherAccount(ByVal productCode As String) As Boolean
        Try
            Connect()
            Dim cmd As SqlCommand = New SqlCommand("SELECT  Distinct itemthr [Item Mother Code] ,IMDBRN [Item Mother Description] From Item  Where Itemdel = 0 and  itemthr NOT IN (SELECT  Item_Mother_code FROM ProductManagersMapping where Pm_ID ='" & productCode & "')  GROUP BY itemthr,IMDBRN", SPMSConn2)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Clear()

            da.Fill(dt)

            gridviewCustomer.DataSource = dt
            Disconnect()


            gridviewCustomer.EnableAlternatingRowColor = True
            gridviewCustomer.Columns(1).Width = 150
            gridviewCustomer.Columns(2).Width = 1000
            gridviewCustomer.Columns(1).ReadOnly = True
            gridviewCustomer.Columns(2).ReadOnly = True
        Catch ex As Exception
            ShowInformation(ex.Message, "Search error")
        End Try
    End Function

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        If String.IsNullOrEmpty(txtPm_Name.Text) = True Then
            RadMessageBox.SetThemeName("TelerikMetroBlue")
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Please Entry the Product Manager Name", "Erro", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        Else
            For i As Integer = 0 To gridviewCustomer.RowCount - 1 Step +1
                Dim rowAlreadyExist As Boolean = False
                Dim check As Boolean = gridviewCustomer.Rows(i).Cells(0).Value
                Dim row As GridViewRowInfo = gridviewCustomer.Rows(i)
                If check = True Then
                    Dim rowinfo As GridViewRowInfo = gridvieConvertMotherAccount.Rows.AddNew
                    rowinfo.Cells(0).Value = row.Cells(1).Value
                    rowinfo.Cells(1).Value = row.Cells(2).Value
                End If
            Next
        End If
        GridViewCustomerRemoveSelected()
    End Sub
    Private Sub GridViewCustomerRemoveSelected()
        Dim selectedRows = gridviewCustomer.SelectedRows.ToArray()
        For s As Integer = selectedRows.Length - 1 To 0 Step -1
            Dim row = selectedRows(s)
            ' do something else maybe here
            gridviewCustomer.Rows.Remove(row)
        Next
    End Sub
    Private Sub gridviewCustomer_CellClick(sender As Object, e As GridViewCellEventArgs) Handles gridviewCustomer.CellClick
        If e.RowIndex = -1 Then Exit Sub
        Dim row As GridViewRowInfo = gridviewCustomer.Rows(e.RowIndex)
        row.Cells(0).Value = ToggleState.On
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        m_IsAction = True
        m_Product = New ProductManager
        EditMode(True)
        loadtext2()
    End Sub

    Private Sub GridviewproductManager_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles GridviewproductManager.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Dim row As GridViewRowInfo = GridviewproductManager.Rows(e.RowIndex)
        If Not CheckIfItemExist(row.Cells(1).Value) Then
            If m_RsItem.State = 1 Then m_RsItem.Close()
            m_RsItem.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            m_RsItem.Open("Select * from ProductManagers WHERE IsActive = 1 AND PM_ID  = '" & row.Cells(1).Value & "' ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            If m_RsItem.RecordCount > 0 Then
                ShowData(m_RsItem)
            End If
        End If
    End Sub
    Private Sub ShowData(ByVal rs As ADODB.Recordset)
        loadtext()
        m_IsNewMode = False
        txtPM_ID.Text = rs.Fields("PM_ID").Value
        txtPm_Name.Text = rs.Fields("PM_Name").Value
        loadtext()
        EditMode(True)
        LoadViewUnMotherAccount(txtPM_ID.Text)
        LoadViewProductManagerMapping(txtPM_ID.Text)
        MainTab.SelectTab(0)
    End Sub
    Private Function CheckIfItemExist(ByVal ItemCode As String) As Boolean
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("Select * from ProductManagers where PM_ID = '" & ItemCode & "'  AND  IsActive = 1", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount = 0 Then
            Return True
        End If
        Return False
    End Function
    Private Sub GridviewproductManager_Click(sender As Object, e As EventArgs) Handles GridviewproductManager.Click

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ValidatingDataEntry() Then
            SaveData()
            EditMode(False)
            Clear()
        End If
    End Sub
    Private Function SaveData() As Boolean
        Try
            If gridvieConvertMotherAccount.RowCount = 0 Then
                If m_IsAction Then
                    m_Action = EnumAction.ADD.ToString
                    For m As Integer = 0 To gridvieConvertMotherAccount.RowCount - 1
                        Dim row As GridViewRowInfo = gridvieConvertMotherAccount.Rows(m)
                        Connect()
                        Dim cmd As SqlCommand = New SqlCommand("uspProductManagersMapping", SPMSConn2)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@ACTION", m_Action)
                        cmd.Parameters.AddWithValue("@PM_ID", txtPM_ID.Text)
                        cmd.Parameters.AddWithValue("@PM_Name", txtPm_Name.Text)
                        cmd.Parameters.AddWithValue("@ITEMMOTHERCODE", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@ITEMMOTHERNAME", row.Cells(1).Value)
                        cmd.ExecuteNonQuery()
                    Next
                    Disconnect()
                End If
                RadMessageBox.SetThemeName("TelerikMetroBlue")
                Dim ds As DialogResult = RadMessageBox.Show(Me, "Successfully Update", "Update", MessageBoxButtons.OK, RadMessageIcon.Info)
            Else
                Delete(txtPM_ID.Text)
                If m_IsAction Then
                    m_Action = EnumAction.Update.ToString
                    For m As Integer = 0 To gridvieConvertMotherAccount.RowCount - 1
                        Dim row As GridViewRowInfo = gridvieConvertMotherAccount.Rows(m)
                        Connect()
                        Dim cmd As SqlCommand = New SqlCommand("uspProductManagersMapping", SPMSConn2)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@ACTION", m_Action)
                        cmd.Parameters.AddWithValue("@PM_ID", txtPM_ID.Text)
                        cmd.Parameters.AddWithValue("@PM_Name", txtPm_Name.Text)
                        cmd.Parameters.AddWithValue("@ITEMMOTHERCODE", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@ITEMMOTHERNAME", row.Cells(1).Value)
                        cmd.ExecuteNonQuery()
                    Next
                    Disconnect()
                    RadMessageBox.SetThemeName("TelerikMetroBlue")
                    Dim ds As DialogResult = RadMessageBox.Show(Me, "Successfully Update", "Update", MessageBoxButtons.OK, RadMessageIcon.Info)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function ValidatingDataEntry() As Boolean
        m_Err.Clear()
        m_HasError = False
        If txtPM_ID.Text = String.Empty Then
            Dim errorMessage As String = "Please Entry The Product manager code"
            m_Err.SetError(txtPM_ID, errorMessage)
            m_HasError = True
            txtPM_ID.Focus()
        End If
        If txtPm_Name.Text = String.Empty Then
            Dim errorMessage As String = "Please Entry the Product manager name"
            m_Err.SetError(txtPm_Name, errorMessage)
            m_HasError = True
            txtPm_Name.Focus()
        End If
        Return Not m_HasError
    End Function
    Private Function Delete(ByVal ProductManagerCode As String)
        If m_IsAction Then
            m_Action = EnumAction.Delete.ToString
            Connect()
            Try
                Dim cmd As SqlCommand = New SqlCommand("uspProductManagersMapping", SPMSConn2)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@ACTION", m_Action)
                cmd.Parameters.AddWithValue("@PM_ID", ProductManagerCode)
                cmd.ExecuteNonQuery()
                Disconnect()
            Catch ex As System.Exception
                Throw
            End Try
        End If
    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If _ProductManagerCode <> "" Then
            RadMessageBox.SetThemeName("TelerikMetroBlue")
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Do want to Remove this Product Item", "Remove", MessageBoxButtons.YesNo, RadMessageIcon.Question)
            If ds = Windows.Forms.DialogResult.Yes Then
                RemoveNotUntherMotherAccount()
            End If
        Else
            RadMessageBox.SetThemeName("TelerikMetroBlue")
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Not Selected Remove", "Erro Remove", MessageBoxButtons.OK, RadMessageIcon.Error)
        End If
    End Sub
    Private Function RemoveNotUntherMotherAccount() As Boolean
        Connect()
        Try
            If m_IsAction Then
                m_Action = EnumAction.Remove.ToString
                Dim cmd As SqlCommand = New SqlCommand("uspProductManagersMapping", SPMSConn2)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@ACTION", m_Action)
                cmd.Parameters.AddWithValue("@ITEMMOTHERCODE", ProductManagerCode)
                cmd.ExecuteNonQuery()
                Disconnect()
                RadMessageBox.SetThemeName("TelerikMetroBlue")
                Dim ds As DialogResult = RadMessageBox.Show(Me, "Successfully Remove", "Remove Selected", MessageBoxButtons.OK, RadMessageIcon.Info)
                If gridvieConvertMotherAccount.RowCount = -1 Then Exit Function
                gridvieConvertMotherAccount.Rows.Remove(gridvieConvertMotherAccount.CurrentRow)
                gridvieConvertMotherAccount.Refresh()
                'Clear()
                Return True
            End If
        Catch ex As System.Exception
            Throw
        End Try
    End Function
    Private Sub gridvieConvertMotherAccount_CellClick(sender As Object, e As GridViewCellEventArgs) Handles gridvieConvertMotherAccount.CellClick
        If e.RowIndex = -1 Then Exit Sub
        Dim row As GridViewRowInfo = gridvieConvertMotherAccount.Rows(e.RowIndex)
        _ProductManagerCode = row.Cells(0).Value
    End Sub

    Private Sub gridviewCustomer_Click(sender As Object, e As EventArgs) Handles gridviewCustomer.Click

    End Sub


End Class
