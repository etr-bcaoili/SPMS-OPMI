create table RebatesDetail
(RecordID int identity(1,1) primary key,
CompanyCode	varchar(10) not null,
CustomerNumber  varchar(25) not null,
CustomerName varchar(255) not null,
CustomerAddress1 varchar(255) not null,
CustomerAddress2 varchar(255) not null,
TransactionDate varchar(8) not null,
InvoiceNumber varchar(10) not null,
ItemNumber varchar(20) not null,
ItemDescription varchar(255) not null,
QuantitySold int not null,
QuantityFree int not null,
NetAmount money not null,
CUTMO varchar(10) not null,
CUTYEAR varchar(10) not null,
Status tinyint not null,
RebatesPercentage decimal(18,2) not null,
RebatesValue money not null,

CheckNumber varchar(30) not null,
PaymentAmount money not null,
RemainingBalance money not null,
CreateDate datetime not null,
CreatedBy int not null
)


