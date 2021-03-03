alter proc WareHouseDelete
	@WarehouseID varchar(50),
	@CreateUser varchar(50),
	@CompanyID varchar(50)
as
begin
delete DepreciationDetail
where DepreciationID in (select DepreciationID from Depreciation where WareHouseDetailID in (select WareHouseDetailID from WareHouseDetail where  WarehouseID = @WarehouseID and CreateUser = @CreateUser and CompanyID = @CompanyID) and CreateUser = @CreateUser and CompanyID =@CompanyID )
and CreateUser = @CreateUser and CompanyID =@CompanyID

delete Depreciation
where WareHouseDetailID in (select WareHouseDetailID from WareHouseDetail where  WarehouseID = @WarehouseID and CreateUser = @CreateUser and CompanyID = @CompanyID)
and CreateUser = @CreateUser and CompanyID = @CompanyID

delete WareHouseDetail
where  WarehouseID = @WarehouseID and CreateUser = @CreateUser and CompanyID = @CompanyID

delete WareHouse
where WarehouseID = @WarehouseID and CreateUser = @CreateUser and CompanyID = @CompanyID
end