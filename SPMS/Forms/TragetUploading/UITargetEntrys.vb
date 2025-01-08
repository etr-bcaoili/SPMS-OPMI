Imports SPMSOPCI.InformationMessagesModule
Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.Dialogs
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports Telerik.WinControls.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class UITargetEntrys
    Dim table As New DataTable

    Private _TargetData As New Target

    Private _TargetSales As New TargerSales

    Private m_ItemCode As String = String.Empty

    Private m_ItemDivisionCode As String = String.Empty

    Private m_SalesCode As String = String.Empty

    Private m_Config As String = String.Empty

    Private m_Err As New ErrorProvider

    Private m_HasError As Boolean = False
    Private Property ItemCode As String
        Get
            Return m_ItemCode
        End Get
        Set(value As String)
            m_ItemCode = value
        End Set
    End Property
    Public Property ItemDivisionCode As String
        Get
            Return m_ItemDivisionCode
        End Get
        Set(value As String)
            m_ItemDivisionCode = value
        End Set
    End Property

    Private Property Config As String
        Get
            Return m_Config
        End Get
        Set(value As String)
            m_Config = value
        End Set
    End Property

    Private Sub EditMode(ByVal IsEditMode As Boolean)
        btnSave.Enabled = IsEditMode
        btnUpdate.Enabled = Not IsEditMode




        txtItemCode.ReadOnly = Not IsEditMode
        txtItemCode.BackColor = Color.White

        txtItemDesc.ReadOnly = Not IsEditMode
        txtItemDesc.BackColor = Color.White

        txtItemDivisionname.ReadOnly = Not IsEditMode
        txtItemDivisionname.BackColor = Color.White

        'txtSalesmanname.ReadOnly = Not IsEditMode
        'txtSalesmanname.BackColor = Color.White

    End Sub
    Private Sub Clear()
        txtItemCode.Text = String.Empty
        txtItemDesc.Text = String.Empty
        txtItemDivisionname.Text = String.Empty
        txtConfig.Text = String.Empty
        GrdViewTM.DataSource = Nothing
        cboCalendarYear.Text = String.Empty
    End Sub

    Private Sub Close()
        On Error Resume Next
        Dim m_TabPage As TabPage = Me.Parent
        CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
        Me.Dispose()
    End Sub
    Private Sub Find()
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Distributor.GetDistributorSql, "Distributor")
        If Not tag Is Nothing Then
            Clear()
            ShowData(tag.KeyColumn11)
            EditMode(False)
        End If
    End Sub
    Private Sub ShowData(ByVal RecordCode As String)
        'Clear()
        'If RecordCode < 1 Then Exit Sub

        '_Distributor = Distributor.Load(RecordCode)
        'txtChannelCode.Tag = _Distributor.DISTRIBUTORID
        'txtChannelCode.Text = _Distributor.DISTCOMID
        'txtDistributor.Text = _Distributor.DISTNAME
        'txtAddress.Text = _Distributor.ADDR
        'EditMode(False)
    End Sub
    Private Sub Delete()
        If ShowDeleteDialog() = MsgBoxResult.Yes Then
            'If _Distributor.Delete Then
            '    DeleteSuccess()
            '    NewRecord()
            'Else
            '    UnDeleteSuccess()
            'End If
        End If
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint

    End Sub

    Private Sub Panel8_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub GrdViewTM_CellClick(sender As Object, e As GridViewCellEventArgs)
        table = GetRecords(Target.GetTargetCollection(m_ItemCode, m_ItemDivisionCode, m_Config))

    End Sub

    Private Sub GrdViewTM_RowsChanged(sender As Object, e As GridViewCollectionChangedEventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Target.GetConfigurationSql, "Target Configuration")
        If Not tag Is Nothing Then
            txtConfig.Text = tag.KeyColumn33
            m_Config = tag.KeyColumn22
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim tag As SelectionTags = Dialogs.ShowSearchDialog(Items.GetItemTargetSql, "Item Target")
        If Not tag Is Nothing Then
            txtItemCode.Text = tag.KeyColumn22
            m_ItemCode = tag.KeyColumn22
            txtItemDesc.Text = tag.KeyColumn33
            txtItemDivisionname.Text = tag.KeyColumn44
            m_ItemDivisionCode = tag.KeyColumn44
            table = GetRecords(Target.GetTargetCollection(m_ItemCode, m_ItemDivisionCode, m_Config))
            If table.Rows.Count = 0 Then
                GrdViewTM.DataSource = Nothing
                LoadSalesMatrix(m_ItemDivisionCode, m_Config)
            Else
                GrdViewTM.DataSource = Nothing
                LoadTargetList(m_ItemCode, m_ItemDivisionCode, m_Config)
            End If
        End If
    End Sub
    Private Function LoadSalesMatrix(ByVal ItemDivisionCode As String, ByVal Config As String) As Boolean
        Try
            Connect()
            Dim cmd As SqlCommand = New SqlCommand("uspTargetPerConfig_NewItem", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ItemDivisionCode", ItemDivisionCode)
            cmd.Parameters.AddWithValue("@Config", Config)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable

            da.Fill(dt)

            GrdViewTM.DataSource = dt
            Disconnect()
            GrdViewTM.EnableAlternatingRowColor = True
            '  GrdTripCollectionPivot.Columns(0).FormatString = "{0:d}"
            GrdViewTM.Columns(0).Width = 100
            GrdViewTM.Columns(1).Width = 150
            GrdViewTM.Columns(2).Width = 70
            GrdViewTM.Columns(3).Width = 70
            GrdViewTM.Columns(4).Width = 70
            GrdViewTM.Columns(5).Width = 70
            GrdViewTM.Columns(6).Width = 70
            GrdViewTM.Columns(7).Width = 70
            GrdViewTM.Columns(8).Width = 70
            GrdViewTM.Columns(9).Width = 70
            GrdViewTM.Columns(10).Width = 70
            GrdViewTM.Columns(11).Width = 70
            GrdViewTM.Columns(12).Width = 70
            GrdViewTM.Columns(13).Width = 70
            GrdViewTM.Columns(14).Width = 70
            GrdViewTM.Columns(15).Width = 70
            GrdViewTM.Columns(16).Width = 70
            GrdViewTM.Columns(17).Width = 70
            GrdViewTM.Columns(18).Width = 70
            GrdViewTM.Columns(19).Width = 70
            GrdViewTM.Columns(20).Width = 70
            GrdViewTM.Columns(21).Width = 70
            GrdViewTM.Columns(22).Width = 70
            GrdViewTM.Columns(23).Width = 70
            GrdViewTM.Columns(24).Width = 70
            GrdViewTM.Columns(25).Width = 70
            GrdViewTM.Columns(26).Width = 70
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function LoadTargetList(ByVal ItemCode As String, ByVal ItemDivisionCode As String, ByVal Config As String) As Boolean
        Try
            Connect()
            Dim cmd As SqlCommand = New SqlCommand("uspTargetPerConfig", SPMSConn2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
            cmd.Parameters.AddWithValue("@ItemDivisionCode", ItemDivisionCode)
            cmd.Parameters.AddWithValue("@ConfigCode", Config)

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Clear()

            da.Fill(dt)

            GrdViewTM.DataSource = dt
            Disconnect()
            GrdViewTM.EnableAlternatingRowColor = True
            '  GrdTripCollectionPivot.Columns(0).FormatString = "{0:d}"
            GrdViewTM.Columns(0).Width = 100
            GrdViewTM.Columns(1).Width = 150
            GrdViewTM.Columns(2).Width = 70
            GrdViewTM.Columns(3).Width = 70
            GrdViewTM.Columns(4).Width = 70
            GrdViewTM.Columns(5).Width = 70
            GrdViewTM.Columns(6).Width = 70
            GrdViewTM.Columns(7).Width = 70
            GrdViewTM.Columns(8).Width = 70
            GrdViewTM.Columns(9).Width = 70
            GrdViewTM.Columns(10).Width = 70
            GrdViewTM.Columns(11).Width = 70
            GrdViewTM.Columns(12).Width = 70
            GrdViewTM.Columns(13).Width = 70
            GrdViewTM.Columns(14).Width = 70
            GrdViewTM.Columns(15).Width = 70
            GrdViewTM.Columns(16).Width = 70
            GrdViewTM.Columns(17).Width = 70
            GrdViewTM.Columns(18).Width = 70
            GrdViewTM.Columns(19).Width = 70
            GrdViewTM.Columns(20).Width = 70
            GrdViewTM.Columns(21).Width = 70
            GrdViewTM.Columns(22).Width = 70
            GrdViewTM.Columns(23).Width = 70
            GrdViewTM.Columns(24).Width = 70
            GrdViewTM.Columns(25).Width = 70
            GrdViewTM.Columns(26).Width = 70
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ValiDateData() Then
            SaveRecord()
            Clear()
            EditMode(False)
            GrdViewTM.ReadOnly = True
        End If
    End Sub
    Private Sub SaveRecord()

        For m As Integer = 0 To GrdViewTM.Rows.Count - 1
            Dim rowinfo As GridViewRowInfo = GrdViewTM.Rows(m)
            _TargetSales = New TargerSales
            _TargetSales.EmployeeID = rowinfo.Cells(0).Value
            _TargetSales.EmployeeName = rowinfo.Cells(1).Value
            _TargetSales.ItemCodeDivision = m_ItemDivisionCode
            _TargetSales.ConfigtypeCode = m_Config
            _TargetSales.ItemCode = m_ItemCode
            _TargetSales.ItemName = txtItemDesc.Text
            _TargetSales.CutYear = cboCalendarYear.Text
            _TargetSales.CompanyCode = "OPCI"
            _TargetSales.TerretoryCode = rowinfo.Cells(0).Value
            _TargetSales.QuantityTagetJanuary = rowinfo.Cells(3).Value
            _TargetSales.SalesTargetJanuary = rowinfo.Cells(4).Value
            _TargetSales.QuantitytargetFebrary = rowinfo.Cells(5).Value
            _TargetSales.SalesTargetFebrary = rowinfo.Cells(6).Value
            _TargetSales.QuantityTagetMarch = rowinfo.Cells(7).Value
            _TargetSales.SaleTagetMarch = rowinfo.Cells(8).Value
            _TargetSales.QuantityTargetApril = rowinfo.Cells(9).Value
            _TargetSales.SaleTargerApril = rowinfo.Cells(10).Value
            _TargetSales.QuantityTargetMay = rowinfo.Cells(11).Value
            _TargetSales.SaleTargetMay = rowinfo.Cells(12).Value
            _TargetSales.QuantityTargerJune = rowinfo.Cells(13).Value
            _TargetSales.SaleTargetJune = rowinfo.Cells(14).Value
            _TargetSales.QuantityTargetJuly = rowinfo.Cells(15).Value
            _TargetSales.SalesTargetJuly = rowinfo.Cells(16).Value
            _TargetSales.QuantityTargetAugust = rowinfo.Cells(17).Value
            _TargetSales.SaleTargetAugust = rowinfo.Cells(18).Value
            _TargetSales.QuantityTargetSeptember = rowinfo.Cells(19).Value
            _TargetSales.SaleTargetSeptember = rowinfo.Cells(20).Value
            _TargetSales.QuantityTargetOctober = rowinfo.Cells(21).Value
            _TargetSales.SaleTargetOctober = rowinfo.Cells(22).Value
            _TargetSales.QuantityTargetNovember = rowinfo.Cells(23).Value
            _TargetSales.SalesTargetNovember = rowinfo.Cells(24).Value
            _TargetSales.QuantityTargetDecember = rowinfo.Cells(25).Value
            _TargetSales.Salestragetdecember = rowinfo.Cells(26).Value
            _TargetSales.Save()
        Next

        SPMSConn.Execute("Exec usProcessuploading")
        MessageBox.Show("Successfully Save Target!")
    End Sub
    Private Function ValiDateData() As Boolean
        m_Err.Clear()
        m_HasError = False

        If txtConfig.Text = "" Then
            m_Err.SetError(txtConfig, "Configuration is Required!")
            m_HasError = True
        End If
        If txtItemCode.Text = "" Then
            m_Err.SetError(txtItemDesc, "Item is Required!")
            m_HasError = True
        End If
        If txtItemDivisionname.Text = "" Then
            m_Err.SetError(txtItemDivisionname, "Item Division Code is Required!")
            m_HasError = True
        End If

        If GrdViewTM.RowCount = 0 Then
            MessageBox.Show("No Data Table is Empty", "Invalid Save", MessageBoxButtons.OK, MessageBoxIcon.Error)
            m_HasError = True
        Else
            If TargerSales.CheckIfDataExist(txtItemCode.Text, m_ItemDivisionCode, m_Config) Then
                TargerSales.CheckDeleteTargetPerItemExist(txtItemCode.Text, m_ItemDivisionCode, m_Config)
                m_HasError = False
            End If
        End If
       
        Return Not m_HasError
    End Function

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        GrdViewTM.ReadOnly = False
        EditMode(True)
    End Sub

    Private Sub LoadYear()
        Dim rs As New ADODB.Recordset
        If rs.State = 1 Then rs.Close()
        rs.Open("SELECT DISTINCT CAYR FROM CALENDAR  ", SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        cboCalendarYear.Items.Clear()
        For m As Integer = 0 To rs.RecordCount - 1
            cboCalendarYear.Items.Add(rs.Fields("CAYR").Value)
            rs.MoveNext()
        Next
    End Sub

    Private Sub UITargetEntrys_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadYear()
        EditMode(False)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clear()
        EditMode(False)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class
