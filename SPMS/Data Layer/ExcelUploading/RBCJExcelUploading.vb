Imports System.Drawing
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Collections.Generic
Imports System.Data.OleDb

Public Class RBCJExcelUploading
    Dim dt As DataTable

    Private m_RawData As New RawData

    Private m_CompanyCode As String

    Private m_Year As String

    Private m_Month As String

    Private m_Path As String

    Public Property CompanyCode() As String
        Get
            Return m_CompanyCode
        End Get
        Set(ByVal value As String)
            m_CompanyCode = value
        End Set
    End Property

    Public Property Year() As String
        Get
            Return m_Year
        End Get
        Set(ByVal value As String)
            m_Year = value
        End Set
    End Property

    Public Property Month() As String
        Get
            Return m_Month
        End Get
        Set(ByVal value As String)
            m_Month = value
        End Set
    End Property

    Public Property Path() As String
        Get
            Return m_Path
        End Get
        Set(ByVal value As String)
            m_Path = value
        End Set
    End Property

    Public Function GetData(ByVal Path As String) As DataTable

        '  Dim con As OleDbConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & FileName & " ;Extended Properties=Excel 8.0;")
        Dim dt As New DataTable
        ' Dim da As New OleDbDataAdapter("SELECT * FROM [Sheet1$] where DistributorCode LIKE '" & CompanyCode & "' AND CutYear LIKE '" & Year & "' AND Cutmo LIKE'" & Month & "'", con)
        'Dim con As OleDbConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & Path & " ;Extended Properties=Excel 8.0;")
        'Dim dt As New DataTable
        'Dim da As New OleDbDataAdapter("SELECT * FROM [Sheet1$] where DistributorCode LIKE '" & CompanyCode & "' AND CutYear LIKE '" & Year & "' AND Cutmo LIKE'" & Month & "'", con)
        'da.Fill(dt)
        Return dt

    End Function

    Public Sub StartProcess()
        Dim ctr As Integer = 0
        Dim TotalQuantity As Decimal = 0
        Dim GrossAmount As Decimal = 0
        Dim ProductDiscount As Decimal = 0
        Dim _Month As String = String.Empty

        If Month < 10 Then
            _Month = "0" & Month
        Else
            _Month = Month
        End If

        If Not RawData.CheckIfRawDataExist(CompanyCode, Year, Month) Then

            For m As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(m)
                If Not dr("DistributorCode") = CompanyCode Then Exit Sub
                m_RawData = New RawData

                m_RawData.CompanyCode = dr("DistributorCode")
                m_RawData.BranchCode = dr("ITEMCD").ToString
                If IsDBNull(dr("IMDBRN")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("IMDBRN")
                End If

                m_RawData.CustomerNumber = dr("CUSTOMERCD")
                m_RawData.CustomerName = dr("CUSTOMERNAME")
                If dr("CADD1") <> "" Then
                    m_RawData.CustomerAddress = dr("CADD1")
                    m_RawData.ShipToAddress1 = dr("CADD1")
                Else
                    m_RawData.CustomerAddress = ""
                    m_RawData.ShipToAddress1 = ""
                End If

                If dr("CADD2") <> "" Then
                    m_RawData.CustomerAddress2 = dr("CADD2")
                    m_RawData.ShipToAddress2 = dr("CADD2")
                Else
                    m_RawData.CustomerAddress2 = ""
                    m_RawData.ShipToAddress2 = ""
                End If
                m_RawData.TranscationDate = dr("InvoiceDate")
                m_RawData.InvoiceNumber = dr("InvoiceNumber")

                If dr("VLAMT") = 0 Then
                    m_RawData.QuantityFree = dr("QuantityFree")
                    TotalQuantity = TotalQuantity + dr("QTYSH")
                    m_RawData.QuantitySold = dr("QuantitySold")
                Else
                    m_RawData.QuantitySold = dr("QuantitySold")
                    TotalQuantity = TotalQuantity + dr("QuantitySold")
                    m_RawData.QuantityFree = 0
                    m_RawData.UnitPrice = dr("ListPrice")
                    m_RawData.NetAmount = dr("Amount")
                    GrossAmount = GrossAmount + dr("Amount")
                End If
                If IsDBNull(dr("InvoiceNumber")) Then
                    m_RawData.InvoiceReferenceNumber = -1
                Else
                    m_RawData.InvoiceReferenceNumber = dr("InvoiceNumber")
                End If
                m_RawData.LineDiscount = dr("Discount")
                If dr("LOTNO") <> "" Then
                    m_RawData.LotNumber = dr("LOTNO").ToString
                Else
                    m_RawData.LotNumber = ""
                End If

                m_RawData.SalesmanNumber = dr("SalesManCode")
                m_RawData.SalesmanName = dr("SLSMNNAME")
                m_RawData.CutMO = dr("Cutmo")
                m_RawData.CutYear = dr("Cutyear")

                ctr += 1
                m_RawData.Save()

            Next
            ' ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & CompanyCode & "','" & _ExecelLocation & "','" & Month & "','" & Year & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        Else

            RawData.DeleteExistRawData(CompanyCode, Year, Month)
            For m As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(m)
                If Not dr("DistributorCode") = CompanyCode Then Exit Sub
                m_RawData = New RawData

                m_RawData.CompanyCode = dr("DistributorCode")
                m_RawData.BranchCode = dr("ITEMCD").ToString
                If IsDBNull(dr("IMDBRN")) Then
                    m_RawData.BranchName = ""
                Else
                    m_RawData.BranchName = dr("IMDBRN")
                End If

                m_RawData.CustomerNumber = dr("CUSTOMERCD")
                m_RawData.CustomerName = dr("CUSTOMERNAME")
                If dr("CADD1") <> "" Then
                    m_RawData.CustomerAddress = dr("CADD1")
                    m_RawData.ShipToAddress1 = dr("CADD1")
                Else
                    m_RawData.CustomerAddress = ""
                    m_RawData.ShipToAddress1 = ""
                End If

                If dr("CADD2") <> "" Then
                    m_RawData.CustomerAddress2 = dr("CADD2")
                    m_RawData.ShipToAddress2 = dr("CADD2")
                Else
                    m_RawData.CustomerAddress2 = ""
                    m_RawData.ShipToAddress2 = ""
                End If
                m_RawData.TranscationDate = dr("InvoiceDate")
                m_RawData.InvoiceNumber = dr("InvoiceNumber")

                If dr("VLAMT") = 0 Then
                    m_RawData.QuantityFree = dr("QuantityFree")
                    TotalQuantity = TotalQuantity + dr("QTYSH")
                    m_RawData.QuantitySold = dr("QuantitySold")
                Else
                    m_RawData.QuantitySold = dr("QuantitySold")
                    TotalQuantity = TotalQuantity + dr("QuantitySold")
                    m_RawData.QuantityFree = 0
                    m_RawData.UnitPrice = dr("ListPrice")
                    m_RawData.NetAmount = dr("Amount")
                    GrossAmount = GrossAmount + dr("Amount")
                End If
                If IsDBNull(dr("InvoiceNumber")) Then
                    m_RawData.InvoiceReferenceNumber = -1
                Else
                    m_RawData.InvoiceReferenceNumber = dr("InvoiceNumber")
                End If
                m_RawData.LineDiscount = dr("Discount")
                If dr("LOTNO") <> "" Then
                    m_RawData.LotNumber = dr("LOTNO").ToString
                Else
                    m_RawData.LotNumber = ""
                End If

                m_RawData.SalesmanNumber = dr("SalesManCode")
                m_RawData.SalesmanName = dr("SLSMNNAME")
                m_RawData.CutMO = dr("Cutmo")
                m_RawData.CutYear = dr("Cutyear")

                ctr += 1
                m_RawData.Save()

            Next
            '  ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & CompanyCode & "','" & _ExecelLocation & "','" & Month & "','" & Year & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        End If

        'If Not RawData.CheckIfRawDataExist(CompanyCode, Year, Month) Then
        '    For m As Integer = 0 To dt.Rows.Count - 1
        '        Dim dr As DataRow = dt.Rows(m)
        '        If Not dr("Companycode") = CompanyCode Then Exit Sub
        '        m_RawData = New RawData

        '        m_RawData.CompanyCode = dr("Companycode")
        '        m_RawData.BranchCode = dr("BRAN").ToString
        '        If IsDBNull(dr("SATBRN")) Then
        '            m_RawData.BranchName = ""
        '        Else
        '            m_RawData.BranchName = dr("SATBRN")
        '        End If
        '        m_RawData.CustomerNumber = dr("CUSNO")
        '        m_RawData.CustomerName = dr("CUSTNM")

        '        If dr("CADD1") <> "" Then
        '            m_RawData.CustomerAddress = dr("CADD1")
        '            m_RawData.ShipToAddress1 = dr("CADD1")
        '        Else
        '            m_RawData.CustomerAddress = ""
        '            m_RawData.ShipToAddress1 = ""
        '        End If

        '        If dr("CADD2") <> "" Then
        '            m_RawData.CustomerAddress2 = dr("CADD2")
        '            m_RawData.ShipToAddress2 = dr("CADD2")
        '        Else
        '            m_RawData.CustomerAddress2 = ""
        '            m_RawData.ShipToAddress2 = ""
        '        End If

        '        m_RawData.TranscationDate = dr("REFDT")
        '        m_RawData.InvoiceNumber = dr("REFNO")
        '        If IsDBNull(dr("REFCD")) Then
        '            m_RawData.TransactionType = ""
        '        Else
        '            m_RawData.TransactionType = dr("REFCD")
        '        End If

        '        m_RawData.ItemNumber = dr("PRODCD")
        '        'm_RawData.ItemDescription = dr("")
        '        'm_RawData.WarehouseNumber = dr("")
        '        'm_RawData._Class = dr("CLASS")
        '        If dr("VLAMT") = 0 Then
        '            m_RawData.QuantityFree = dr("QTYSH")
        '            TotalQuantity = TotalQuantity + dr("QTYSH")
        '            m_RawData.QuantitySold = 0
        '        Else
        '            m_RawData.QuantitySold = dr("QTYSH")
        '            TotalQuantity = TotalQuantity + dr("QTYSH")
        '            m_RawData.QuantityFree = 0
        '        End If
        '        'm_RawData.GrossAmount = dr("")
        '        'm_RawData.LineDiscount = dr("")
        '        'm_RawData.ProductDiscount = dr("")
        '        'm_RawData.VatCode = dr("")
        '        'm_RawData.Route = dr("")
        '        'm_RawData.Taxes = dr("")
        '        'm_RawData.Freight = dr("")
        '        'm_RawData.Additional = dr("")
        '        m_RawData.NetAmount = dr("VLAMT")
        '        GrossAmount = GrossAmount + dr("VLAMT")
        '        'm_RawData.UnitPrice = dr("")

        '        If IsDBNull(dr("XREFNO")) Then
        '            m_RawData.InvoiceReferenceNumber = -1
        '        Else
        '            m_RawData.InvoiceReferenceNumber = dr("XREFNO")
        '        End If

        '        If IsDBNull(dr("REASN")) Then
        '            m_RawData.CMCode = ""
        '        Else
        '            m_RawData.CMCode = dr("REASN")
        '        End If

        '        'm_RawData.SONumber = dr("")
        '        'm_RawData.SODate = dr("")
        '        m_RawData.SOTerms = dr("TERMS")

        '        If dr("EXPDTE").ToString <> "" Then
        '            m_RawData.ExpiryDate = dr("EXPDTE").ToString
        '        Else
        '            m_RawData.ExpiryDate = ""
        '        End If

        '        If dr("LOTNO") <> "" Then
        '            m_RawData.LotNumber = dr("LOTNO").ToString
        '        Else
        '            m_RawData.LotNumber = ""
        '        End If

        '        m_RawData.SalesmanNumber = dr("SMAN")
        '        'm_RawData.SalesmanName = dr("")
        '        m_RawData.ShipToName = dr("CUSTNM")

        '        If IsDBNull(dr("ZIPCD")) Then
        '            m_RawData.Zipcode = ""
        '        Else
        '            m_RawData.Zipcode = dr("ZIPCD")
        '        End If

        '        'm_RawData.TerritoryNumber = dr("")
        '        'm_RawData.Area = dr("")
        '        m_RawData.CustomerClass = dr("CLASS")
        '        'm_RawData.ClassName = dr("")
        '        m_RawData.Principal = dr("CONO")
        '        'm_RawData.SubPrincipal = dr("")
        '        'm_RawData.PrincipalDivisionCode = dr("")
        '        'm_RawData.SalesWeek = dr("")
        '        If IsDBNull(dr("SATBRN")) Then
        '            m_RawData.CustomerDeliveryCode = "001"
        '        Else
        '            m_RawData.CustomerDeliveryCode = dr("SATBRN")
        '        End If
        '        m_RawData.ListOfTaxIncluse = dr("SELLPR")
        '        'm_RawData.ContractPrincipalApprovalNumber = dr("")
        '        m_RawData.OrderType = "N"
        '        'm_RawData.IsCode = dr("")
        '        m_RawData.CutMO = dr("SLSMO")
        '        m_RawData.CutYear = dr("SLSYR")
        '        'm_RawData.Region = dr("")
        '        'm_RawData.EffectivityStartDate = dr("")
        '        'm_RawData.EffectivityEndDate = dr("")

        '        ctr += 1
        '        m_RawData.Save()
        '    Next
        '    ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & CompanyCode & "','" & Path & "','" & _Month & "','" & Year & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        'Else
        '    RawData.DeleteExistRawData(CompanyCode, Year, Month)

        '    For m As Integer = 0 To dt.Rows.Count - 1
        '        Dim dr As DataRow = dt.Rows(m)

        '        If Not dr("Companycode") = CompanyCode Then Exit Sub
        '        m_RawData = New RawData

        '        m_RawData.CompanyCode = dr("Companycode")
        '        m_RawData.BranchCode = dr("BRAN").ToString
        '        If IsDBNull(dr("SATBRN")) Then
        '            m_RawData.BranchName = ""
        '        Else
        '            m_RawData.BranchName = dr("SATBRN")
        '        End If
        '        m_RawData.CustomerNumber = dr("CUSNO")
        '        m_RawData.CustomerName = dr("CUSTNM")

        '        If dr("CADD1") <> "" Then
        '            m_RawData.CustomerAddress = dr("CADD1")
        '            m_RawData.ShipToAddress1 = dr("CADD1")
        '        Else
        '            m_RawData.CustomerAddress = ""
        '            m_RawData.ShipToAddress1 = ""
        '        End If

        '        If dr("CADD2") <> "" Then
        '            m_RawData.CustomerAddress2 = dr("CADD2")
        '            m_RawData.ShipToAddress2 = dr("CADD2")
        '        Else
        '            m_RawData.CustomerAddress2 = ""
        '            m_RawData.ShipToAddress2 = ""
        '        End If

        '        m_RawData.TranscationDate = dr("REFDT")
        '        m_RawData.InvoiceNumber = dr("REFNO")
        '        If IsDBNull(dr("REFCD")) Then
        '            m_RawData.TransactionType = ""
        '        Else
        '            m_RawData.TransactionType = dr("REFCD")
        '        End If

        '        m_RawData.ItemNumber = dr("PRODCD")
        '        'm_RawData.ItemDescription = dr("")
        '        'm_RawData.WarehouseNumber = dr("")
        '        'm_RawData._Class = dr("CLASS")
        '        If dr("VLAMT") = 0 Then
        '            m_RawData.QuantityFree = dr("QTYSH")
        '            TotalQuantity = TotalQuantity + dr("QTYSH")
        '            m_RawData.QuantitySold = 0
        '        Else
        '            m_RawData.QuantitySold = dr("QTYSH")
        '            TotalQuantity = TotalQuantity + dr("QTYSH")
        '            m_RawData.QuantityFree = 0
        '        End If
        '        'm_RawData.GrossAmount = dr("")
        '        'm_RawData.LineDiscount = dr("")
        '        'm_RawData.ProductDiscount = dr("")
        '        'm_RawData.VatCode = dr("")
        '        'm_RawData.Route = dr("")
        '        'm_RawData.Taxes = dr("")
        '        'm_RawData.Freight = dr("")
        '        'm_RawData.Additional = dr("")
        '        m_RawData.NetAmount = dr("VLAMT")
        '        GrossAmount = GrossAmount + dr("VLAMT")
        '        'm_RawData.UnitPrice = dr("")

        '        If IsDBNull(dr("XREFNO")) Then
        '            m_RawData.InvoiceReferenceNumber = -1
        '        Else
        '            m_RawData.InvoiceReferenceNumber = dr("XREFNO")
        '        End If

        '        If IsDBNull(dr("REASN")) Then
        '            m_RawData.CMCode = ""
        '        Else
        '            m_RawData.CMCode = dr("REASN")
        '        End If

        '        'm_RawData.SONumber = dr("")
        '        'm_RawData.SODate = dr("")
        '        m_RawData.SOTerms = dr("TERMS")

        '        If dr("EXPDTE").ToString <> "" Then
        '            m_RawData.ExpiryDate = dr("EXPDTE").ToString
        '        Else
        '            m_RawData.ExpiryDate = ""
        '        End If

        '        If dr("LOTNO") <> "" Then
        '            m_RawData.LotNumber = dr("LOTNO").ToString
        '        Else
        '            m_RawData.LotNumber = ""
        '        End If

        '        m_RawData.SalesmanNumber = dr("SMAN")
        '        'm_RawData.SalesmanName = dr("")
        '        m_RawData.ShipToName = dr("CUSTNM")

        '        If IsDBNull(dr("ZIPCD")) Then
        '            m_RawData.Zipcode = ""
        '        Else
        '            m_RawData.Zipcode = dr("ZIPCD")
        '        End If

        '        'm_RawData.TerritoryNumber = dr("")
        '        'm_RawData.Area = dr("")
        '        m_RawData.CustomerClass = dr("CLASS")
        '        'm_RawData.ClassName = dr("")
        '        m_RawData.Principal = dr("CONO")
        '        'm_RawData.SubPrincipal = dr("")
        '        'm_RawData.PrincipalDivisionCode = dr("")
        '        'm_RawData.SalesWeek = dr("")
        '        If IsDBNull(dr("SATBRN")) Then
        '            m_RawData.CustomerDeliveryCode = "001"
        '        Else
        '            m_RawData.CustomerDeliveryCode = dr("SATBRN")
        '        End If
        '        m_RawData.ListOfTaxIncluse = dr("SELLPR")
        '        'm_RawData.ContractPrincipalApprovalNumber = dr("")
        '        m_RawData.OrderType = "N"
        '        'm_RawData.IsCode = dr("")
        '        m_RawData.CutMO = dr("SLSMO")
        '        m_RawData.CutYear = dr("SLSYR")
        '        'm_RawData.Region = dr("")
        '        'm_RawData.EffectivityStartDate = dr("")
        '        'm_RawData.EffectivityEndDate = dr("")

        '        ctr += 1
        '        m_RawData.Save()
        '    Next
        '    'If m_RawData.Save Then
        '    '    MessageBox.Show("Upload Successfully")
        '    'Else
        '    '    MessageBox.Show("Data Already Exist")
        '    'End If
        '    ExecuteCommand("Insert Into UploadedRawData(CompanyCode,CheckFileName,Cutmo,Cutyear,TotalGrossAmount,TotalQuantity,TotalNetAmount) " & " Values('" & CompanyCode & "','" & Path & "','" & _Month & "','" & Year & "','" & GrossAmount & "','" & TotalQuantity & "','" & GrossAmount & "' )")
        'End If
    End Sub
End Class
