alter proc InvoiceDelete
	@InvoiceID varchar(50),
	@CreateUser varchar(50) ,
	@CompanyID varchar(50) 
as
begin

delete DepreciationDetail
where DepreciationID in (select DepreciationID from Depreciation where WareHouseDetailID in (select WareHouseDetailID from WareHouseDetail where  WarehouseID in(select WarehouseID from WareHouse where InvoiceID = @InvoiceID and CompanyID =@CompanyID and CreateUser =@CreateUser)))
and CreateUser = @CreateUser and CompanyID =@CompanyID

delete Depreciation
where WareHouseDetailID in (select WareHouseDetailID from WareHouseDetail where  WarehouseID in(select WarehouseID from WareHouse where InvoiceID = @InvoiceID and CompanyID =@CompanyID and CreateUser =@CreateUser))
and CreateUser = @CreateUser and CompanyID = @CompanyID

delete WareHouseDetail
where  WarehouseID in(select WarehouseID from WareHouse where InvoiceID = @InvoiceID and CompanyID =@CompanyID and CreateUser =@CreateUser) and CreateUser = @CreateUser and CompanyID = @CompanyID


delete WareHouse 
where InvoiceID = @InvoiceID and CompanyID =@CompanyID and CreateUser =@CreateUser

--aaa
delete Invoice
where InvoiceID = @InvoiceID and CompanyID =@CompanyID and CreateUser =@CreateUser
end