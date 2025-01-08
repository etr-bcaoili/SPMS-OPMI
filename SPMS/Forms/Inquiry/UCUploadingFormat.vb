Public Class UCUploadingFormat

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub



    Private Sub UCUploadingFormat_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyGridTheme(dgUpload)
        LoadCustomerUploadFormat()
    End Sub


    Private Sub LoadCustomerUploadFormat()
        dgUpload.Columns.Clear()
        dgUpload.Rows.Clear()
        dgUpload.Columns.Add("colChannel", "Channel")
        dgUpload.Columns.Add("colCustomerCode", "Customer Code")
        dgUpload.Columns.Add("colCustomerName", "Customer Name")
        dgUpload.Columns.Add("colShipToCode", "Ship To Code")
        dgUpload.Columns.Add("colShipToName", "Ship To Name")
        dgUpload.Columns.Add("colAddress1", "Address 1")
        dgUpload.Columns.Add("colAddress2", "Address2")
        dgUpload.Columns.Add("colRegionCode", "Region Code")
        dgUpload.Columns.Add("colRegionName", "Region Name")
        dgUpload.Columns.Add("colProvinceCode", "Province Code")
        dgUpload.Columns.Add("colProvinceName", "Province Name")
        dgUpload.Columns.Add("colMunicipalityCode", "Municipality Code")
        dgUpload.Columns.Add("colMunicipalityName", "Municipality Name")
        dgUpload.Columns.Add("colZipCode", "ZipCode")
        dgUpload.Columns.Add("colCustomerClass", "Customer Class")
        dgUpload.Columns.Add("colCustomerGroup", "Customer Group")

    End Sub
End Class
