Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Public Class SearchDialog
    Private m_Query As String = String.Empty
    Private m_Selected As SelectionTag
    Private m_Cache As DataTable
    Private dt As New DataTable
    Private strTableName As String = ""
    Private strColumns As String = ""
    Private strCondition As String = ""
    Private strQuery As String = ""
    Private strKeyColumn As String = ""
    Private strKeyColumn1 As String = ""
    Private strKeyColumn2 As String = ""
    Private strKeyColumn3 As String = "'"
    Private strKeyColumn4 As String = "'"
    'Public Sub New()

    '    ' This call is required by the designer.
    '    InitializeComponent()

    '    Me.GrdView.EnableHotTracking = True
    '    Me.GrdView.ShowFilteringRow = False
    '    Me.GrdView.EnableFiltering = True
    '    Me.GrdView.EnableCustomFiltering = True

    '    ' Add any initialization after the InitializeComponent() call.
    'End Sub

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

    Public ReadOnly Property Keycolumn3() As String
        Get
            Return strKeyColumn3
        End Get
    End Property
    Public ReadOnly Property Keycolumn4() As String
        Get
            Return strKeyColumn4
        End Get
    End Property

    Friend ReadOnly Property Selected() As SelectionTag
        Get
            Return m_Selected
        End Get
    End Property

    Friend Property SearchTitle() As String
        Get
            Return Label1.Text
        End Get
        Set(ByVal value As String)
            Label1.Text = value
        End Set
    End Property

    Friend Property Query() As String
        Get
            Return m_Query
        End Get
        Set(ByVal value As String)
            m_Query = value
        End Set
    End Property
    Private Sub SearchDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.GrdView.TableElement.RowHeight = 35
        GetRecords()
    End Sub
    Public Sub GetRecords()
        m_Cache = ConnectionModule.GetRecords(m_Query)
        GrdView.DataSource = m_Cache
        GrdView.Columns(0).IsVisible = False
        GrdView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill
    End Sub
    Private Sub RadButton2_Click(sender As Object, e As EventArgs) Handles RadButton2.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        SelectRecord()
    End Sub
    Private Sub SelectRecord()
        If GrdView.SelectedRows.Count > 0 Then
            strKeyColumn = GrdView.SelectedRows(0).Cells(0).Value
            If GrdView.ColumnCount > 1 Then
                strKeyColumn1 = GrdView.SelectedRows(0).Cells(1).Value
            Else
                strKeyColumn1 = ""
            End If
            If GrdView.ColumnCount > 2 Then
                strKeyColumn2 = GrdView.SelectedRows(0).Cells(2).Value
            Else
                strKeyColumn2 = ""
            End If
            If GrdView.ColumnCount > 3 Then
                strKeyColumn3 = GrdView.SelectedRows(0).Cells(3).Value
            Else
                strKeyColumn3 = ""
            End If
            If GrdView.ColumnCount > 4 Then
                strKeyColumn4 = GrdView.SelectedRows(0).Cells(4).Value
            Else
                strKeyColumn4 = ""
            End If
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
    Private Sub txtFilterBox_TextChanged(sender As Object, e As EventArgs)
        Me.GrdView.MasterTemplate.Refresh()
    End Sub
    Private Sub GrdView_CellDoubleClick1(sender As Object, e As GridViewCellEventArgs) Handles GrdView.CellDoubleClick
        SelectRecord()
    End Sub
    Private Sub GrdView_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GrdView.KeyPress
        Select Case e.KeyChar
            Case Convert.ToChar(Windows.Forms.Keys.Enter)
                SelectRecord()
            Case Convert.ToChar(Windows.Forms.Keys.Escape)
                DialogResult = Windows.Forms.DialogResult.Cancel
        End Select
    End Sub
End Class