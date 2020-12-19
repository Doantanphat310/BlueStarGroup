
create proc WareHouseSelectInvoiceID
@InvoiceID varchar(50), @CompanyID varchar(50), @CreateUser varchar(50)
as
begin
select * from WareHouse
where InvoiceID = @InvoiceID and CompanyID = @CompanyID and CreateUser = @CreateUser and IsDelete is NULL
end


create proc WareHouseSelectVoucherID
@VoucherID varchar(50), @CompanyID varchar(50), @CreateUser varchar(50)
as
begin
select * from WareHouse
where VouchersID = @VoucherID and CompanyID = @CompanyID and CreateUser = @CreateUser and IsDelete is NULL
end