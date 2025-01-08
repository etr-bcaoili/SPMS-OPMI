SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE uspUploadingMercury
	@DistributorCode VARCHAR(100) = '',

	--@CustomerID INT OUTPUT,
	--@DistributorCode VARCHAR(15) OUTPUT,
	--@CustomerAccountNumber VARCHAR(255) OUTPUT,
	@Address VARCHAR(255) OUTPUT,
	@CustomerStoreName VARCHAR(255) OUTPUT,
	--@RegionKey INT OUTPUT,
	--@CityKey INT OUTPUT,
	--@ProvinceKey INT OUTPUT
AS


SELECT 	@CustomerStoreName = [ShipToCustomer].[Cust_StoreName] AS [Customer],
			@Address = [Addresses].[AddressString] AS [Address]
FROM		[Customers],
			[CustomerShipToDetails],
			[Customers] AS [ShiptoCustomer],
			[Addresses]
WHERE	[CustomerShipToDetails].[CustomerID] = [Customers].[Custkey]
AND		[ShiptoCustomer].[Custkey] = [CustomerShipToDetails].[ShipToCustomerID]
AND		[Addresses].[AddressID] = [ShipToCustomer].[CustomerAddressID]
AND		[Customers].[Custkey] 
IN 			(SELECT [custkey] FROM [Customers] WHERE Cust_StoreName = 'MERCURY DRUG CORPORATION')
AND		[CustomerShipToDetails].[DistributorCode] = @DistributorCode

/*
SELECT 		       @CustomerID = b.CustKey ,
		       @CustomerAccountNumber = b.cust_accntno,
		       @DistributorCode = c.DistributorCode, 
		       @CustomerStoreName = b.Cust_StoreName , 
		       @Address = A.addressstring ,
		       @RegionKey = A.RegionKey, 
		       @CityKey = A.CityKey, 
		       @ProvinceKey = A.ProvinceKey

FROM 			addresses  a ,
					customers b,
					customershiptodetails c

WHERE  		a.addressid = b.customeraddressid
and				b.custkey = @CustomerKey 
and				A.addressid 
in				(SELECT customeraddressid 
				 FROM   customers 
				 WHERE  custkey 
				 IN((SELECT shiptocustomerid 
					 FROM   customershiptodetails 
					 WHERE  CustomerID 
				IN (Select CustKey 
					FROM   Customers 
					WHERE  RawDataCustomerCode <> '')) ))
*/


RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO