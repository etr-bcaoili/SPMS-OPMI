Alter procedure uspRebates

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
	@RebatesValue money= 0
	

	as

	if @Action='Save' begin
		
		if @RecordID=-1 begin
			
					insert into Rebates( CompanyCode, CustomerNumber, CustomerName, CustomerAddress1, CustomerAddress2, TransactionDate, InvoiceNumber, ItemNumber, ItemDescription, QuantitySold, QuantityFree, NetAmount, CUTMO, CUTYEAR, Status, RebatesPercentage, RebatesValue  )
					values( @CompanyCode, @CustomerNumber, @CustomerName, @CustomerAddress1, @CustomerAddress2, @TransactionDate,@InvoiceNumber, @ItemNumber, @ItemDescription, @QuantitySold, @QuantityFree, @NetAmount, @CUTMo, @CUTYear, @Status, @RebatesPercentage, @RebatesValue  )
					
					Select @@IDENTITY 
				end
				
				else
				 begin
				
					update Rebates
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
						RebatesValue= @RebatesValue 
						where RecordID= @RecordID							
						
				end
		end
		
		else if  @Action= 'Delete'
		begin
				delete from Rebates
				where RecordID=@RecordID
		end
			
			
											
		


