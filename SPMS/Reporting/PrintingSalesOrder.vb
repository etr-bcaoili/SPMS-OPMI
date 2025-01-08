Public Class PrintingSalesOrder
    Private m_ReportFileName As String = Application.StartupPath & "\TestReport1.txt"

    Private m_Report As New JReport.JReport

    Private m_ShiptoParty As String = String.Empty
    Private m_ShiptoPartyAdd As String = String.Empty
    Private m_Telephone As String = String.Empty
    Private m_Fax As String = String.Empty

    Private m_PrintDate As String = String.Empty
    Private m_PONumber As String = String.Empty
    Private m_ReferenceNo As String = String.Empty
    Private m_Supplier As String = String.Empty
    Private m_SupplierAdd As String = String.Empty
    Private m_Currency As String = String.Empty
    Private m_CreditTerms As String = String.Empty
    Private m_Remarks As String = String.Empty
    Private m_DocumentDate As String = String.Empty
    Private m_PostingDate As String = String.Empty
    Private m_DeliveryDate As String = String.Empty
    Private m_CreatedBy As String = String.Empty
    'Private m_CreatedOn As String = String.Empty
    Private m_ApprovedBy As String = String.Empty
    Private m_PersonPosition As String = String.Empty
    'Private m_RejectedBy As String = String.Empty
    'Private m_RejectedOn As String = String.Empty
    'Private m_CancelledBy As String = String.Empty
    'Private m_CancelledOn As String = String.Empty
    'Private m_CancellationReason As String = String.Empty

    Private m_ModeOfShipment As String = String.Empty
    Private m_TermsOfDelivery As String = String.Empty
    Private m_PaymentTerms As String = String.Empty
    Private m_CIF As Decimal = 0

    Dim y As Integer = 230
    Dim ctr As Integer = 15

    Dim page As Integer = 0

    Private m_details As New PreviewOfPurchaseOrderDetailCollection


    Public ReadOnly Property PreviewOfPurchaseOrderDetailCollection() As PreviewOfPurchaseOrderDetailCollection
        Get
            Return m_details
        End Get
    End Property

    Public Property PrintDate() As String
        Get
            Return m_PrintDate
        End Get
        Set(ByVal value As String)
            m_PrintDate = value
        End Set
    End Property

    Public Property PONumber() As String
        Get
            Return m_PONumber
        End Get
        Set(ByVal value As String)
            m_PONumber = value

        End Set
    End Property

    Public Property ReferenceNumber() As String
        Get
            Return m_ReferenceNo
        End Get
        Set(ByVal value As String)
            m_ReferenceNo = value

        End Set
    End Property

    Public Property Supplier() As String
        Get
            Return m_Supplier
        End Get
        Set(ByVal value As String)
            m_Supplier = value

        End Set
    End Property

    Public Property SupplierAdd() As String
        Get
            Return m_SupplierAdd
        End Get
        Set(ByVal value As String)
            m_SupplierAdd = value

        End Set
    End Property

    Public Property Currency() As String
        Get
            Return m_Currency
        End Get
        Set(ByVal value As String)
            m_Currency = value

        End Set
    End Property

    Public Property CreditTerms() As String
        Get
            Return m_CreditTerms
        End Get
        Set(ByVal value As String)
            m_CreditTerms = value

        End Set
    End Property


    Public Property Remarks() As String
        Get
            Return m_Remarks
        End Get
        Set(ByVal value As String)
            m_Remarks = value

        End Set
    End Property

    Public Property DocumentDate() As String
        Get
            Return m_DocumentDate
        End Get
        Set(ByVal value As String)
            m_DocumentDate = value

        End Set
    End Property

    Public Property PostingDate() As String
        Get
            Return m_PostingDate

        End Get
        Set(ByVal value As String)
            m_PostingDate = value

        End Set
    End Property

    Public Property DeliveryDate() As String
        Get
            Return m_DeliveryDate
        End Get
        Set(ByVal value As String)
            m_DeliveryDate = value
        End Set
    End Property

    Public Property CreatedBy() As String
        Get
            Return m_CreatedBy
        End Get
        Set(ByVal value As String)
            m_CreatedBy = value

        End Set
    End Property

    Public Property PersonPosition() As String
        Get
            Return m_PersonPosition
        End Get
        Set(ByVal value As String)
            m_PersonPosition = value
        End Set
    End Property

    'Public Property CreatedOn() As String
    '    Get
    '        Return m_CreatedOn
    '    End Get
    '    Set(ByVal value As String)
    '        m_CreatedOn = value

    '    End Set
    'End Property

    Public Property ApprovedBy() As String
        Get
            Return m_ApprovedBy
        End Get
        Set(ByVal value As String)
            m_ApprovedBy = value

        End Set
    End Property

    'Public Property ApprovedOn() As String
    '    Get
    '        Return m_ApprovedOn

    '    End Get
    '    Set(ByVal value As String)
    '        m_ApprovedOn = value

    '    End Set
    'End Property

    'Public Property RejectedBy() As String
    '    Get
    '        Return m_RejectedBy
    '    End Get
    '    Set(ByVal value As String)
    '        m_RejectedBy = value

    '    End Set
    'End Property

    'Public Property RejectedOn() As String
    '    Get
    '        Return m_RejectedOn
    '    End Get
    '    Set(ByVal value As String)
    '        m_RejectedOn = value

    '    End Set
    'End Property

    'Public Property CancelledBy() As String
    '    Get
    '        Return m_CancelledBy
    '    End Get
    '    Set(ByVal value As String)
    '        m_CancelledBy = value

    '    End Set
    'End Property

    'Public Property CancelledOn() As String
    '    Get
    '        Return m_CancelledOn

    '    End Get
    '    Set(ByVal value As String)
    '        m_CancelledOn = value
    '    End Set
    'End Property

    'Public Property CancelledReason() As String
    '    Get
    '        Return m_CancellationReason
    '    End Get
    '    Set(ByVal value As String)
    '        m_CancellationReason = value

    '    End Set
    'End Property

    Public Property ModeOfShipment() As String
        Get
            Return m_ModeOfShipment
        End Get
        Set(ByVal value As String)
            m_ModeOfShipment = value
        End Set
    End Property

    Public Property TermsOfDelivery() As String
        Get
            Return m_TermsOfDelivery
        End Get
        Set(ByVal value As String)
            m_TermsOfDelivery = value
        End Set
    End Property


    Public Property PaymentTerms() As String
        Get
            Return m_PaymentTerms
        End Get
        Set(ByVal value As String)
            m_PaymentTerms = value
        End Set
    End Property

    Public Property CIF() As Decimal
        Get
            Return m_CIF
        End Get
        Set(ByVal value As Decimal)
            m_CIF = value
        End Set
    End Property

    Public Property ShiptoParty() As String
        Get
            Return m_ShiptoParty
        End Get
        Set(ByVal value As String)
            m_ShiptoParty = value

        End Set
    End Property
    Public Property ShiptoPartyAdd() As String
        Get
            Return m_ShiptoPartyAdd
        End Get
        Set(ByVal value As String)
            m_ShiptoPartyAdd = value

        End Set
    End Property

    Public Property Telephone() As String
        Get
            Return m_Telephone
        End Get
        Set(ByVal value As String)
            m_Telephone = value
        End Set
    End Property

    Public Property Fax() As String
        Get
            Return m_Fax
        End Get
        Set(ByVal value As String)
            m_Fax = value
        End Set
    End Property



    Public Sub GenerateReport()
        'Print()
        ' DrawDetails(Me)
        m_Report.setLandscape()
        m_Report.setPaperSize(825, 1175)
        PrintPreview()
        m_Report.nextPage()
        m_Report.fileName = m_ReportFileName
        m_Report.Save()
        m_Report.showReport(m_ReportFileName)

    End Sub

    Public Sub PrintForm()
        Dim numb As Integer = 0
        page = page + 1
        If page = 1 Then
            numb = page + page
        End If

        m_Report.drawText("Page " & page & " of " & numb, 880, 800, 200, 20)

        m_Report.setFont("Arial Black", 8)
        m_Report.drawRect(10, 10, 1070, 140)
        m_Report.drawText("Ship to Party (Consignee Name and Address)", 15, 15, 300, 100)
        m_Report.setFont("Arial", 8)
        m_Report.drawText(m_ShiptoParty, 15, 35, 500, 100)
        m_Report.drawText(m_ShiptoPartyAdd, 15, 45, 300, 100)
        m_Report.drawText("Tel:", 15, 95, 100, 100)
        m_Report.drawText(m_Telephone, 115, 95, 100, 100)
        m_Report.drawText("Fax:", 15, 115, 100, 100)
        m_Report.drawText(m_Fax, 115, 115, 100, 100)

        m_Report.setFont("Arial Black", 8)

        m_Report.drawText("Ship to Party (Consignee Name and Address)", 15, 15, 300, 100)
        m_Report.setFont("Arial", 8)
        m_Report.drawLine(359, 10, 359, 145)
        m_Report.drawText(m_ShiptoParty, 400, 35, 300, 100)
        m_Report.drawText(m_ShiptoPartyAdd, 400, 45, 300, 100)
        m_Report.drawText("Tel:", 400, 95, 100, 100)
        m_Report.drawText(m_Telephone, 500, 95, 100, 100, StringAlignment.Center)
        m_Report.drawText("Fax:", 400, 115, 100, 100)
        m_Report.drawText(m_Fax, 500, 115, 100, 100, StringAlignment.Center)
        m_Report.drawLine(789, 10, 789, 145)
        m_Report.drawLine(789, 150, 789, 164)


        'horizontal
        m_Report.drawLine(10, 165, 1080, 165)
        m_Report.drawLine(10, 185, 1080, 185)
        m_Report.drawLine(10, 229, 1080, 229)
        m_Report.drawLine(10, 244, 1080, 244)
        m_Report.drawLine(10, 259, 1080, 259)
        m_Report.drawLine(10, 274, 1080, 274)
        m_Report.drawLine(10, 289, 1080, 289)
        m_Report.drawLine(10, 304, 1080, 304)
        m_Report.drawLine(10, 319, 1080, 319)
        m_Report.drawLine(10, 334, 1080, 334)
        m_Report.drawLine(10, 349, 1080, 349)
        m_Report.drawLine(10, 364, 1080, 364)
        m_Report.drawLine(10, 379, 1080, 379)
        m_Report.drawLine(10, 394, 1080, 394)
        m_Report.drawLine(10, 409, 1080, 409)
        m_Report.drawLine(10, 424, 1080, 424)
        m_Report.drawLine(10, 439, 1080, 439)
        m_Report.drawLine(10, 454, 1080, 454)
        m_Report.drawLine(10, 469, 1080, 469)
        m_Report.drawLine(10, 484, 1080, 484)


        m_Report.drawLine(769, 504, 909, 504)
        m_Report.drawLine(769, 524, 909, 524)

        m_Report.drawLine(10, 544, 1080, 544)
        m_Report.drawLine(10, 560, 969, 560)
        m_Report.drawLine(10, 575, 569, 575)
        m_Report.drawLine(10, 590, 969, 590)
        m_Report.drawLine(10, 605, 969, 605)
        m_Report.drawLine(10, 620, 569, 620)
        m_Report.drawLine(10, 635, 569, 635)
        m_Report.drawLine(10, 650, 969, 650)
        m_Report.drawLine(10, 665, 569, 665)
        m_Report.drawLine(10, 680, 569, 680)
        m_Report.drawLine(10, 695, 969, 695)


        'vertical

        m_Report.drawLine(9, 169, 9, 544) 'SN
        m_Report.drawLine(9, 560, 9, 695)
        m_Report.drawLine(39, 185, 39, 484) 'ItemCode
        m_Report.drawLine(99, 185, 99, 484) 'SAPCode
        m_Report.drawLine(199, 185, 199, 484) 'ItemDescription
        m_Report.drawLine(369, 185, 369, 484) 'PS
        m_Report.drawLine(329, 560, 329, 694)
        m_Report.drawLine(399, 169, 399, 484) 'UOM

        m_Report.drawLine(429, 169, 429, 484) 'CQO
        m_Report.drawLine(499, 185, 499, 484) 'FCG
        m_Report.drawLine(569, 185, 569, 484) 'S
        m_Report.drawLine(569, 560, 569, 694)
        m_Report.drawLine(619, 169, 619, 484) 'TOQ
        m_Report.drawLine(689, 169, 689, 484) 'UP
        m_Report.drawLine(769, 185, 769, 484) 'TA
        m_Report.drawLine(849, 169, 849, 544)
        m_Report.drawLine(909, 185, 909, 544) 'PRN
        m_Report.drawLine(969, 185, 969, 484) 'RNTBP
        m_Report.drawLine(1080, 168, 1080, 544) 'AR
        m_Report.drawLine(969, 560, 969, 695)

        m_Report.setFont("Arial", 10, True)
        m_Report.drawRect(Color.Yellow, Color.Black, 769, 469, 140, 75)
        m_Report.drawText("CIF", 770, 470, 60, 100)
        m_Report.drawText("Freight", 770, 490, 60, 100)
        m_Report.drawText("Insurance", 770, 510, 100, 100)
        m_Report.drawText("Total USD", 770, 530, 100, 100)

        m_Report.setFont("Arial", 9)
        m_Report.drawLine(10, 145, 1080, 145)
        m_Report.drawText("PO Number:", 10, 150, 100, 100)
        m_Report.drawText(m_PONumber, 90, 150, 100, 100)
        m_Report.drawText("Date", 790, 150, 50, 100)
        m_Report.drawText(m_PrintDate, 840, 150, 70, 100)
        m_Report.drawLine(10, 169, 1080, 169)

        m_Report.setFont("Arial", 9, True)
        m_Report.drawText("Barcodes to be printed on each individual Pack.", 10, 515, 400, 100)
        m_Report.setFont("Arial", 9, True)
        m_Report.drawText("SHIP INFORMATION:", 10, 546, 200, 100)
        m_Report.setFont("Arial", 8)
        m_Report.drawText("Mode of Shipment:", 10, 561, 200, 100)
        m_Report.drawText("Terms of Delivery:", 10, 576, 200, 100)
        m_Report.drawText("Payment Terms:", 10, 591, 200, 100)
        m_Report.drawText("Notify(if other than Consignee)", 10, 606, 300, 100)
        m_Report.setFont("Arial", 10, True)
        m_Report.drawText("Expected Delivery Date:", 10, 621, 300, 100)
        m_Report.setFont("Arial", 8)
        m_Report.drawText("Partial Shipment:", 10, 636, 200, 100)
        m_Report.drawText("Port Discharge:", 10, 651, 200, 100)
        m_Report.drawText("Final Destination:", 10, 666, 200, 100)

        m_Report.setFont("Arial", 8, True)
        m_Report.drawText(m_ModeOfShipment, 345, 561, 100, 100)
        m_Report.setFont("Arial", 8)
        m_Report.drawText("FOB/CIF/CIP/CPT/C&F - CIF", 345, 576, 200, 100)
        m_Report.setFont("Arial", 8, True)
        m_Report.drawText(m_PaymentTerms, 345, 591, 100, 100)
        m_Report.setFont("Arial", 10, True)
        m_Report.drawText("Immediate Requirement", 345, 621, 200, 100)
        m_Report.setFont("Arial", 8, True)
        m_Report.drawText("Allowed/Not Allowed", 345, 636, 200, 100)
        m_Report.drawText("Allowed/Not Allowed", 345, 651, 200, 100)
        m_Report.drawText("Manila, Philippines", 345, 666, 200, 100)

        m_Report.setFont("Arial", 8)
        m_Report.drawText("Shipping Marks: Glenmark Philippines, Inc. ( GPI)", 570, 561, 300, 100)
        m_Report.drawLine(569, 563, 969, 563)
        m_Report.drawText("Document Required by Fax: Yes  /  No - YES", 570, 591, 300, 100)
        m_Report.drawLine(569, 593, 969, 593)
        m_Report.drawText("By Courier (Address): SAME AS ABOVE", 570, 606, 300, 100)
        m_Report.drawLine(569, 608, 969, 608)
        m_Report.drawText("For Negotiation: (Name of the Party & Address) - SAME AS ABOVE", 570, 651, 300, 100)

        m_Report.setFont("Arial", 8)
        m_Report.drawRect(969, 560, 111, 45)
        m_Report.drawText("BankerDetails: NA", 970, 561, 200, 100)

        m_Report.drawRect(969, 605, 111, 90)
        m_Report.drawText("SpecialRequirement", 970, 610, 200, 100)

        m_Report.drawText("Prepared By:", 10, 700, 150, 100)
        m_Report.drawText(m_CreatedBy, 10, 730, 100, 100)


        m_Report.drawText("Approved By:", 10, 760, 150, 100)
        m_Report.drawText(m_ApprovedBy, 10, 790, 150, 100)

        m_Report.setFont("Arial", 8)
        m_Report.drawText("SN", 10, 190, 30, 100, StringAlignment.Center)
        m_Report.drawText("Item Code", 40, 190, 60, 100, StringAlignment.Center)
        m_Report.drawText("SAP Code", 100, 190, 100, 100, StringAlignment.Center)
        m_Report.drawText("Product Description", 200, 190, 130, 100, StringAlignment.Center)
        m_Report.drawText("Pack Size", 370, 190, 30, 100, StringAlignment.Center)
        m_Report.drawText("UOM", 400, 190, 30, 100, StringAlignment.Center)
        m_Report.drawText("Commercial Quantity Ordered", 430, 190, 70, 100, StringAlignment.Center)
        m_Report.drawText("Free of Charge Goods", 500, 190, 70, 100, StringAlignment.Center)
        m_Report.drawText("Samples", 570, 190, 50, 100, StringAlignment.Center)
        m_Report.drawText("TotalOrder Quantity (Sale)", 620, 190, 70, 100, StringAlignment.Center)
        m_Report.drawText("Unit Price (USD/Euro)", 690, 190, 80, 100, StringAlignment.Center)
        m_Report.drawText("Total Amount (USD)", 770, 190, 70, 200, StringAlignment.Center)
        m_Report.drawText("SPECIFICATIONS INSTRUCTIONS", 850, 170, 195, 100, StringAlignment.Center)
        m_Report.drawText("Product Reg. No", 850, 190, 60, 200, StringAlignment.Center)
        m_Report.drawText("Reg.No.To Be Printed", 910, 190, 60, 100, StringAlignment.Center)
        m_Report.drawText("Art Work Req.", 970, 190, 100, 100, StringAlignment.Center)


    End Sub

    Public Sub PrintPreview()
        PrintForm()

        Dim det As PreviewOfPurchaseOrderDetail

        For i As Integer = 0 To m_details.Count - 1
            det = m_details(i)

            If ctr = 0 Then
                ctr = 15
                y = 230
                m_Report.nextPage()

                PrintForm()
            End If
            'Dim x As Integer = 0
            'x = x + 1
            m_Report.setFont("Arial", 8)

            ' m_Report.drawText(x, 10, y, 30, 100, StringAlignment.Center)
            m_Report.drawText(det.ItemCode, 40, y, 60, 15, StringAlignment.Center)
            m_Report.drawText(det.SAPCode, 100, y, 100, 15, StringAlignment.Center)
            m_Report.drawText(det.ItemDescription, 200, y, 170, 15, StringAlignment.Center)
            m_Report.drawText(det.PackSize, 370, y, 30, 15, StringAlignment.Center)
            m_Report.drawText(det.Unit, 400, y, 30, 15, StringAlignment.Center)
            'm_Report.drawText(FormatQuantityValue(det.Quantity), 430, y, 70, 15, StringAlignment.Center)
            m_Report.drawText(det.Free, 500, y, 70, 15, StringAlignment.Center)
            'm_Report.drawText(FormatQuantityValue(det.Samples), 570, y, 50, 15, StringAlignment.Center)
            'm_Report.drawText(FormatQuantityValue(det.TotalOrderQuantity), 620, y, 70, 15, StringAlignment.Far)
            'm_Report.drawText(FormatAmountValue(det.PurchaseCost), 690, y, 80, 15, StringAlignment.Far)
            'm_Report.drawText(FormatAmountValue(det.Amount), 770, y, 70, 15, StringAlignment.Far)
            m_Report.drawText(det.PRN, 850, y, 60, 15, StringAlignment.Center)
            m_Report.drawText(det.RNTBP, 910, y, 60, 15, StringAlignment.Center)
            m_Report.drawText(det.AR, 970, y, 100, 15, StringAlignment.Center)

            y = y + 15
            ctr = ctr - 1

            '    m_Report.drawText(FormatAmountValue(m_CIF), 850, 470, 60, 100, StringAlignment.Far)
            '   m_Report.drawText(FormatAmountValue(det.TA), 850, 530, 60, 100, StringAlignment.Far)

        Next
    End Sub
