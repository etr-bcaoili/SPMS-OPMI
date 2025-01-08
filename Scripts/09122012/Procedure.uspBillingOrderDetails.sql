ALTER   PROCEDURE [dbo].[uspBillingOrderDetails]
	@Action VARCHAR(100)= '',
	@BillingOrderDetailID INT = -1,
	@BillingOrderID INT = -1,
	@ItemID INT = -1,
	@Quantity NUMERIC(12,6) = -1,
	@UnitOfMeasureID INT = -1,
	@Discount VARCHAR(50) = '',
	@Amount MONEY = 0,
	@UnitPrice MONEY = 0,
	@DiscountAmount MONEY = 0,
	@WarehouseID INT = -1,
	@WarehouseLocationID INT = -1,
	@Lot VARCHAR(20) = '',
	@ListPrice MONEY = 0,
    @IsFreeGoods BIT = 0,
	@ExpiryDate DATETIME = '1/1/1900',
	@ManufacturingDate DATETIME = '1/1/1900',
	@Remarks VARCHAR(255) = '',	
	@RawDataID INT = -1,
	@RawDataAmount MONEY = 0,
	@NetAmount MONEY = 0,
	@FreeGoods NUMERIC(12,6) = 0,
	@VatAmount MONEY = 0,
	@VatInclusiveAmount MONEY = 0,
	@VatInclusiveRawDataNetAmount MONEY = 0,
	@VatInclusiveGrossAmount MONEY = 0,
	@VatInclusiveDiscount MONEY = 0,
	@VatInclusiveDiscountPercentage NUMERIC(12,6) = 0,
	@VatExclusiveRawDataNetAmount MONEY = 0,
	@VatExclusiveGrossAmount MONEY = 0,
	@VatExclusiveDiscount MONEY = 0,
	@VatExclusiveDiscountPercentage NUMERIC(12,6) = 0
	
AS
	IF @Action = 'Save' 

		IF @BillingOrderDetailID = -1
			BEGIN

			INSERT INTO BillingOrderDetails(BillingOrderID,ItemID,Quantity,UnitOfMeasureID, 
				Discount,Amount ,UnitPrice,DiscountAmount, 
				WarehouseID,WarehouseLocationID,Lot,ListPrice,IsFreeGoods, 
				ExpiryDate,ManufacturingDate,Remarks, RawDataID, RawDataAmount, NetAmount,
				FreeGoods ,VatAmount, VatInclusiveAmount, VatInclusiveRawDataNetAmount,
				VatInclusiveGrossAmount, VatInclusiveDiscount, VatInclusiveDiscountPercentage,
				VatExclusiveRawDataNetAmount, VatExclusiveGrossAmount, VatExclusiveDiscount,
				VatExclusiveDiscountPercentage) 
			VALUES (@BillingOrderID,@ItemID,@Quantity,@UnitOfMeasureID, 
				@Discount,@Amount,@UnitPrice,@DiscountAmount, 
				@WarehouseID,@WarehouseLocationID,@Lot,@ListPrice,@IsFreeGoods, 
				@ExpiryDate, @ManufacturingDate, @Remarks, @RawDataID, @RawDataAmount, @NetAmount,
				@FreeGoods, @VatAmount, @VatInclusiveAmount, @VatInclusiveRawDataNetAmount,
				@VatInclusiveGrossAmount, @VatInclusiveDiscount, @VatInclusiveDiscountPercentage,
				@VatExclusiveRawDataNetAmount, @VatExclusiveGrossAmount, @VatExclusiveDiscount,
				@VatExclusiveDiscountPercentage) 
						
			SELECT @@Identity

			END
		ELSE		
			BEGIN
				UPDATE BillingOrderDetails SET				
					BillingOrderID = @BillingOrderID,
					ItemID = @ItemID,
					Quantity = @Quantity,
					UnitOfMeasureID = @UnitOfMeasureID, 
					Discount= @Discount,
					Amount = @Amount, 
					UnitPrice = @UnitPrice,
					DiscountAmount = @DiscountAmount, 
					WarehouseID = @WarehouseID,
					WarehouseLocationID = @WarehouseLocationID,
					Lot = @Lot,
					ListPrice = @ListPrice,
					IsFreeGoods = @IsFreeGoods, 
					ExpiryDate = @ExpiryDate,
					ManufacturingDate = @ManufacturingDate,
					Remarks = @Remarks,
					RawDataID = @RawDataID,
					RawDataAmount = @RawDataAmount, 
					NetAmount = @NetAmount,
					FreeGoods = @FreeGoods,
					VatAmount = @VatAmount,
					VatInclusiveAmount = @VatInclusiveAmount,
					VatInclusiveRawDataNetAmount = @VatInclusiveRawDataNetAmount,
					VatinclusiveGrossAmount = @VatInclusiveGrossAmount,
					VatInclusiveDiscount = @VatInclusiveDiscount, 
					VatInclusiveDiscountPercentage = @VatInclusiveDiscountPercentage,
					VatExclusiveRawDataNetAmount = @VatExclusiveRawDataNetAmount,
					VatExclusiveGrossAmount = @VatExclusiveGrossAmount,
					VatExclusiveDiscount = @VatExclusiveDiscount,
					VatExclusiveDiscountPercentage = @VatExclusiveDiscountPercentage
			 	WHERE  BillingOrderDetailID = @BillingOrderDetailID
				
			 	SELECT @BillingOrderDetailID
			
			END

		ELSE IF @Action = 'Delete' 
			BEGIN
				DELETE FROM BillingOrderDetails
					WHERE BillingOrderDetailID = @BillingOrderDetailID
			END	