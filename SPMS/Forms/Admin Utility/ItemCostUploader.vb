Imports System.Data.OleDb

Public Class ItemCostUploader

    Private m_ItemCost As New ItemCosting
    Private m_PrevChannelCode As String = String.Empty
    Private m_Month As String = String.Empty


    Private Sub StartUpload(ByVal FileName As String)
        Try

      
            m_PrevChannelCode = String.Empty
            m_Month = String.Empty

            Dim con As OleDbConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & FileName & " ;Extended Properties=Excel 8.0;")
            Dim dt As New DataTable
            Dim da As New OleDbDataAdapter("SELECT * FROM [Sheet1$]  Where [Channel Code] IS NOT NULL  Order By [Channel Code], Month , Year", con)
            Dim det As ItemCostingDetails
            da.Fill(dt)

            Dim ctr As Integer = 0
            pbar.Visible = True

            For m As Integer = 0 To dt.Rows.Count - 1

                pbar.Value = ctr / dt.Rows.Count * 100

                Dim dr As DataRow = dt.Rows(m)
                If m_PrevChannelCode = String.Empty Then
                    m_ItemCost = New ItemCosting
                    m_ItemCost.CompanyCode = dr("Channel Code")
                    m_ItemCost.Month = dr("Month")
                    m_ItemCost.Year = dr("Year")

                    det = New ItemCostingDetails
                    det.ItemCode = dr("Item Code")
                    det.ChannelItemCode = dr("Channel Item Code")
                    det.ItemCost = dr("Item Cost")

                    m_ItemCost.ItemCostingDetailsCollection.Add(det)
                    m_PrevChannelCode = dr("Channel Code")
                    m_Month = dr("Month")
                Else
                    If Not m_PrevChannelCode = dr("Channel Code") Then
                        m_ItemCost.Save()

                        m_ItemCost = New ItemCosting
                        m_ItemCost.CompanyCode = dr("Channel Code")
                        m_ItemCost.Month = dr("Month")
                        m_ItemCost.Year = dr("Year")

                        det = New ItemCostingDetails
                        det.ItemCode = dr("Item Code")
                        det.ChannelItemCode = dr("Channel Item Code")
                        det.ItemCost = dr("Item Cost")
                        m_ItemCost.ItemCostingDetailsCollection.Add(det)

                        If m = dt.Rows.Count - 1 Then
                            m_ItemCost.Save()
                        End If
                        m_PrevChannelCode = dr("Channel Code")
                        m_Month = dr("Month")
                    Else
                        If Not m_Month = dr("Month") Then

                            m_ItemCost.Save()

                            m_ItemCost = New ItemCosting
                            m_ItemCost.CompanyCode = dr("Channel Code")
                            m_ItemCost.Month = dr("Month")
                            m_ItemCost.Year = dr("Year")

                            det = New ItemCostingDetails
                            det.ItemCode = dr("Item Code")
                            det.ChannelItemCode = dr("Channel Item Code")
                            det.ItemCost = dr("Item Cost")
                            m_ItemCost.ItemCostingDetailsCollection.Add(det)

                            If m = dt.Rows.Count - 1 Then
                                m_ItemCost.Save()
                            End If

                        Else

                            det = New ItemCostingDetails
                            det.ItemCode = dr("Item Code").ToString
                            det.ChannelItemCode = dr("Channel Item Code")
                            det.ItemCost = dr("Item Cost")
                            m_ItemCost.ItemCostingDetailsCollection.Add(det)
                            If m = dt.Rows.Count - 1 Then
                                m_ItemCost.Save()
                            End If
                        End If

                        m_PrevChannelCode = dr("Channel Code")
                        m_Month = dr("Month")

                    End If
                End If
                ctr += 1
            Next
            pbar.Visible = False
            ShowInformation("Record Successfully Uploaded", "Item Cost Uploading")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        OpenFile()
    End Sub
    Private Sub OpenFile()
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Microsoft Office Excel(*.xls)|*.xls;*.xlsx"
        If (ofd.ShowDialog() = DialogResult.OK) Then
            If ofd.FileName.Length > 255 Then
                ShowExclamation("Path Too Long.", "Sales Agent")
                Exit Sub
            End If
            txtFileName.Text = ofd.FileName
        End If
    End Sub

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        StartUpload(txtFileName.Text)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub
End Class