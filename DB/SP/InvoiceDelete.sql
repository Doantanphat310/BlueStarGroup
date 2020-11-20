create proc InvoiceDelete
	@InvoiceID varchar(50),
	@CreateUser varchar(50) ,
	@CompanyID varchar(50) 
as
begin
update Invoice
set IsDelete = 0
where InvoiceID = @InvoiceID and CompanyID =@CompanyID and CreateUser =@CreateUser

update WareHouse 
set IsDelete = 0
where InvoiceID = @InvoiceID and CompanyID =@CompanyID and CreateUser =@CreateUser

update WareHouseDetail
set IsDelete = 0
where  WarehouseID in(select WarehouseID from WareHouse where InvoiceID = @InvoiceID and CompanyID =@CompanyID and CreateUser =@CreateUser) and CreateUser = @CreateUser and CompanyID = @CompanyID

update Depreciation
set IsDelete = 0
where WareHouseDetailID in (select WareHouseDetailID from WareHouseDetail where  WarehouseID in(select WarehouseID from WareHouse where InvoiceID = @InvoiceID and CompanyID =@CompanyID and CreateUser =@CreateUser))
and CreateUser = @CreateUser and CompanyID = @CompanyID

update DepreciationDetail
set IsDelete = 0
where DepreciationID in (select DepreciationID from Depreciation where WareHouseDetailID in (select WareHouseDetailID from WareHouseDetail where  WarehouseID in(select WarehouseID from WareHouse where InvoiceID = @InvoiceID and CompanyID =@CompanyID and CreateUser =@CreateUser)))
and CreateUser = @CreateUser and CompanyID =@CompanyID

end