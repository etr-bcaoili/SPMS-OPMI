

Create procedure uspForRebatesTagging

@CompanyCode  varchar(10)='',
@CutMO int=0,
@CutYear int =0

as


select * from Rawdata rd where not  exists (select * from Rebates rb 
		where	rb.CustomerNumber=rd.CustomerNumber and 
				rb.ItemNumber=rd.ItemNumber and			
				rb.InvoiceNumber=rd.InvoiceNumber and 
				rb.CUTMO= rd.CUTMO 	and 
				rb.CUTYEAR= rd.CUTYEAR)
and rd.CompanyCode=@CompanyCode    
and rd.CUTMo=@CutMO 
and rd.CutYear=@CutYear  
and rd.NetAmount>=0