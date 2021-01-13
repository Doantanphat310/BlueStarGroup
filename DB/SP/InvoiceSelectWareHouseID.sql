Create proc InvoiceSelectWareHouseID
@InvoiceID varchar(50), @CompanyID varchar(50)
as
begin

	select top(1) WarehouseID from WareHouse
	where InvoiceID = @InvoiceID and CompanyID = @CompanyID
end