End Class



Public Class PreviewOfPurchaseOrderDetail

    'Private m_ShiptoPartyContact As String = String.Empty
    Private m_ItemCode As String = String.Empty
    Private m_SAPCode As String = String.Empty
    Private m_ItemDescription As String = String.Empty
    Private m_PackSize As String = String.Empty
    Private m_Free As String = String.Empty
    Private m_Unit As String = String.Empty
    Private m_Quantity As Decimal = 0
    Private m_TypeOfPrice As String = String.Empty
    Private m_PurchaseCost As Decimal = 0
    Private m_Amout As Decimal = 0
    Private m_TA As Decimal = 0
    Private m_TotalOrderQuantity As Decimal = 0
    Private m_Samples As Decimal = 0
    Private m_PRN As String = String.Empty
    Private m_RNTBP As String = String.Empty
    Private m_AR As String = String.Empty


    Public Property ItemCode() As String
        Get
            Return m_ItemCode
        End Get
        Set(ByVal value As String)
            m_ItemCode = value

        End Set
    End Property

    Public Property SAPCode() As String
        Get
            Return m_SAPCode
        End Get
        Set(ByVal value As String)
            m_SAPCode = value
        End Set
    End Property

    Public Property ItemDescription() As String
        Get
            Return m_ItemDescription

        End Get
        Set(ByVal value As String)
            m_ItemDescription = value

        End Set
    End Property

    Public Property PackSize() As String
        Get
            Return m_PackSize
        End Get
        Set(ByVal value As String)
            m_PackSize = value
        End Set
    End Property

    Public Property Free() As String
        Get
            Return m_Free

        End Get
        Set(ByVal value As String)
            m_Free = value

        End Set
    End Property

    Public Property Unit() As String
        Get
            Return m_Unit
        End Get
        Set(ByVal value As String)
            m_Unit = value
        End Set
    End Property

    Public Property Quantity() As Decimal
        Get
            Return m_Quantity
        End Get
        Set(ByVal value As Decimal)
            m_Quantity = value
        End Set
    End Property

    Public Property TypeOfPrice() As String
        Get
            Return m_TypeOfPrice
        End Get
        Set(ByVal value As String)
            m_TypeOfPrice = value
        End Set
    End Property

    Public Property PurchaseCost() As Decimal
        Get
            Return m_PurchaseCost
        End Get
        Set(ByVal value As Decimal)
            m_PurchaseCost = value
        End Set
    End Property

    Public Property Amount() As Decimal
        Get
            Return m_Amout
        End Get
        Set(ByVal value As Decimal)
            m_Amout = value
        End Set
    End Property

    Public Property TotalOrderQuantity() As Decimal
        Get
            Return m_TotalOrderQuantity
        End Get
        Set(ByVal value As Decimal)
            m_TotalOrderQuantity = value
        End Set
    End Property

    Public Property Samples() As Decimal
        Get
            Return m_Samples
        End Get
        Set(ByVal value As Decimal)
            m_Samples = value
        End Set
    End Property

    Public Property PRN() As String
        Get
            Return m_PRN
        End Get
        Set(ByVal value As String)
            m_PRN = value
        End Set
    End Property

    Public Property RNTBP() As String
        Get
            Return m_RNTBP
        End Get
        Set(ByVal value As String)
            m_RNTBP = value
        End Set
    End Property

    Public Property AR() As String
        Get
            Return m_AR
        End Get
        Set(ByVal value As String)
            m_AR = value
        End Set
    End Property

    '    Public Property Remarks2() As String
    '        Get
    '            Return m_Remarks2
    '        End Get
    '        Set(ByVal value As String)
    '            m_Remarks2 = value
    '        End Set
    '    End Property

    Public Property TA() As Decimal
        Get
            Return m_TA
        End Get
        Set(ByVal value As Decimal)
            m_TA = value
        End Set
    End Property
End Class

Public Class PreviewOfPurchaseOrderDetailCollection

    Inherits List(Of PreviewOfPurchaseOrderDetail)
End Class