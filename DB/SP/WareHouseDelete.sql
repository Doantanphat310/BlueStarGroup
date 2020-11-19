create proc WareHouseDelete
	@WarehouseID varchar(50),
	@CreateUser varchar(50),
	@CompanyID varchar(50)
as
begin
update WareHouse
set IsDelete = 0
	where WarehouseID = @WarehouseID and CreateUser = @CreateUser and CompanyID = @CompanyID
update WareHouseDetail
set IsDelete = 0
where  WarehouseID = @WarehouseID and CreateUser = @CreateUser and CompanyID = @CompanyID

update Depreciation
set IsDelete = 0
where WareHouseDetailID in (select WareHouseDetailID from WareHouseDetail where  WarehouseID = @WarehouseID and CreateUser = @CreateUser and CompanyID = @CompanyID)
and CreateUser = @CreateUser and CompanyID = @CompanyID

update DepreciationDetail
set IsDelete = 0
where DepreciationID in (select DepreciationID from Depreciation where WareHouseDetailID in (select WareHouseDetailID from WareHouseDetail where  WarehouseID = @WarehouseID and CreateUser = @CreateUser and CompanyID = @CompanyID) and CreateUser = @CreateUser and CompanyID =@CompanyID )
and CreateUser = @CreateUser and CompanyID =@CompanyID
end