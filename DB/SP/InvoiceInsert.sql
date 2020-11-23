
InvoiceInsert 'test','test','test','test','test','test','test','test','t','2020-11-22',10,10.00,20,'Phat','Test'

select * from Invoice

alter table Invoice
alter column VAT decimal

alter proc InvoiceInsert
	@InvoiceID varchar(50),
	@VouchersID varchar(50) ,
	@CustomerID varchar(50) ,
	@Description nvarchar(max) ,
	@MaSo varchar(50) ,
	@MauSo varchar(50) ,
	@KyHieu varchar(50) ,
	@InvoiceNo varchar(50) ,
	@InvoiceType varchar(1) ,
	@InvoiceDate datetime ,
	@Amount money ,
	@VAT decimal ,
	@Discounts money ,
	@CreateUser varchar(50) ,
	@CompanyID varchar(50) 
as
begin
INSERT INTO Invoice(
	InvoiceID,
	VouchersID,
	CustomerID,
	Description,
	MaSo,
	MauSo,
	KyHieu,
	InvoiceNo,
	InvoiceType,
	InvoiceDate,
	Amount,
	VAT,
	Discounts,
	CreateDate,
	CreateUser,
	CompanyID)
	VALUES(
	@InvoiceID,
	@VouchersID,
	@CustomerID,
	@Description,
	@MaSo,
	@MauSo,
	@KyHieu,
	@InvoiceNo,
	@InvoiceType,
	@InvoiceDate,
	@Amount,
	@VAT,
	@Discounts,
	getdate(),
	@CreateUser,
	@CompanyID)
end