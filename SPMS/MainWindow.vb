Imports System.IO
Imports SPMSOPCI.ConnectionModule
Public Class MainWindow

    Private Sub MainWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If ConnectionExists() = True Then
            'for the auto backup
            'code below is to first get the IP of the computer and compare with the datasource of the server ip
            Dim MyIP As String = ""
            MyIP = GetSplittedText(GetSqlconnectionPath(), 0, ";")
            MyIP = GetSplittedText(MyIP, 1, "=")
            OpenDb()

            Dim rs As New ADODB.Recordset
            rs = RsCompany()
            If rs.RecordCount > 0 Then
                Me.Text = rs.Fields("comname").Value & " - Sales Performance Monitoring System"
            End If

            If ConnectionModule.GetDefaultCompany = "" Then
                TabPage1.BackgroundImage = SPMSOPCI.My.Resources.COVER_GLENMARK_DA_copy3
                ProfitAndLossToolStripMenuItem.Visible = True
                TorrentUtilitToolStripMenuItem.Visible = True

            End If

            'for the login
            Dim tmpUserLogin As New UserLogin
            tmpUserLogin.ShowDialog()

            If tmpUserLogin.Username <> "" Then
                LockModules(tmpUserLogin.Username)

                If GetPcIPAddress() = MyIP Then
                    If AutoBackUpExist() = False Then
                        BackupDatabase(GetbackupLocationPath)
                        CreateBackUpDatabaseRecord(GetbackupLocationPath)
                    End If
                End If
            End If
        Else

            DatabaseConnection.ShowDialog()

            Dim rs As New ADODB.Recordset
            rs = RsCompany()
            If rs.RecordCount > 0 Then
                Me.Text = rs.Fields("comname").Value
            End If

            If ConnectionModule.GetDefaultCompany = "GPI" Then
                TabPage1.BackgroundImage = SPMSOPCI.My.Resources.COVER_GLENMARK_DA_copy3
                ProfitAndLossToolStripMenuItem.Visible = False
                TorrentUtilitToolStripMenuItem.Visible = False
            End If

            'for the login
            Dim tmpUserLogin As New UserLogin
            tmpUserLogin.ShowDialog()

            If tmpUserLogin.Username <> "" Then
                LockModules(tmpUserLogin.Username)
            Else
                Me.Dispose()
            End If

        End If

        Me.Opacity = 100%
        '  ShowInformation(HasReferenceRecords(TABLENAME, VALUETOFIND), "")
        'Me.ReportViewer1.RefreshReport()

        'If ConnectionExists() = True Then
        '    Dim MyIP As String = ""
        '    MyIP = GetSplittedText(GetSqlconnectionPath(), 0, ";")
        '    MyIP = GetSplittedText(MyIP, 1, "=")
        '    OpenDb()
        '    If GetPcIPAddress() = MyIP Then
        '        If AutoBackUpExist() = False Then
        '            BackupDatabase(GetbackupLocationPath)
        '            CreateBackUpDatabaseRecord(GetbackupLocationPath)
        '        End If
        '    End If
        'Else
        '    'TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        '    'Dim mine As New ucDatabaseConnection
        '    'mine.Width = Me.Width
        '    'mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        '    'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        '    'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        '    'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Database Connection"
        '    'TabControl1.SelectTab(TabControl1.TabPages.Count - 1)



        'End If


        '  ShowInformation(HasReferenceRecords(TABLENAME, VALUETOFIND), "")
    End Sub


    Private Sub OpenDb()
        If OpenConnection() <> True Then
            ConnectionFailed()
        End If
    End Sub

    Private Sub mnusalesFlashClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If sender Is mnuSalesSummary Then
        '    TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        '    Dim mine As New ucSalesFlash
        '    mine.Width = Me.Width
        '    mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        '    TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        '    TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        '    TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Flash"
        '    TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        'End If
    End Sub

    Private Sub mnuTransactionClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRawDataUploader.Click, mnuDataAnalyzer.Click
        If sender Is mnuRawDataUploader Then
        ElseIf sender Is mnuDataAnalyzer Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New UCRawDataAnalyzer
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Analyzer"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub



    Private Sub mnuMasterDataMaintenanceClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuItemDivision.Click, mnuItemGroup.Click, mnuItemClass.Click, mnuRegion.Click, mnuDistrict.Click, mnuArea.Click, mnuZipCode.Click,
    mnuCustomerGroup.Click, mnuCustomerClass.Click, mnuCustomer.Click, mnuSalesRegion.Click, mnuSalesDistrict.Click, mnuSalesTeam.Click, mnuAreaCoverage.Click, mnuMedicalRep.Click, mnuSalesmanager.Click, mnuItem.Click
        'for the items
        If sender Is mnuItemDivision Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucMasterItemDivisions
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Item Division"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        ElseIf sender Is mnuItemGroup Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucMasterItemGroups
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Item Group"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        ElseIf sender Is mnuItemClass Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucMasterItemClasss
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Therapeautic Class"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        ElseIf sender Is mnuItem Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            ''Dim mine As New UcMasterItems
            Dim mine As New UIItemCreate
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Item Creation"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        ElseIf sender Is mnuRegion Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucMasterRegions
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Region"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        ElseIf sender Is mnuDistrict Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucMasterDistrics
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "City/Province"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        ElseIf sender Is mnuArea Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucMasterMunicipalityLocations
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Municipality/Location"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)

        ElseIf sender Is mnuZipCode Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucMasterZipCodes
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Zip Code"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)

        ElseIf sender Is mnuCustomerGroup Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucMasterCustomerGroup
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Customer Group"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        ElseIf sender Is mnuCustomerClass Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucMasterCustomerClass
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Customer Class"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        ElseIf sender Is mnuCustomer Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New UICustomerEntrys
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Customer Entry"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        ElseIf sender Is mnuSalesRegion Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucMasterSTRegion
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Division"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        ElseIf sender Is mnuSalesDistrict Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New UIDistrictManager
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "DSM to District Assignment"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        ElseIf sender Is mnuSalesTeam Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucMasterSTTeam
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Team"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        ElseIf sender Is mnuAreaCoverage Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucMasterSTAreaCoverage
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Area Coverage"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        ElseIf sender Is mnuMedicalRep Then

            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New UIMasterMedicalReprecentative
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Employee Info"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        ElseIf sender Is mnuSalesmanager Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New UISalesManager
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Manager"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If

    End Sub

    Private Sub mnuAdministrationClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportingCalendar.Click

        If sender Is mnuCompany Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucCompany
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Company"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        ElseIf sender Is mnuReportingCalendar Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucAdministrationCalendar
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Reporting Calendar"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)

        End If

        'ElseIf sender Is mnuSalesSharing Then
        'TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        'Dim mine As New ucTransactionSalesSharing
        'mine.Width = Me.Width
        'mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Sharing"
        'TabControl1.SelectTab(TabControl1.TabPages.Count - 1)




        'End If

    End Sub


    Private Sub CustomerMappingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New ucAdministrationCustomerMapping
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Customer Mapping"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub mnuUtilitiesClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If sender Is mnuItemMasterFile Then
        '    With cr


        '        .Connect = "SPMS"

        '        .Destination = Crystal.DestinationConstants.crptToWindow

        '        .WindowState = Crystal.WindowStateConstants.crptMaximized
        '        .DiscardSavedData = True
        '        .WindowTitle = "Item Master Listing"
        '        .ReportFileName = System.AppDomain.CurrentDomain.BaseDirectory & "Resources\Reports\ReportMasterItemListing.rpt"

        '        .Action = 1
        '    End With
        'ElseIf sender Is ZipCodeToolStripMenuItem Then
        '    With cr


        '        .Connect = "SPMS"

        '        .Destination = Crystal.DestinationConstants.crptToWindow

        '        .WindowState = Crystal.WindowStateConstants.crptMaximized
        '        .DiscardSavedData = True
        '        .WindowTitle = "Geographical Map Master Listing"
        '        .ReportFileName = System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Reports\ReportMasterZipCode.rpt"

        '        .Action = 1
        '    End With

        'ElseIf sender Is mnuTerritorialMatrix Then
        '    With cr


        '        .Connect = "SPMS"

        '        .Destination = Crystal.DestinationConstants.crptToWindow

        '        .WindowState = Crystal.WindowStateConstants.crptMaximized
        '        .DiscardSavedData = True
        '        .WindowTitle = "Territorial Matrix Report"
        '        .ReportFileName = System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Reports\ReportSalesMatrix.rpt"

        '        .Action = 1
        '    End With
        'ElseIf sender Is mnuSalesTerritorialMatrix Then
        '    With cr


        '        .Connect = "SPMS"

        '        .Destination = Crystal.DestinationConstants.crptToWindow

        '        .WindowState = Crystal.WindowStateConstants.crptMaximized
        '        .DiscardSavedData = True
        '        .WindowTitle = "Sales Territorial Matrix Report"
        '        .ReportFileName = System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\Reports\ReportSalesMatrixByMEDREP.rpt"

        '        .Action = 1
        '    End With

        'End If

    End Sub

    Private Sub TerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TerToolStripMenuItem.Click

        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        ''  Dim mine As New UCAdministrationSalesMatrix
        Dim mine As New UIAdministratorSalesMatrix
        mine.Width = Me.Width
        mine.Height = Me.Height
        '''' mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 5
        'TabControl1.Dock = DockStyle.None 'set dock to none to allow resize
        'TabControl1.Size = New Size(New Point(30, 30)) ' set size anything you want
        'TabControl1.Dock = DockStyle.Fill 'set dock to fill to fit to container
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "MR Territory Assignment"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ChannelsItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChannelsItemToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        ''Dim mine As New UCDistributorItems
        Dim mine As New ucDistributorItemsPrice
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Channel Items Price List"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub


    Private Sub RawdataLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RawdataLToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New ucUploadedRawdata
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Raw Data Log File"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub mnuMainSalesTarget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainSalesTarget.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCTerritoryItemTargetPerDistributor
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Target Per Territory Per Item"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub SalesTransactionForThePeriodToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub SalesTransactionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesTransactionToolStripMenuItem.Click
        'If sender Is SalesTransactionToolStripMenuItem Then
        '    TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        '    Dim mine As New UCReportSalesTransactionforThePeriodofAll
        '    mine.Width = Me.Width
        '    mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        '    TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        '    TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        '    TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Transaction Reports"
        '    TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        'End If
    End Sub

    Private Sub CustomerMappingToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If sender Is CustomerMappingToolStripMenuItem Then
        '    TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        '    Dim mine As New ucAdministrationCustomerMapping
        '    mine.Width = Me.Width
        '    mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        '    TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        '    TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        '    TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Customer Mapping"
        '    TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        'End If
    End Sub

    Private Sub CustomerShipToToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerShipToToolStripMenuItem.Click
        If sender Is CustomerShipToToolStripMenuItem Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucMasterCustomerShipTo
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Customer Ship To"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub

    Private Sub UploadCustomerMappingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadCustomerMappingToolStripMenuItem.Click

        CustomerUploading.Show()


    End Sub

    Private Sub UploadSalesTargetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\SalesTargetUploading.exe") = True Then
            Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\SalesTargetUploading.exe")
            'Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\MDI.exe", AppWinStyle.NormalFocus)
        End If
    End Sub

    Private Sub MasterFileReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterFileReportsToolStripMenuItem.Click
        'TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        'Dim mine As New UcReportMasterFile
        'mine.Width = Me.Width
        'mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Master File Reports"
        'TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub


    Private Sub MonthlySalesForReToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ZIPCodeTerritoryAssignmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZIPCodeTerritoryAssignmentToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCMasterZipCodeAssignmentToTerritory
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Zip Code Assignment to Territory"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub SalesSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesSummaryToolStripMenuItem.Click
        'TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        'Dim mine As New ucReportSalesSummaryPeriod
        'mine.Width = Me.Width
        'mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Summary Reports"
        'TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub SalesCreditExclusionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesCreditExclusionToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCSalesCreditExclusion
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Credit Exclusion"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub mnuScriptUploader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuScriptUploader.Click
        'UserAdminLogIn.ShowDialog()
        Dim result As New UserAdminLogIn
        result.ShowDialog()
        If result.Status = True Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New UCScriptUpdater
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Script Updater"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub

    Private Sub SalesCreditReallignmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesCreditReallignmentToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCUtilityForCustDivItemSales
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Credit Realignment"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub mnumappedCustomerMapping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnumappedCustomerMapping.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New ucCustomerMappingInquiry
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Zip Code with Multiple Territories"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub UploadChannelItemsPricelistToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadChannelItemsPricelistToolStripMenuItem.Click
        Dim DistributorItems As New ItemListUploading
        DistributorItems.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCDSMDistrictAssigment
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Territorial District"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub CustomerMasterlistToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerMasterlistToolStripMenuItem.Click
        Dim DownloadingCustomer As New DownloadingCustomer
        DownloadingCustomer.ShowDialog()
    End Sub

    Private Sub SalesTargetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesTargetToolStripMenuItem.Click
        Dim Downloadingsalestarget As New frmDownloadingSalesTarget
        Downloadingsalestarget.ShowDialog()
    End Sub

    Private Sub PriceListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PriceListToolStripMenuItem.Click
        Dim Downloadingitemprice As New ItempriceDownloading
        Downloadingitemprice.ShowDialog()
    End Sub

    Private Sub UploadCustomerMappingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\CustomerMappingUploading.exe") = True Then
        '    Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\CustomerMappingUploading.exe")
        '    'Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\MDI.exe", AppWinStyle.NormalFocus)
        'End If
    End Sub

    Private Sub UploadZipCodeTerritoryAssigmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\ZipCodeTerritoryAssignmentUploading.exe") = True Then
        '    Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\ZipCodeTerritoryAssignmentUploading.exe")
        '    'Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\MDI.exe", AppWinStyle.NormalFocus)
        'End If
    End Sub

    Private Sub CustomerMappingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerMappingToolStripMenuItem1.Click
        If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\CustomerMappingDownloading.exe") = True Then
            Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\CustomerMappingDownloading.exe")
            'Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\MDI.exe", AppWinStyle.NormalFocus)
        End If
    End Sub

    Private Sub ZipCodeTerritoryAssignmentToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZipCodeTerritoryAssignmentToolStripMenuItem1.Click
        If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\ZipCodeTerritoryAssignmentDownloading.exe") = True Then
            Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\ZipCodeTerritoryAssignmentDownloading.exe")
            'Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\MDI.exe", AppWinStyle.NormalFocus)
        End If
    End Sub

    Private Sub CustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerToolStripMenuItem.Click
        If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\Template\Customer.xls") = True Then
            Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\Template\Customer.xls")
            'Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\MDI.exe", AppWinStyle.NormalFocus)
        End If
    End Sub

    Private Sub CustomerMappingToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\Template\CustomerMapping.xls") = True Then
        '    Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\Template\CustomerMapping.xls")
        '    'Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\MDI.exe", AppWinStyle.NormalFocus)
        'End If
    End Sub

    Private Sub SalesTargetToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesTargetToolStripMenuItem1.Click
        If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\Template\SalesTarget.xls") = True Then
            Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\Template\SalesTarget.xls")
            'Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\MDI.exe", AppWinStyle.NormalFocus)
        End If
    End Sub

    Private Sub ItemPriceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemPriceToolStripMenuItem.Click
        If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\Template\PriceList.xls") = True Then
            Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\Template\PriceList.xls")
            'Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\MDI.exe", AppWinStyle.NormalFocus)
        End If
    End Sub

    Private Sub ZipCodeTerritoryAssignmentToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\Template\Zip Code Territory Assignment.xls") = True Then
        '    Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\Template\Zip Code Territory Assignment.xls")
        '    'Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\MDI.exe", AppWinStyle.NormalFocus)
        'End If
    End Sub

    Private Sub CloseSalesSharingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseSalesSharingToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCMonthEndClosing
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Month End Closing"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub CreateUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateUserToolStripMenuItem.Click

    End Sub

    Private Sub UserProfileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserProfileToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCUserSchema
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "User Profile"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)

    End Sub

    Private Sub UserCreationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserCreationToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCUserCreator
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "User Creation"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub INHRawdataUploadingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INHRawdataUploadingToolStripMenuItem.Click
        If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\Template\GPI Default Format.xls") = True Then
            Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\Template\GPI Default Format.xls")
            'Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\MDI.exe", AppWinStyle.NormalFocus)
        End If
    End Sub

    Private Sub VatMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VatMaintenanceToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCVatMaintenance
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Vat Maintenance"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub CustomerMappingListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerMappingListingToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCCustomerMappingListing
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Customer Mapping Listing"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub mnuSalesFlash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    '================================================== For User Access ===================================================
    Private Sub LockModules()
        Dim rs As New ADODB.Recordset


        rs = RsModules()
        For i As Integer = 1 To rs.RecordCount


            SetMenuItem(rs.Fields("submoduleformname").Value.ToString, rs.Fields("enabled").Value)

            rs.MoveNext()
        Next
    End Sub

    Private Sub LockModules(ByVal Username As String)
        Dim rs As New ADODB.Recordset
        rs = RsUsers("UserName = '" & Username & "' ")
        If rs.RecordCount > 0 Then
            rs = RsModules("SchemaCD = '" & rs.Fields("SchemaCd").Value & "' ")
            If rs.RecordCount > 0 Then
                For i As Integer = 1 To rs.RecordCount


                    SetMenuItem(rs.Fields("submoduleformname").Value.ToString, rs.Fields("enabled").Value)

                    rs.MoveNext()
                Next
                SetAccountforUse(Username)

            End If
        End If
    End Sub


    Private Function SetMenuItem(ByVal name As String, ByVal enabled As Boolean)

        Dim m As ToolStripMenuItem

        m = Me.FindToolStripMenuItem(Me.MenuStrip1.Items, name)

        If m IsNot Nothing Then

            m.Enabled = enabled

            Return True

        Else

            Return False

        End If

    End Function


    Private Function FindToolStripMenuItem(ByRef menus As ToolStripItemCollection, ByVal name As String) As ToolStripMenuItem

        Dim found As Boolean = False

        Dim t, temp As ToolStripMenuItem

        t = menus(name)

        If t Is Nothing Then

            Dim i As Integer = 0
            While Not found And i < menus.Count
                If menus(i).GetType Is GetType(ToolStripMenuItem) Then
                    temp = menus(i)
                    t = Me.FindToolStripMenuItem(temp.DropDownItems, name)
                    found = (t IsNot Nothing)
                End If
                i += 1
            End While

        End If

        Return t

    End Function

    Private Sub MainWindow_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        LogOutAccount(User)
    End Sub


    Private Sub MainWindow_MouseCaptureChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseCaptureChanged

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Dim q As MsgBoxResult
        q = VDialog.Show("Are you sure you want to exit the application?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If q = MsgBoxResult.Yes Then
            Me.Dispose()
        End If
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        If ShowQuestion("Are you sure you want to log - off?", "Exit") Then
            LogOutAccount(User)
            Me.Opacity = 80%
            Dim tmpUserLogin As New UserLogin
            tmpUserLogin.ShowDialog()

            If tmpUserLogin.Username <> "" Then
                LockModules(tmpUserLogin.Username)
            End If
            Me.Opacity = 100%
        End If
    End Sub

    Private Sub MainWindow_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus

    End Sub

    Private Sub mnuDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDownloadItemMaster.Click

        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCReportMasterFileDownload
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Download Item Master"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCReportGeographicalMap
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Download Geographical Map"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCReportMasterSalesMatrix
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Download Sales Matrix"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub SalesTransactionToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesTransactionToolStripMenuItem1.Click
        If sender Is SalesTransactionToolStripMenuItem1 Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucSalesTransactionByChannel
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Transaction By Channel"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub

    Private Sub SalesTransactionByDistrictToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesTransactionByDistrictToolStripMenuItem.Click
        If sender Is SalesTransactionByDistrictToolStripMenuItem Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucSalesTransactionByDistrict
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Transaction By District"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub

    Private Sub SalesTransactionByRegionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesTransactionByRegionToolStripMenuItem.Click
        If sender Is SalesTransactionByRegionToolStripMenuItem Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucSalesTransactionByRegion
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Transaction By Region"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub

    Private Sub SalesTransactionByTerritoryCodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesTransactionByTerritoryCodeToolStripMenuItem.Click
        If sender Is SalesTransactionByTerritoryCodeToolStripMenuItem Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucSalesTransactionByTerritoryCode
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Transaction By Territory Code"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub

    Private Sub SalesTransactionByTerritoryTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesTransactionByTerritoryTypeToolStripMenuItem.Click
        If sender Is SalesTransactionByTerritoryTypeToolStripMenuItem Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New ucSalesTransactionByTransactionType
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Transaction By Transaction Type"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub

    Private Sub SaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaToolStripMenuItem.Click
        If sender Is SaToolStripMenuItem Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New UCReportSalesSummaryAllTerritory
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Summary All Territory"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub

    Private Sub AleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AleToolStripMenuItem.Click
        If sender Is AleToolStripMenuItem Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New UCReportSalesSummarybyDistrict
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Summary By District"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub

    Private Sub SalesSummaryByRegionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesSummaryByRegionToolStripMenuItem.Click
        If sender Is SalesSummaryByRegionToolStripMenuItem Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New UCReportSalesSummaryByRegion
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Summary By Region"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub

    Private Sub SalesSummaryByToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesSummaryByToolStripMenuItem.Click
        If sender Is SalesSummaryByToolStripMenuItem Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New UCReportSalesSummarybySalesCategory
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Summary By Sales Category"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub

    Private Sub SalesSummaryPerProductPerDistrictToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesSummaryPerProductPerDistrictToolStripMenuItem.Click
        If sender Is SalesSummaryPerProductPerDistrictToolStripMenuItem Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New UCReportSalesSummaryperProductperDistrict
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Summary Per Product Per District"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        If sender Is ToolStripMenuItem5 Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New UCReportSalesSummaryPerProduct
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Summary Per Product"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub

    Private Sub SalesSummaryPerProductTerritoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesSummaryPerProductTerritoryToolStripMenuItem.Click
        If sender Is SalesSummaryPerProductTerritoryToolStripMenuItem Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New UCReportSalesSummaryPerProductTerritory
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Summary Per Product Territory"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub

    Private Sub SalesSummaryPerProductTerritoryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesSummaryPerProductTerritoryToolStripMenuItem1.Click
        If sender Is SalesSummaryPerProductTerritoryToolStripMenuItem1 Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New UCReportSalesSummaryperTerritoryDistrict
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Summary Per Territory District"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub

    Private Sub SalesSummaryPerTerritoryProductToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesSummaryPerTerritoryProductToolStripMenuItem.Click
        If sender Is SalesSummaryPerTerritoryProductToolStripMenuItem Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New UCReportSalesSummaryPerTerritoryProduct
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Summary Per Territory Product"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub

    Private Sub SalesSummaryProductRegionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesSummaryProductRegionToolStripMenuItem.Click
        If sender Is SalesSummaryProductRegionToolStripMenuItem Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New UCReportSalesSummaryProductRegion
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Summary Product Region"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub

    Private Sub SalesSummaryTerritoryRegionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesSummaryTerritoryRegionToolStripMenuItem.Click
        If sender Is SalesSummaryTerritoryRegionToolStripMenuItem Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New UCreportSalesSummaryTerritoryRegion
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Summary Territory Region"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        If sender Is ToolStripMenuItem6 Then
            TabControl1.TabPages.Add(TabControl1.TabPages.Count)
            Dim mine As New UCReportSalesSummaryByChannel
            mine.Width = Me.Width
            mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Summary By Channel"
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        End If
    End Sub

    Private Sub UserPasswordResetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserPasswordResetToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCResetPassword
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Reset Password"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub UserUnlockAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserUnlockAccountToolStripMenuItem.Click
        UserStatusReset.ShowDialog()
    End Sub

    Private Sub SalesSharingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SalesSharingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesSharingToolStripMenuItem1.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCReportSalesSharing
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Sharing"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub



    Private Sub mnuAchievementTerritoryWise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCReportSalesAchievementTerritoryWise
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Achievement Territory Wise"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub AnalyticsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        ' Dim mine As New ucMonthlyReport
        'mine.Width = Me.Width
        'mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Analytics"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub AchievementTransactionWiseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCReportSalesAchievementTransactionTypeWise
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Achievement Transaction Wise"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub SalesStatisticsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New ucReportMercury
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Statistics"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub NationalSalesPerformanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        ' Dim mine As New ucMonthlyReport
        'mine.Width = Me.Width
        'mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "National Sales Performance"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub


    Private Function RsCompany(Optional ByVal Filter As String = "", Optional ByVal Orderby As String = "") As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        If Filter <> "" Then
            Filter = " where " & Filter
        End If
        If Orderby <> "" Then
            Orderby = " order by " & Orderby
        End If
        rs.Open("select * from company " & Filter & Orderby, SPMSConn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Return rs
    End Function

    Private Sub ManualCustomerMappingCopyFromToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim a As New CustomerMappingCopyFrom
        'a.ShowDialog()
    End Sub

    Private Sub SalesSharingCopyFromToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As New SalesSharingCopyFrom
        a.ShowDialog()
    End Sub

    Private Sub ZipCodeTerritoryMappingCopyFromToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim a As New ZipCodeTerritoryMappingCopyFrom
        'a.ShowDialog()
    End Sub


    Private Sub TerritoryWisePerformanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TerritoryWisePerformanceToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCPerformanceTerritoryWise
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Performance Territory Wise"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub DistrictWisePerformanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DistrictWisePerformanceToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCReportPerformanceMonthWise_DistrictWise
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Performance District Wise"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub






    Private Sub TerritoryAndProductWisePerformanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TerritoryAndProductWisePerformanceToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCReportPerformanceMonthWise_TerritoryProductWise
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Performance Territory Product Wise"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub
    '
    Private Sub DistrictAndProductWisePerformanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DistrictAndProductWisePerformanceToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCReportPerformanceMonthWise_DistrictProductWise
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Performance District Product Wise"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub MRWisePerformanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MRWisePerformanceToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCReportPerformanceMonthWise_MRWise
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Performance MR Wise"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub MRTerritoryAssignmentCopyFromToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As New MRTerritoryAssignmentCopyFrom
        a.ShowDialog()
    End Sub

    Private Sub ExpenseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ReferencesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReferencesToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCParticulars
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "References"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ExpenseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        'Dim mine As New UCExpense
        'mine.Width = Me.Width
        'mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Expense"
        'TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ExpenseUploadingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim a As New ExpenseUploader
        'a.ShowDialog()
    End Sub

    Private Sub ProfitAndLossToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProfitAndLossToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCReportProfitAndLoss
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Profit And Loss"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub TorrentUtilitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TorrentUtilitToolStripMenuItem.Click
        Dim FromDownloadReportUtility As New FrmDownloadReportUtilty
        FromDownloadReportUtility.ShowDialog()
    End Sub



    Private Sub mnuSalesAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalesAnalysis.Click

    End Sub

    Private Sub SalesListInvoiceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As Form = New Form1
        mine.Width = Me.Width
        mine.TopLevel = False
        mine.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        mine.WindowState = FormWindowState.Maximized
        mine.Show()
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales List Invoice Report"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)

    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub ItemCostToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim a As New ItemCostUploader
        'a.ShowDialog()
    End Sub

    Private Sub SalesSummaryByCompanyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesSummaryByCompanyToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim SummaryByCompany As New UCReportSalesSummaryByCompany
        SummaryByCompany.Width = Me.Width
        SummaryByCompany.Show()
        SummaryByCompany.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = SummaryByCompany.Label1.Text
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(SummaryByCompany)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)

    End Sub

    Private Sub SalesSummaryByCompanyPerMedRepToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesSummaryByCompanyPerMedRepToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim SummaryCompmedrep As New UCReportSalesSummaryByCompanyPerMedrep
        SummaryCompmedrep.Width = Me.Width
        SummaryCompmedrep.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        SummaryCompmedrep.Show()
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = SummaryCompmedrep.Label1.Text
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(SummaryCompmedrep)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub GrossProfitAnalysisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim ProfitAndLoss As New UCGrossProfitAnalysis
        ProfitAndLoss.Width = Me.Width
        ProfitAndLoss.Height = Me.TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        ProfitAndLoss.Show()
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = ProfitAndLoss.Label1.Text
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(ProfitAndLoss)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)

    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim SalesComparison As New UCReportSalesComparison
        SalesComparison.Width = Me.Width
        SalesComparison.Height = Me.TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = SalesComparison.Label1.Text
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(SalesComparison)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ItemDetailmanComparativeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemDetailmanComparativeToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim ItemDetailmanChannelComparative As New ucReportItemDetailmanComparative
        ItemDetailmanChannelComparative.Width = Me.Width
        ItemDetailmanChannelComparative.Height = Me.TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = ItemDetailmanChannelComparative.Label1.Text
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(ItemDetailmanChannelComparative)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub STDSALESPERPRODUCTMTDQTDYTDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STDSALESPERPRODUCTMTDQTDYTDToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim STDSalesPerProduct As New UCSTD_Sales_Per_Product_MTD_QTD_YTD
        STDSalesPerProduct.Width = Me.Width
        STDSalesPerProduct.Height = Me.TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = STDSalesPerProduct.Label1.Text
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(STDSalesPerProduct)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub SummaryDistrictToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryDistrictToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim SummaryDistrict As New ucReportSalesSummaryDistrict
        SummaryDistrict.Width = Me.Width
        SummaryDistrict.Height = Me.TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = SummaryDistrict.Label1.Text
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(SummaryDistrict)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub SalesSummaryChannelPerCustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesSummaryChannelPerCustomerToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim SalesSummaryChannelPerCustomer As New ucSalesSummaryChannelPerCustomer
        SalesSummaryChannelPerCustomer.Width = Me.Width
        SalesSummaryChannelPerCustomer.Height = Me.TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = SalesSummaryChannelPerCustomer.Label1.Text
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(SalesSummaryChannelPerCustomer)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub MercuryPerRepPerBranchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MercuryPerRepPerBranchToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim MercuryPerRepPerBranch As New ucMercuryPerRepPerBranch
        MercuryPerRepPerBranch.Width = Me.Width
        MercuryPerRepPerBranch.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = MercuryPerRepPerBranch.Label1.Text
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(MercuryPerRepPerBranch)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ItemSalesWithTargetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemSalesWithTargetToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim ItemSalesWithTarget As New UCReportItemSalesWithTarget
        ItemSalesWithTarget.Width = Me.Width
        ItemSalesWithTarget.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = ItemSalesWithTarget.Label1.Text
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(ItemSalesWithTarget)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ReportMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportMaintenanceToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim InfraReportMaintenance As New UCInfraReport
        InfraReportMaintenance.Width = Me.Width
        InfraReportMaintenance.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Report Maintenance"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(InfraReportMaintenance)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ReportViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportViewerToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim InfraReportReviewer As New UCInfraReportResult
        InfraReportReviewer.Width = Me.Width
        InfraReportReviewer.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Report Viewer"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(InfraReportReviewer)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub SharingMappingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SharingMappingToolStripMenuItem.Click
        'Dim a As New CustMapping
        'a.ShowDialog()
        Dim Sharing As New UISharingUploading
        Sharing.ShowDialog()
    End Sub

    Private Sub SharingMappingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SharingMappingToolStripMenuItem1.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New SharingMapping
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sharing Mapping"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ItemMappingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemMappingToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New ItemMapping
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Item Mapping"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub SharingMappingToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SharingMappingToolStripMenuItem1.Click

    End Sub

    Private Sub IncentiveSchemeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        'Dim mine As New IncentiveSets
        'mine.Width = Me.Width
        'mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Incentive Scheme"
        'TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub RawDataUploadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RawDataUploadToolStripMenuItem.Click

    End Sub

    'Private Sub BillingOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillingOrderToolStripMenuItem.Click
    '    TabControl1.TabPages.Add(TabControl1.TabPages.Count)
    '    Dim mine As New SalesEntryConcise
    '    mine.Width = Me.Width
    '    mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
    '    TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
    '    TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
    '    TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Billing Order"
    '    TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    'End Sub

    Private Sub BillingOrderToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillingOrderToolStripMenuItem1.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New SalesEntryConcise
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Order Entry"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub BillingOrderReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillingOrderReportsToolStripMenuItem.Click
        'If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\BillingOrderDownloading.exe") = True Then
        '    Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "Resources\BillingOrderDownloading.exe")
        '    'Shell(System.AppDomain.CurrentDomain.BaseDirectory & "\Resources\MDI.exe", AppWinStyle.NormalFocus)
        'End If

        Dim RawData As New Download_BiilingOrder
        RawData.ShowDialog()
    End Sub

    Private Sub RebatesTaggingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RebatesTaggingToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New ucRebatesTagging
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Rabates Tagging"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub PaymentViewingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentViewingToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New ucPaymentsViewing
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Payments Viewing"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub PaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New ucPayments
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Payments"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub MDIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MDIToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New ucUploader
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Raw Data Upload"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ALToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ALToolStripMenuItem.Click
        Dim RawData As New frmRawDataUploader
        RawData.ShowDialog()
    End Sub

    Private Sub ROTCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROTCToolStripMenuItem.Click
        SalesUploading.Show()
    End Sub

    Private Sub ODIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ODIToolStripMenuItem.Click
        Dim RawData As New frmRawDataUploader
        RawData._CompanyName = "ODI"
        RawData.ShowDialog()
    End Sub

    Private Sub mnuMainTerritorialConfiguration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainTerritorialConfiguration.Click

    End Sub

    Private Sub SalesPerformanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesPerformanceToolStripMenuItem.Click

    End Sub

    Private Sub TargetSalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TargetSalesToolStripMenuItem.Click
        Dim TargetsaleUpload As New ucTargetUploading
        TargetsaleUpload.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim ProfitAndLoss As New UCGrossProfitAnalysis
        ProfitAndLoss.Width = Me.Width
        ProfitAndLoss.Height = Me.TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        ProfitAndLoss.Show()
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = ProfitAndLoss.Label1.Text
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(ProfitAndLoss)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)

    End Sub

    Private Sub ExpenseToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpenseToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        'Dim mine As New UCExpense
        Dim mine As New UIExpense
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Expense"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ExpenseUploadingToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As New ExpenseUploader
        a.ShowDialog()
    End Sub

    Private Sub ItemCostToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemCostToolStripMenuItem.Click
        Dim a As New frmItemCosting
        a.ShowDialog()
    End Sub

    Private Sub ExpenseToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpenseToolStripMenuItem1.Click
        Dim a As New ExpenseUploader
        a.ShowDialog()
    End Sub

    Private Sub RawDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RawDataToolStripMenuItem.Click
        Dim RawData As New frmRawDataUploader
        RawData.ShowDialog()
    End Sub

    Private Sub InHouseRawDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InHouseRawDataToolStripMenuItem.Click
        Dim InRawData As New frmInHouseRawData
        InRawData.ShowDialog()
    End Sub

    Private Sub mnuTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransaction.Click

    End Sub

    Private Sub UnMapCustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnMapCustomerToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCUnMapCustomer
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Un-Map Customer(s)"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub NewPositionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewPositionToolStripMenuItem.Click
        'Dim PositionForm As New frmProductManager
        'PositionForm.ShowDialog()
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UIPosition
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Position"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub BudgetForecastingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BudgetForecastingToolStripMenuItem1.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New BudgetForecast
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Budget Forecasting"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub SalesPerformancesContractToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesPerformancesContractToolStripMenuItem.Click
        Dim UCsalesperformance_contract As New frmDownloadSalesperformancereport
        UCsalesperformance_contract.ShowDialog()
    End Sub

    Private Sub SalesPerChannelReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesPerChannelReportsToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCSalesPerChannel
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Reporting Per Channel"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub mnuMasterDataMaintenance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMasterDataMaintenance.Click

    End Sub

    Private Sub SalesMatrixToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesMatrixToolStripMenuItem.Click
        'Dim salesMatrix As New SalesMatrix
        'salesMatrix.ShowDialog()

        Dim SalesMatrix As New UISalesMatrix
        SalesMatrix.ShowDialog()
    End Sub

    Private Sub AreacoverageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AreacoverageToolStripMenuItem.Click
        Dim AreaCoverage As New Areacoverage
        AreaCoverage.ShowDialog()
    End Sub

    Private Sub ConfToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCConfigurationType
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "ConfigurationType"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub QueryAnalysisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QueryAnalysisToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New uCQueryForm
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Query Analysis Data"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub UnMappingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnMappingToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UCNonDataFilesOnSystem
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Non DataFiles on System"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub MRTerritoryAssignmentCopyFromToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MRTerritoryAssignmentCopyFromToolStripMenuItem1.Click
        Dim a As New MRTerritoryAssignmentCopyFrom
        a.ShowDialog()
    End Sub

    Private Sub SalesSharingCopyFromToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesSharingCopyFromToolStripMenuItem1.Click
        Dim a As New SalesSharingCopyFrom
        a.ShowDialog()
    End Sub

    Private Sub ProductManagerCreateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductManagerCreateToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New frmProductManagers
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Product Manager Create"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ProductManagerMappingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductManagerMappingToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UProductManagerMapping
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Product Manager Mapping"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub IssuedTarget_Click(sender As Object, e As EventArgs) Handles IssuedTarget.Click
        Dim TargetsaleUpload As New UI_IssuedTarget
        TargetsaleUpload.ShowDialog()
    End Sub

    Private Sub DistributorChannelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DistributorChannelToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UIDistributors
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Channel Entry"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub SalesTargetEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesTargetEntryToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim mine As New UITargetEntrys
        mine.Width = Me.Width
        mine.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height - 30
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = mine.Name
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(mine)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Target Entry"
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim UISalesReportResult As New UISalesReportResult
        UISalesReportResult.Width = Me.Width
        UISalesReportResult.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Report Viewer"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(UISalesReportResult)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub mnuItemCategory_Click(sender As Object, e As EventArgs) Handles mnuItemCategory.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim UCMasterItemCategory As New ucMasterItemCategory
        UCMasterItemCategory.Width = Me.Width
        UCMasterItemCategory.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Item Category"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(UCMasterItemCategory)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub mnItemManagerAssignment_Click(sender As Object, e As EventArgs) Handles mnItemManagerAssignment.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim UCMasterItemProductManager As New ucMasterItemProductManagerAssign
        UCMasterItemProductManager.Width = Me.Width
        UCMasterItemProductManager.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Item Product Manager Assignment"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(UCMasterItemProductManager)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub
    Private Sub mnuCoordinator_Click(sender As Object, e As EventArgs) Handles mnuCoordinator.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim UCMasterItemCoordanatorItem As New UcMasterCoordanatorItem
        UCMasterItemCoordanatorItem.Width = Me.Width
        UCMasterItemCoordanatorItem.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Customer Class"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(UCMasterItemCoordanatorItem)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub NoneSalesActivityOverviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NoneSalesActivityOverviewToolStripMenuItem.Click
        'Dim ActivityOverview As New Form2
        'ActivityOverview.ShowDialog()
    End Sub

    Private Sub GenerationActivityOverviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerationActivityOverviewToolStripMenuItem.Click
        Dim GenerationActivityOverview As New UIGenerationSC02
        GenerationActivityOverview.Show()
        'TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        'Dim UITESTINGCHART As New UISalesVsTargetChart
        'UITESTINGCHART.Width = Me.Width
        'UITESTINGCHART.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Customer Coordinator"
        'TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(UITESTINGCHART)
        'TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        'TabControl1.TabPages(1).AutoScroll = True
    End Sub

    Private Sub mnuCustomerCoordinator_Click(sender As Object, e As EventArgs) Handles mnuCustomerCoordinator.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim UCMasterCustomerCoordinator As New UICustomerClass
        UCMasterCustomerCoordinator.Width = Me.Width
        UCMasterCustomerCoordinator.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Customer Coordinator"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(UCMasterCustomerCoordinator)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub DoctorMedicalPersonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DoctorMedicalPersonToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim UIMedicalDoctor As New MDEntry
        UIMedicalDoctor.Width = Me.Width
        UIMedicalDoctor.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Medical Doctor Personel"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(UIMedicalDoctor)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub TerritoryManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TerritoryManagerToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim UIMedicalDoctor As New UITerritoryManagerChanges
        UIMedicalDoctor.Width = Me.Width
        UIMedicalDoctor.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Territory Manager Change and  Processs"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(UIMedicalDoctor)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub DataChangeCorrectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataChangeCorrectionToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        Dim RawData As New UIRawDataUploading
        RawData.ShowDialog()
    End Sub

    Private Sub MedicalDoctorSalesPersonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MedicalDoctorSalesPersonToolStripMenuItem.Click

    End Sub

    Private Sub MedicalDoctorValidationRawDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MedicalDoctorValidationRawDataToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim UIMedicalDoctorValidationRawData As New UIMedicalDoctorValidationRawData
        UIMedicalDoctorValidationRawData.Width = Me.Width
        UIMedicalDoctorValidationRawData.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Medical Doctor Validation RawData"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(UIMedicalDoctorValidationRawData)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub MedicalDoctorCreationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MedicalDoctorCreationToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        ''Dim UIMedicalDoctor As New UIMedicalDoctor
        Dim UIMedicalDoctorPersonel As New UIMedicalDoctorPersonel
        UIMedicalDoctorPersonel.Width = Me.Width
        UIMedicalDoctorPersonel.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Medical Doctor Personel"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(UIMedicalDoctorPersonel)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles mnuProductItemGroup.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        ''Dim UIMedicalDoctor As New UIMedicalDoctor
        Dim MenuProductItemGroup As New UIProductItemGroup
        MenuProductItemGroup.Width = Me.Width
        MenuProductItemGroup.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Product Item Group"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(MenuProductItemGroup)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ToolStripMenuItem12_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click

    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        ''Dim UIMedicalDoctor As New UIMedicalDoctor
        Dim MenuProductItemGroup As New UIDistributorChannelGroup
        MenuProductItemGroup.Width = Me.Width
        MenuProductItemGroup.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Distributor Channel Group"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(MenuProductItemGroup)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        Dim a As New FrmProductPerChannelCopyFrom
        a.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click

    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim MenuProductItemGroup As New UCUnitOfMeasurement
        MenuProductItemGroup.Width = Me.Width
        MenuProductItemGroup.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Unit of Measurement"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(MenuProductItemGroup)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem17.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim MenuUnitOfConversion As New UCUnitOfConversion
        MenuUnitOfConversion.Width = Me.Width
        MenuUnitOfConversion.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Unit of Conversion"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(MenuUnitOfConversion)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub SalesByChannelDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesByChannelDataToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        ''Dim UIMedicalDoctor As New UIMedicalDoctor
        Dim MenuSalesExportSourceData As New UISalesExportSourceData
        MenuSalesExportSourceData.Width = Me.Width
        MenuSalesExportSourceData.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Export Source Data"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(MenuSalesExportSourceData)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub SalesByTerritoryDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesByTerritoryDataToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        ''Dim UIMedicalDoctor As New UIMedicalDoctor
        Dim MenuTerritoryProductPerformance As New UITerritoryProductPerformance
        MenuTerritoryProductPerformance.Width = Me.Width
        MenuTerritoryProductPerformance.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Territory Product Performance by Pivot Data"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(MenuTerritoryProductPerformance)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ToolStripMenuItem18_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem18.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        ''Dim UIMedicalDoctor As New UIMedicalDoctor
        Dim MenuUIDMICTerritoryManagerPeriodToPeriodPivot As New UIDMICTerritoryManagerPeriodToPeriodPivot
        MenuUIDMICTerritoryManagerPeriodToPeriodPivot.Width = Me.Width
        MenuUIDMICTerritoryManagerPeriodToPeriodPivot.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "District Manager Item Customer Territory Manager Comparative Period to Period"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(MenuUIDMICTerritoryManagerPeriodToPeriodPivot)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ExpenseToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ExpenseToolStripMenuItem2.Click

    End Sub

    Private Sub MedicalDoctorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MedicalDoctorToolStripMenuItem.Click

    End Sub

    Private Sub DoctorOfMedicineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DoctorOfMedicineToolStripMenuItem.Click

    End Sub

    Private Sub EmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim MenuUIEmployeeSalesman As New UIEmployeeSalesman
        MenuUIEmployeeSalesman.Width = Me.Width
        MenuUIEmployeeSalesman.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Employee Sales Man"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(MenuUIEmployeeSalesman)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub SalesAccountSpecialistToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesAccountSpecialistToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim MenuUISalesAccountSpecialist As New UISalesAccountSpecialist
        MenuUISalesAccountSpecialist.Width = Me.Width
        MenuUISalesAccountSpecialist.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Account Specialist"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(MenuUISalesAccountSpecialist)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub SalesAccountSpecialistApplyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesAccountSpecialistApplyToolStripMenuItem.Click
        Dim a As New UISalesAccountSpecialistProcess
        a.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem20_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem20.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim MenuUISalesAccountSpecialist As New UISalesAcountSpecialistConfig
        MenuUISalesAccountSpecialist.Width = Me.Width
        MenuUISalesAccountSpecialist.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Account Specialist Configuration"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(MenuUISalesAccountSpecialist)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub SalesAccountSpecialistTargetSettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesAccountSpecialistTargetSettingToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim MenuUISalesAccountSpecialist As New UISalesAccountSpecialistTarget
        MenuUISalesAccountSpecialist.Width = Me.Width
        MenuUISalesAccountSpecialist.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Sales Account Specialist Target"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(MenuUISalesAccountSpecialist)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ItemSharingSettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemSharingSettingToolStripMenuItem.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim MenuUISalesAccountSpecialist As New UiItemSharing
        MenuUISalesAccountSpecialist.Width = Me.Width
        MenuUISalesAccountSpecialist.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Item Sharing"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(MenuUISalesAccountSpecialist)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub ToolStripMenuItem22_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem22.Click
        Dim a As New ItemSharingCopyFrom
        a.ShowDialog()
    End Sub

    Private Sub mnuUpload_Click(sender As Object, e As EventArgs) Handles mnuUpload.Click

    End Sub

    Private Sub ToolStripMenuItem23_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem23.Click
        Dim a As New UIPublishReport
        a.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem24_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem24.Click
        TabControl1.TabPages.Add(TabControl1.TabPages.Count)
        Dim MenuUISalesAccountSpecialist As New UICustomerAndItemSharing
        MenuUISalesAccountSpecialist.Width = Me.Width
        MenuUISalesAccountSpecialist.Height = TabControl1.TabPages(TabControl1.TabPages.Count - 1).Height
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Text = "Customer and Item Sharing"
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(MenuUISalesAccountSpecialist)
        TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
    End Sub

    Private Sub CustomerItemSharingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerItemSharingToolStripMenuItem.Click
        Dim a As New UIUploadingCustomerItemSharing
        a.ShowDialog()
    End Sub
End Class
