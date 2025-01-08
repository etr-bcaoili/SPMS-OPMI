ALTER PROCEDURE [dbo].[uspBillingOrder]
	@Action VARCHAR(100)= '',
	@BillingOrderID INT = -1,
	@BillingOrderNumber VARCHAR(15) = '',
	@CustomerID INT = -1,
	@ShipToCustomerID INT = -1,
	@Address VARCHAR(255) = '',
	@SalesManID INT = -1,
	@TransactionDate DATETIME = '1/1/1900',
	@VatStatus CHAR(1) = '',
	@InvoiceNumber VARCHAR(15) = '',
	@InvoiceDate DATETIME = '1/1/1900',
	@CreditTermKey INT = -1,
	@GrossTotal MONEY = 0,
	@GrossDiscount MONEY = 0,
    @NetTotal MONEY = 0,
	@Status INT = -1,
	@Remarks VARCHAR(255) = '',	
	@CreatedBy INT = -1,
	@CreateDate DATETIME = '1/1/1900',
	@LastModifiedBy INT = -1,
	@LastModifiedDate DATETIME = '1/1/1900',
	@Source INT = -1,
	@PriorityOrdinal INT = -1,
	@OrderType INT = -1,
	@RawDataID INT = -1,
	@DistributorCode VARCHAR(25) = '',
	@ShipToCode VARCHAR(25) = '',
	@TransactionType TINYINT = 0,
	@IsVatable BIT = 0,
	@TotalVat MONEY = 0,
	@InvoiceReferenceNumber VARCHAR(100) = '',
	@CMCode VARCHAR(25) = '',
	@ShipToName VARCHAR(255) = '',
	@ShipToAddress1 VARCHAR(255) = '',
	@ShipToAddress2 VARCHAR(255) = '',
	@VatInclusiveAmount MONEY = 0,
	@VatInclusiveRawDataNetAmount MONEY = 0,
	@VatInclusiveGrossAmount MONEY = 0,
	@VatInclusiveDiscount MONEY = 0,
	@VatInclusiveDiscountPercentage NUMERIC(12,6) = 0,
	@VatExclusiveRawDataNetAmount MONEY = 0,
	@VatExclusiveGrossAmount MONEY = 0,
	@VatExclusiveDiscount MONEY = 0,
	@VatExclusiveDiscountPercentage NUMERIC(12,6) = 0,
	@VatAmount MONEY = 0,
	@RowVersion INT = -1
AS
	IF @Action = 'Save' 

		IF @BillingOrderID = -1
			BEGIN

			INSERT INTO BillingOrder(BillingOrderNumber ,CustomerId ,ShipToCustomerId ,Address ,SalesManID, 
				TransactionDate ,VatStatus ,InvoiceNumber ,InvoiceDate ,CreditTermKey , GrossTotal ,
				GrossDiscount ,NetTotal ,Status , Remarks ,CreatedBy, CreateDate,LastModifiedBy,
				LastModifiedDate,[Source],PriorityOrdinal, OrderType, RawDataID, DistributorCode,
				ShipToCode, IsVatable, TotalVat, InvoiceReferenceNumber, CMCode, ShipToName, ShipToAddress1,
				ShipToAddress2, VatInclusiveAmount, VatInclusiveRawDataNetAmount, VatInclusiveGrossAmount,
				VatInclusiveDiscount, VatInclusiveDiscountPercentage, VatExclusiveRawDataNetAmount,
				VatExclusiveGrossAmount , VatExclusiveDiscount, VatExclusiveDiscountPercentage, VatAmount, [RowVersion]) 
			VALUES (@BillingOrderNumber ,@CustomerId ,@ShipToCustomerId ,@Address ,@SalesManID, 
				@TransactionDate ,@VatStatus ,@InvoiceNumber ,@InvoiceDate ,@CreditTermKey , @GrossTotal ,
				@GrossDiscount ,@NetTotal ,@Status , @Remarks ,@CreatedBy, @CreateDate,@LastModifiedBy,
				@LastModifiedDate,@Source,@PriorityOrdinal, @OrderType, @RawDataID, @DistributorCode,
				@ShipToCode, @IsVatable, @TotalVat, @InvoiceReferenceNumber, @CMCode, @ShipToName, @ShipToAddress1,
				@ShipToAddress2, @VatInclusiveAmount, @VatInclusiveRawDataNetAmount, @VatInclusiveGrossAmount,
				@VatInclusiveDiscount, @VatInclusiveDiscountPercentage, @VatExclusiveRawDataNetAmount,
				@VatExclusiveGrossAmount , @VatExclusiveDiscount, @VatExclusiveDiscountPercentage, @VatAmount, @RowVersion) 
						
			SELECT @@Identity

			END
		ELSE		
			BEGIN
				UPDATE BillingOrder SET				   
					BillingOrderNumber = @BillingOrderNumber,
					CustomerId = @CustomerId, 
					ShipToCustomerId = @ShipToCustomerId, 
					Address = @Address, 
					SalesManID  = @SalesManID,
					TransactionDate = @TransactionDate,
					VatStatus = @VatStatus, 
					InvoiceNumber = @InvoiceNumber,
					InvoiceDate = @InvoiceDate, 
					CreditTermKey = @CreditTermKey,
					GrossTotal = @GrossTotal, 
					GrossDiscount = @GrossDiscount,
					NetTotal = @NetTotal, 
					Status = @Status, 
					Remarks = @Remarks, 
					CreatedBy = @CreatedBy, 
					CreateDate = @CreateDate, 
					LastModifiedBy = @LastModifiedBy, 
					LastModifiedDate = @LastModifiedDate, 
					Source = @Source, 
					PriorityOrdinal = @PriorityOrdinal, 
					OrderType  = @OrderType,
					RawDataID = @RawDataID,
					DistributorCode = @DistributorCode,
					ShipToCode = @ShipToCode, 
					IsVatable = @IsVatable,
					TotalVat = @TotalVat,
					InvoiceReferenceNumber = @InvoiceReferenceNumber,
					CMCode = @CMCode,
					ShipToName = @ShipToName,
					ShipToAddress1 = @ShipToAddress1,
					ShipToAddress2 = @ShipToAddress2,
					VatInclusiveAmount = @VatInclusiveAmount,
					VatInclusiveRawDataNetAmount = @VatInclusiveRawDataNetAmount,
					VatInclusiveGrossAmount = @VatInclusiveGrossAmount,
					VatInclusiveDiscount = @VatInclusiveDiscount,
					VatInclusiveDiscountPercentage = @VatInclusiveDiscountPercentage,
					VatExclusiveRawDataNetAmount = @VatExclusiveRawDataNetAmount,
					VatExclusiveGrossAmount = @VatExclusiveGrossAmount, 
					VatExclusiveDiscount = @VatExclusiveDiscount,
					VatExclusiveDiscountPercentage = @VatExclusiveDiscountPercentage, 
					VatAmount = @VatAmount,
					[RowVersion] = @RowVersion

			 	WHERE  BillingOrderID = @BillingOrderID
				
			 	SELECT @BillingOrderID
			
			END

		ELSE IF @Action = 'Delete' 
			BEGIN
				DELETE FROM BillingOrder
					WHERE BillingOrderID = @BillingOrderID
			END	