Alter procedure uspRebatesPayment

	@Action varchar(100)='',
	@RecordID int = -1,
	@CompanyCode varchar(10)='',
	@CustomerNumber varchar(25)='',
	@CustomerName varchar(255)='',
	@CustomerAddress1 varchar(255)='',
	@CustomerAddress2 varchar(255)='',
	@TransactionDate varchar(8)='',
	@InvoiceNumber varchar(10)='',
	@ItemNumber varchar(20)='',
	@ItemDescription varchar(255)='',
	@QuantitySold integer=0,
	@QuantityFree integer=0,
	@NetAmount money=0,
	@CUTMo varchar(10)='',
	@CUTYear varchar(10)='',
	@Status smallint =0,
	@RebatesPercentage decimal(10,2)=0,
	@RebatesValue money= 0,
	@CheckNumber varchar(30)='',
	@PaymentAmount money=0,
	@RemainingBalance money=0,
	@CreateDate datetime='01/01/1990',
	@CreatedBy int =-1
	
	as
	
	set @CreateDate=GETDATE()


	if @Action='Save' begin
		
		
		
		if @RecordID=-1 begin
			
					insert into RebatesDetail( CompanyCode, CustomerNumber, CustomerName, CustomerAddress1, CustomerAddress2, TransactionDate, InvoiceNumber, ItemNumber, ItemDescription, QuantitySold, QuantityFree, NetAmount, CUTMO, CUTYEAR, Status, RebatesPercentage, RebatesValue, CheckNumber, PaymentAmount, RemainingBalance, CreateDate, CreatedBy   )
					values( @CompanyCode, @CustomerNumber, @CustomerName, @CustomerAddress1, @CustomerAddress2, @TransactionDate,@InvoiceNumber, @ItemNumber, @ItemDescription, @QuantitySold, @QuantityFree, @NetAmount, @CUTMo, @CUTYear, @Status, @RebatesPercentage, @RebatesValue, @CheckNumber, @PaymentAmount, @RemainingBalance, @CreateDate, @CreatedBy   )
					
					Select @@IDENTITY 
				end
				
				else
				 begin
				
					update RebatesDetail 
					set CompanyCode= @CompanyCode,
						CustomerName= @CustomerName,
						CustomerNumber= @CustomerNumber,
						CustomerAddress1= @CustomerAddress1,
						CustomerAddress2= @CustomerAddress2,
						TransactionDate= @TransactionDate,
						ItemNumber= @ItemNumber,
						ItemDescription= @ItemDescription,
						QuantitySold= @QuantitySold,
						QuantityFree = @QuantityFree,
						NetAmount= @NetAmount,
						CUTMO= @CUTMo,
						CUTYEAR= @CUTYear,
						Status= @Status,
						RebatesPercentage= @RebatesPercentage,
						RebatesValue= @RebatesValue,
						CheckNumber= @CheckNumber,
						PaymentAmount= @PaymentAmount,
						RemainingBalance= @RemainingBalance,
						CreateDate= @CreateDate,
						CreatedBy= @CreatedBy 
						 
						where RecordID= @RecordID							
						
				end
		end
		
		else if  @Action= 'Delete'
		begin
				delete from Rebates
				where RecordID=@RecordID
		end
			
			
											
		


