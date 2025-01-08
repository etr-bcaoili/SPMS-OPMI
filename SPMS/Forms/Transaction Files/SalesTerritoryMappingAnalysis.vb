Public Class SalesTerritoryMappingAnalysis

    Private m_ComID As String = String.Empty
    Private m_FromDate As Date = "1/1/900"
    Private m_ToDate As Date = "1/1/1900"

    Private m_CustomerMappingCache As New CustomerMappingOverlappingCache
    Private m_SalesMatrixCache As New SalesMatrixCache
    Private m_CustomerMappingType As New CustomerMappingClassCache
    Private m_SingleCustomerMapping As New SingleCustomerMappingCache

    Private m_AutoShare As AutoCreateSharing
    Private m_WithErr As Boolean = False
    Private m_HasInitialized As Boolean = False

    Public Property AutoShare() As AutoCreateSharing
        Get
            Return m_AutoShare
        End Get
        Set(ByVal value As AutoCreateSharing)
            m_AutoShare = value
        End Set
    End Property

    Public Property COMID() As String
        Get
            Return m_ComID
        End Get
        Set(ByVal value As String)
            m_ComID = value
        End Set
    End Property

    Public Property FromDate() As Date
        Get
            Return m_FromDate
        End Get
        Set(ByVal value As Date)
            m_FromDate = value
        End Set
    End Property

    Public Property ToDate() As Date
        Get
            Return m_ToDate
        End Get
        Set(ByVal value As Date)
            m_ToDate = value
        End Set
    End Property

    Private Sub SalesTerritoryMappingAnalysis_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        If m_WithErr Then
            m_AutoShare.IsAllowedAutoSharing = False
        Else
            m_AutoShare.IsAllowedAutoSharing = True
        End If
    End Sub

    Private Sub SalesTerritoryMappingAnalysis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_HasInitialized = False
        ApplyGridTheme(dgCustomerMapping)
        ApplyGridTheme(dgSalesMatrix)
        ApplyGridTheme(dgCustomerMappingwithMulitpleType)
        ApplyGridTheme(dgSingleCustomerMapping)

        dgCustomerMappingwithMulitpleType.AutoGenerateColumns = False
        dgSalesMatrix.AutoGenerateColumns = False
        dgCustomerMapping.AutoGenerateColumns = False
        dgSingleCustomerMapping.AutoGenerateColumns = False

        m_CustomerMappingCache.InitializedCache(m_ComID, m_FromDate, m_ToDate)
        m_SalesMatrixCache.InitializedCache(m_ComID, m_FromDate, m_ToDate)
        m_CustomerMappingType.InitializedCache(m_ComID, m_FromDate, m_ToDate)
        m_SingleCustomerMapping.InitializedCache(m_ComID, m_FromDate, m_ToDate)

        If m_CustomerMappingCache.WithErr = True Or m_SalesMatrixCache.WithErr Or m_CustomerMappingType.WithErr Or m_SingleCustomerMapping.WithErr Then
            m_WithErr = True
        Else
            Me.Dispose()
        End If

        dtFrom.Value = FromDate.ToShortDateString
        dtTo.Value = ToDate.ToShortDateString

        dtFrom2.Value = FromDate.ToShortDateString
        dtTo2.Value = ToDate.ToShortDateString

        dt3From.Value = FromDate.ToShortDateString
        dt3To.Value = ToDate.ToShortDateString

        dt4From.Value = FromDate.ToShortDateString
        dt4To.Value = ToDate.ToShortDateString


        m_HasInitialized = True
        FilterCustomerMapping()
        FilterSalesMatrix()
        FilterCustomerMappingType()
        FilterSingleCustomerMapping()
    End Sub

    Private Sub FilterCustomerMapping()

        m_CustomerMappingCache.Channel = txtChannel.Text
        m_CustomerMappingCache.CustomerCode = txtCustomerCode.Text
        m_CustomerMappingCache.EffectivityEndDate = dtTo.Value
        m_CustomerMappingCache.EffectivityStartDate = dtFrom.Value
        m_CustomerMappingCache.Municipality = txtMunicipality.Text
        m_CustomerMappingCache.Province = txtProvince.Text
        m_CustomerMappingCache.RegionCode = txtRegion.Text
        m_CustomerMappingCache.ShipToCode = txtShipToCode.Text
        m_CustomerMappingCache.ShipToName = txtShipToName.Text
        m_CustomerMappingCache.Territory = txtTerritory.Text

        dgCustomerMapping.DataSource = m_CustomerMappingCache.FilterDv
    End Sub


    Private Sub FilterSalesMatrix()

        m_SalesMatrixCache.EffectivityStartDate = dtFrom2.Value
        m_SalesMatrixCache.EffectivityEndDate = dtTo2.Value
        m_SalesMatrixCache.ItemDivision = txtItemDivision.Text
        m_SalesMatrixCache.SalesmanCode = txtMRCode.Text
        m_SalesMatrixCache.SalesmanName = txtMRName.Text
        m_SalesMatrixCache.TerritoryCode = txtTerritory2.Text
        m_SalesMatrixCache.TerritoryName = txtTerritoryName.Text

        dgSalesMatrix.DataSource = m_SalesMatrixCache.FilterDv
    End Sub

    Private Sub FilterCustomerMappingType()

        m_CustomerMappingType.AreaCd = txt3Municipality.Text
        m_CustomerMappingType.CDACD = txt3ShipToCode.Text
        m_CustomerMappingType.ComID = txt3Channel.Text
        m_CustomerMappingType.CustomerCd = txt3CustomerCd.Text
        m_CustomerMappingType.DistrctCD = txt3Province.Text
        m_CustomerMappingType.EffectivityEndDate = dt3To.Value
        m_CustomerMappingType.EffectivityStartDate = dt3From.Value
        m_CustomerMappingType.RegCd = txt3RegCd.Text
        m_CustomerMappingType.TransactionType = txt3Type.Text
        m_CustomerMappingType.ZipCd = txt3ZipCd.Text
        m_CustomerMappingType.AreaCovrg = txt3AreaCovrg.Text
        dgCustomerMappingwithMulitpleType.DataSource = m_CustomerMappingType.FilterDv
    End Sub


    Private Sub FilterSingleCustomerMapping()

        m_SingleCustomerMapping.Channel = txt4Channel.Text
        m_SingleCustomerMapping.CustomerCode = txt4CustomerCode.Text
        m_SingleCustomerMapping.EffectivityEndDate = dt4To.Value
        m_SingleCustomerMapping.EffectivityStartDate = dt4From.Value
        m_SingleCustomerMapping.Municipality = txt4Municipality.Text
        m_SingleCustomerMapping.Province = txt4Municipality.Text
        m_SingleCustomerMapping.RegionCode = txt4Region.Text
        m_SingleCustomerMapping.ShipToCode = txt4ShipToCode.Text
        m_SingleCustomerMapping.ShipToName = txt4ShipToName.Text
        m_SingleCustomerMapping.Territory = txt4Territory.Text

        dgSingleCustomerMapping.DataSource =(m_SingleCustomerMapping.FilterDv)
    End Sub

    Private Sub txtChannel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChannel.TextChanged, txtCustomerCode.TextChanged, txtMunicipality.TextChanged, txtProvince.TextChanged, txtRegion.TextChanged, txtShipToCode.TextChanged, txtShipToName.TextChanged, txtTerritory.TextChanged, dtFrom.ValueChanged, dtTo.ValueChanged
        If m_HasInitialized Then
            FilterCustomerMapping()
        End If
    End Sub

    Private Sub txtItemDivision_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemDivision.TextChanged, txtTerritory2.TextChanged, txtTerritoryName.TextChanged, txtMRCode.TextChanged, txtMRName.TextChanged, dtFrom2.ValueChanged, dtTo2.ValueChanged
        If m_HasInitialized Then
            FilterSalesMatrix()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked


        If Not m_CustomerMappingCache.WithErr And Not m_SalesMatrixCache.WithErr Then

            If chk3Override.Checked And chk4Override.Checked Then
                m_WithErr = False
            ElseIf chk3Override.Checked And Not m_CustomerMappingType.WithErr Then
                m_WithErr = False
            ElseIf chk4Override.Checked And Not m_SingleCustomerMapping.WithErr Then
                m_WithErr = False
            End If


        End If
        'If chk4Override.Checked Then



        '    If Not m_CustomerMappingCache.WithErr And Not m_SalesMatrixCache.WithErr And Not m_CustomerMappingType.WithErr And m_SingleCustomerMapping.WithErr Then
        '        m_WithErr = False
        '    End If
        'End If

        'If chk3Override.Checked Then
        '    If Not m_CustomerMappingCache.WithErr And Not m_SalesMatrixCache.WithErr And Not m_SingleCustomerMapping.WithErr And m_CustomerMappingType.WithErr Then
        '        m_WithErr = False
        '    End If
        'End If
        Me.Dispose()
    End Sub

    Private Sub txt3Channel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt3Channel.TextChanged, txt3CustomerCd.TextChanged, txt3Municipality.TextChanged, txt3Province.TextChanged, txt3RegCd.TextChanged, txt3ShipToCode.TextChanged, txt3ShipToName.TextChanged, txt3Type.TextChanged, txt3ZipCd.TextChanged, dt3From.ValueChanged, dt3To.ValueChanged, txt3AreaCovrg.TextChanged
        If m_HasInitialized Then
            FilterCustomerMappingType()
        End If
    End Sub

    Private Sub txt4Channel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt4Channel.TextChanged, txt4CustomerCode.TextChanged, txt4Municipality.TextChanged, txt4Province.TextChanged, txt4Region.TextChanged, txt4ShipToCode.TextChanged, txt4ShipToName.TextChanged, txt4Territory.TextChanged, dt4From.ValueChanged, dt4To.ValueChanged
        If m_HasInitialized Then FilterSingleCustomerMapping()

    End Sub
End Class