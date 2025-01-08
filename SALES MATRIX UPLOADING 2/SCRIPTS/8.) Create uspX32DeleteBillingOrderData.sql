
CREATE PROCEDURE uspX32DeleteBillingOrderData
	@CompanyCode VARCHAR(100) = '',
	@UploadDate DATETIME = '1/1/1900'


AS
	Set @CompanyCode = 'MDI'
	
	SET @UploadDate = (SELECT TOP 1 UploadDate  FROM althearawdata.dbo.historicalrawdata WHERE CompanyCode = @CompanyCode ORDER BY UploadDate DESC)


	
	SELECT DISTINCT rawdataid  AS RawDataID
	INTO #tmpRawDataID
	FROM althearawdata.dbo.historicalrawdata
	WHERE CompanyCode = @CompanyCode
	And UploadDate = @UploadDate

	
	/* Delete Agent Sharing*/
	Delete From BillingOrderAgent
		WHERE RawDataID IN (SELECT * FROM #tmpRawdataID)
	/* Delete Billing Order Details */
	Delete From BillingOrderDetails 
		WHERE RawDataID IN (SELECT * FROM #tmpRawdataID)
	/* Delete Billing Order*/
	Delete From BillingOrder
		WHERE RawDataID IN (SELECT * FROM #tmpRawdataID)

GO