	ALTER proc [dbo].[WarehouseListDelete]
	@WarehouseListID varchar(50),
	@CreateUser varchar(50),
	@CompanyID varchar(50)
	as
	begin
	delete WarehouseList
	where WarehouseListID = @WarehouseListID and CreateUser = @CreateUser and CompanyID = @CompanyID
	end