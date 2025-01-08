SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

ALTER   PROCEDURE uspRawData 
	@CompanyCode VARCHAR(10)= '',
	@BranchCode VARCHAR(10) = '',
	@BranchName VARCHAR(255) = '',
	@CustomerNumber VARCHAR(10) = '',
	@CustomerName VARCHAR(255) = '',
	@CustomerAddress1 VARCHAR(255) = '',
	@CustomerAddress2 VARCHAR(255) = '',
	@TransactionDate VARCHAR(8) = '',
	@InvoiceNumber VARCHAR(10) = '',
	@TransactionType VARCHAR(2) = '',
	@ItemNumber VARCHAR(20) = '',
	@ItemDescription VARCHAR(3) = '',
	@WarehouseNumber VARCHAR(3) = '',
	@Class VARCHAR(3) = '',
	@QuantitySold INT = -1,
	@QuantityFree INT = -1,
	@GrossAmount MONEY = 0,
	@LineDiscount MONEY = 0,
	@ProductDiscount MONEY = 0,
	@VatCode VARCHAR(1) = '',
	@Route VARCHAR(6) = '',
	@Taxes MONEY = 0,
	@Freight MONEY = 0,
	@Additional MONEY = 0,
	@NetAmount MONEY = 0,
	@UnitPrice MONEY = 0,
	@InvoiceReferenceNumber INT = -1,
	@CMCode VARCHAR(3) = '',
	@SONumber INT = -1,
	@SODate INT = -1,
	@SOTerms VARCHAR(6) = '',
	@ExpiryDate INT = -1,
	@LotNumber VARCHAR(15) = '',
	@SalesmanNumber VARCHAR(3) = '',
	@SalesmanName VARCHAR(24) = '',
	@ShipToName VARCHAR(50) = '',
	@ShipToAddress1 VARCHAR(50) = '',
	@ShipToAddress2 VARCHAR(50) = '',
	@ZipCode VARCHAR(6) = '',
	@TerritoryNumber VARCHAR(3) = '',
	@Area VARCHAR(3) = '',
	@CustomerClass VARCHAR(3) = '',
	@ClassName VARCHAR(24) = '',
	@Principal VARCHAR(3) = '',
	@SubPrincipal VARCHAR(6) = '',
	@PrincipalDivisionCode VARCHAR(3) = '',
	@SalesWeek VARCHAR(1) = '',
	@CustomerDeliveryCode VARCHAR(3) = '',
	@ListPriceTaxInclude VARCHAR(9) = '',
	@ContractPrincipalApprovalNumber VARCHAR(15) = '',
	@OrderType VARCHAR(1) = '',
	@IsCode VARCHAR(255) = ''

AS
	IF @CompanyCode = 'MDI' BEGIN
		
		INSERT INTO RawData(CompanyCode,BranchCode,BranchName,CustomerNumber,CustomerName,
			CustomerAddress1,CustomerAddress2,TransactionDate,InvoiceNumber,TransactionType,
			ItemNumber,ItemDescription,WarehouseNumber,Class,QuantitySold,			
			QuantityFree,GrossAmount,LineDiscount,ProductDiscount,VatCode,
			Route,Taxes,Freight,Additional,NetAmount,
			UnitPrice,InvoiceReferenceNumber,CMCode,SONumber,SODate,
			SOTerms,ExpiryDate,LotNumber,SalesmanNumber,SalesmanName,
			ShipToName,ShipToAddress1,ShipToAddress2,ZipCode,TerritoryNumber,
			Area,CustomerClass,ClassName,Principal,SubPrincipal,PrincipalDivisionCode,
			SalesWeek,CustomerDeliveryCode,ListPriceTaxInclude,ContractPrincipalApprovalNumber,OrderType,IsCode)
		VALUES (@CompanyCode,@BranchCode,@BranchName,@CustomerNumber,@CustomerName,
			@CustomerAddress1,@CustomerAddress2,@TransactionDate,@InvoiceNumber,TransactionType,
			@ItemNumber,@ItemDescription,@WarehouseNumber,@Class,@QuantitySold,			
			@QuantityFree,@GrossAmount,@LineDiscount,@ProductDiscount,@VatCode,
			@Route,Taxes,@Freight,@Additional,@NetAmount,
			@UnitPrice,@InvoiceReferenceNumber,@CMCode,@SONumber,@SODate,
			@SOTerms,@ExpiryDate,@LotNumber,@SalesmanNumber,@SalesmanName,
			@ShipToName,@ShipToAddress1,@ShipToAddress2,@ZipCode,@TerritoryNumber,
			@Area,@CustomerClass,@ClassName,@Principal,@SubPrincipal,@PrincipalDivisionCode,
			@SalesWeek,@CustomerDeliveryCode,@ListPriceTaxInclude,@ContractPrincipalApprovalNumber,@OrderType,@IsCode)
	END	
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


