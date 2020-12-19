create proc InvoiceUpdate
	@InvoiceID varchar(50),
	@CustomerID varchar(50) ,
	@Description nvarchar(max) ,
	@MaSo varchar(50) ,
	@MauSo varchar(50) ,
	@KyHieu varchar(50) ,
	@InvoiceNo varchar(50) ,
	@InvoiceType varchar(1) ,
	@InvoiceDate datetime ,
	@Amount money ,
	@VAT money ,
	@Discounts money ,
	@CreateUser varchar(50) ,
	@CompanyID varchar(50) 
as
begin
update Invoice
set 
	CustomerID=@CustomerID,
	Description=@Description,
	InvoiceFormNo=@MaSo,
	FormNo=@MauSo,
	SerialNo=@KyHieu,
	InvoiceNo=@InvoiceNo,
	InvoiceType=@InvoiceType,
	InvoiceDate=@InvoiceDate,
	Amount=@Amount,
	VAT=@VAT,
	Discounts=@Discounts,
	updatedate = getdate(),
	updateuser = @CreateUser
where InvoiceID = @InvoiceID and CompanyID =@CompanyID and CreateUser =@CreateUser
end