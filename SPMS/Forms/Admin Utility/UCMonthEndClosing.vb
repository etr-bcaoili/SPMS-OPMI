Imports SPMSOPCI.ConnectionModule
Imports SPMSOPCI.ErrorMessagesModule
Imports SPMSOPCI.InformationMessagesModule

Public Class UCMonthEndClosing

    Private Sub UCMonthEndClosing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearForm()
        PopulateBoxes()
    End Sub

    Private Sub ClearForm()
        cmbchannel.Items.Clear()
        cmbchannelname.Items.Clear()

        cmbchannel.Text = ""
        cmbchannelname.Text = ""



    End Sub

    Private Sub PopulateBoxes()
        Dim rs As New ADODB.Recordset
        cmbchannel.Items.Clear()
        cmbchannelname.Items.Clear()

        ' for the distributor
        rs = rsDistributor()
        cmbchannel.Items.Add("All")

        If rs.RecordCount > 0 Then
            For i As Integer = 1 To rs.RecordCount
                cmbchannel.Items.Add(rs.Fields("DistComID").Value)
                cmbchannelname.Items.Add(rs.Fields("DistName").Value)

                rs.MoveNext()
            Next
        End If


    End Sub

    Private Function rsDistributor(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT * FROM DISTRIBUTOR WHERE DLTFLG = 0" & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        Return rs
    End Function

    Private Function rsCustDiv(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " AND " & Filter
        End If

        rs.Open("SELECT * FROM CUST_DIV_ITEM_SALES WHERE ISACTIVE = 1 " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


        Return rs
    End Function

    Private Sub cmbchannel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbchannel.SelectedIndexChanged, cmbchannelname.SelectedIndexChanged, cmbYear.SelectedIndexChanged, cmbmonth.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
        If sender Is cmbchannel Then
            rs = rsDistributor(" distcomid = '" & cmbchannel.Text & "' ")
            cmbmonth.Items.Clear()
            cmbYear.Items.Clear()
            cmbmonth.Text = ""
            cmbYear.Text = ""
            If rs.RecordCount > 0 Then
                cmbchannelname.Text = rs.Fields("distname").Value

                rs = RsDistinctMonth(" COMID = '" & cmbchannel.Text & "' ")
                If rs.RecordCount > 0 Then
                    For i As Integer = 1 To rs.RecordCount
                        cmbmonth.Items.Add(rs.Fields("CUTMO").Value)
                        rs.MoveNext()
                    Next
                End If

                rs = RsDistinctYear(" COMID = '" & cmbchannel.Text & "'")
                If rs.RecordCount > 0 Then
                    For i As Integer = 1 To rs.RecordCount
                        cmbYear.Items.Add(rs.Fields("CUTYEAR").Value)
                        rs.MoveNext()
                    Next
                End If
            End If
        ElseIf sender Is cmbchannelname Then
            rs = rsDistributor(" distname = '" & cmbchannelname.Text & "' ")
            If rs.RecordCount > 0 Then
                cmbchannel.Text = rs.Fields("distcomid").Value
            End If
        End If

    End Sub

    Private Sub ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfinalize.Click, btnClose.Click
        Dim rs As New ADODB.Recordset
        If sender Is btnfinalize Then
            If ValidFields() = True Then
                If ConfirmCloseofTransaction() = MsgBoxResult.Yes Then
                    If cmbchannel.Text <> "All" Then
                        SPMSConn.Execute("UPDATE CUST_DIV_ITEM_SALES SET TRXFLG = 1 WHERE COMID = '" & cmbchannel.Text & "' AND CUTMO = '" & cmbmonth.Text & "' AND CUTYEAR = '" & cmbYear.Text & "' ")
                    Else
                        SPMSConn.Execute("UPDATE CUST_DIV_ITEM_SALES SET TRXFLG = 1 WHERE CUTMO = '" & cmbmonth.Text & "' AND CUTYEAR = '" & cmbYear.Text & "' ")
                    End If
                    SaveSuccess()
                End If
            End If
        ElseIf sender Is btnClose Then
            On Error Resume Next
            Dim m_TabPage As TabPage = Me.Parent
            CType(m_TabPage.Parent, Windows.Forms.TabControl).TabPages.Remove(m_TabPage)
            Me.Dispose()
        End If

    End Sub

    Private Function RsDistinctMonth(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " where " & Filter
        End If

        rs.Open("SELECT DISTINCT CUTMO FROM CUST_DIV_ITEM_SALES " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


        Return rs
    End Function

    Private Function RsDistinctYear(Optional ByVal Filter As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " where " & Filter
        End If

        rs.Open("SELECT DISTINCT CUTYEAR FROM CUST_DIV_ITEM_SALES " & Filter, SPMSConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


        Return rs
    End Function

    Private Function ValidFields() As Boolean
        If cmbchannel.Text = "" Then
            ShowInformation("No Channel selected", "Channel not selected")
            Return False
        ElseIf cmbmonth.Text = "" Then
            ShowInformation("No month selected", "Month Not selected")
            Return False
        ElseIf cmbYear.Text = "" Then
            ShowInformation("No year selcted", "Year not selected")
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnlock.Click
        If ValidFields() = True Then
            If ShowQuestion("Are you sure you want to unlock this sales month?", "Unlock Sales Month") = MsgBoxResult.Yes Then
                If cmbchannel.Text <> "All" Then
                    SPMSConn.Execute("UPDATE CUST_DIV_ITEM_SALES SET TRXFLG = 0 WHERE COMID = '" & cmbchannel.Text & "' AND CUTMO = '" & cmbmonth.Text & "' AND CUTYEAR = '" & cmbYear.Text & "' ")
                Else
                    SPMSConn.Execute("UPDATE CUST_DIV_ITEM_SALES SET TRXFLG = 0 WHERE CUTMO = '" & cmbmonth.Text & "' AND CUTYEAR = '" & cmbYear.Text & "' ")
                End If
                SaveSuccess()
            End If
        End If
    End Sub
End Class
